
type point = int * int // a point (x, y) in the plane
type color = ImgUtil . color

type figure =
    | Circle of point * int * color // defined by center , radius , and color
    | Rectangle of point * point * color // defined by corners top -left , bottom -right , and color
    | Mix of figure * figure // combine figures with mixed color at overlap

// finds color of figure at point
let rec colorAt (x,y) figure =
    match figure with
    | Circle ((cx,cy) , r , col ) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
// uses Pythagoras ' equation to determine
// distance to center
        then Some col else None
    | Rectangle ((x0,y0) , (x1,y1) , col) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1
// within corners
        then Some col else None
    | Mix (f1,f2) ->
        match (colorAt (x,y) f1, colorAt (x,y) f2) with
        | (None , c) -> c // no overlap
        | (c , None ) -> c // no overlap
        | (Some c1 , Some c2) ->
        let (a1,r1,g1,b1) = ImgUtil.fromColor c1
        let (a2,r2,g2,b2) = ImgUtil.fromColor c2
        in Some (ImgUtil.fromArgb((a1+a2)/2, (r1+r2)/2, // calculate
                                      (g1+g2)/2, (b1+b2)/2)) // average color


//8i0

let figTest : figure =
   Mix (Circle ((50,50), 45, ImgUtil.red), Rectangle ((40,40), (90,110), ImgUtil.blue))


//8i1

///<summary> Funktionen makePicture laver et billede i form af en .png fil</summary>
///<example> Kaldet <c>makePicture "Hello" figurA 100 150</c> laver en fil der hedder Hello.png 
/// med brede på 100 pixel og højde på 150 pixel, der er også en figur på billedet, baggrunden af billedet er gråt. <c>['c'; 'b'; 'd'; 'a']</c>. </example>
///<param name="name"> inputtet er en string som skal bestemme filens navn</param>
///<param name="figur"> inputtet er en figur/ flere figurer som kan enten være cirkler eller rektangler, bestemmes af typen figure</param>
///<param name="b"> inputtet er en integer der bestemmer hvor bredt selve billedet er</param>
///<param name="h"> inputtet er en integer der bestemmer hvor højt selve billedet er</param>
///<returns> Laver en .png fil </returns>

let makePicture (name:string) (figur:figure) (b:int) (h:int) : unit =
    let Canvas = ImgUtil.mk b h
    for x = 0 to b-1 do
        for y = 0 to h-1 do
            match colorAt (x,y) figur with
                | Some col -> 
                  ImgUtil.setPixel col (x,y) Canvas
                | None -> 
                  ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128)) (x,y) Canvas
                
    do ImgUtil.toPngFile (name + ".png") Canvas

//8i2

makePicture "figTest" figTest 100 150
// Billedet af vil blive gemt i src/ mappen

//8i3

///<summary> Funktionen checkFigure tjekker om en/flere figurer udfylder betingelserne</summary>
///<example> Kaldet <c>checkFigure figurA</c> returnerer <c>true</c> fordi figurA er en cirkel med en positiv radius. </example>
///<param name="figure"> inputtet er en figur/ flere figurer som kan enten være cirkler eller rektangler, bestemmes af typen figure </param>
///<returns> Returner true hvis radius er non-negativ, det returnerer også true hvis øverste venstre hjørne i en rektangel faktisk er ovenover
/// og til venstre for det nederste højre hjørne </returns>

let rec checkFigure figure : bool =
    match figure with
    | Circle ((cx,cy), r, col) -> 
        r >= 0 
    | Rectangle ((x0,y0), (x1,y1), col) ->
        x0 <= x1 && y0 <= y1 
    | Mix (f1,f2) -> 
        checkFigure f1 && checkFigure f2


//8i4

///<summary> Funktionen move rykker placeringen af en eller flere figurer </summary>
///<example> Kaldet <c>move figurA 0 20</c> returnerer en cirkel som er rykket 20 pixel ned. </example>
///<param name="figure"> inputtet er en figur/ flere figurer som kan enten være cirkler eller rektangler, bestemmes af typen figure </param>
///<param name="v"> inputtet er en vektor bestående af to integer </param>
///<returns> Returner en ny figur </returns>

let rec move figure (v: int*int) : figure =
    match figure with
    | Circle ((cx,cy), r, col) -> 
        Circle ((cx + fst v, cy + snd v), r, col)
    | Rectangle ((x0,y0), (x1,y1), col) -> 
        Rectangle ((x0 + fst v, y0 + snd v), (x1 + fst v, y1 + snd v), col)
    | Mix (f1,f2) -> 
        Mix (move f1 v, move f2 v)

makePicture "moveTest" (move figTest (-20,20)) 100 150
// Billedet af vil blive gemt i src/ mappen

//8i5

///<summary> Funktionen boundingBox returnerer to punkter der betegner øverste venstre hjørne og 
/// nedeste højre hjørne af den mindste akserette rektangel, der indeholder hele figuren </summary>
///<example> Kaldet <c>boundingBox figurA </c> returnerer to punkter der betegner øverste venstre 
/// hjørne og nedeste højre hjørne af en rektangel der indeholder figurA </example>
///<param name="figure"> inputtet er en figur/ flere figurer som kan enten være cirkler eller rektangler, bestemmes af typen figure </param>
///<returns> Returner to punkter </returns>

let rec boundingBox figure : (point*point) =
    match figure with 
    | Circle ((cx,cy), r, col) -> 
        (cx - r, cy - r), (cx + r, cy + r)
    | Rectangle ((x0,y0), (x1,y1), col) -> 
        (x0,y0), (x1,y1)
    | Mix (f1, f2) -> 
        let (a1,a2), (b1,b2) = boundingBox f1 
        let (c1,c2), (d1,d2) = boundingBox f2
        (min a1 c1, min a2 c2), (max b1 d1, max b2 d2)
