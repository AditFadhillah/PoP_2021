type point = int * int // a point (x, y) in the plane
type color = ImgUtil.color

type figure =
    | Circle of point * int * color
// defined by center , radius , and color
    | Rectangle of point * point * color
// defined by corners top -left , bottom -right , and color
    | Mix of figure * figure
// combine figures with mixed color at overlap


// finds color of figure at point
let rec colorAt (x,y) figure =
    match figure with
    | Circle ((cx,cy), r, col) ->
        if (x-cy)*(x-cx)+(y-cy)*(y-cy) <= r*r
            // uses Pythagoras ' equation to determine
            // distance to center
        then Some col else None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1
            // within corners
        then Some col else None
    | Mix (f1,f2) ->
        match ( colorAt (x,y) f1 , colorAt (x,y) f2) with 
        | (None , c) -> c // no overlap
        | (c, None) -> c  // no overlap
        | (Some c1, Some c2) ->
        let (a1,r1,g1,b1) = ImgUtil.fromColor c1
        let (a2,r2,g2,b2) = ImgUtil.fromColor c2
        in Some ( ImgUtil.fromArgb ((a1+a2)/2,(r1+r2)/2,(g1+g2)/2,(b1+b2)/2))   


(*
let C = ImgUtil.mk 256 256
do ImgUtil.setPixel ( ImgUtil.fromRgb (255 ,0 ,0) ) (10 ,10) C
do ImgUtil.toPngFile "test.png" C
*)

//let C = ImgUtil.mk 100 120
let figTest : figure = Mix ((Circle ((50,50), 45, (ImgUtil.red))), (Rectangle ((40,40), (90,110), (ImgUtil.blue))))
//do ImgUtil.toPngFile "test.png" C


///<summary> Funktionen makePicture laver et billedet i form af en .png fil</summary>
///<example> Kaldet <c>makePicture "Hello" figurA 100 150</c> laver en fil der hedder Hello.png 
/// med brede på 100 pixel og højde på 150 pixel, der er også en figur på billedet, baggrunden af billedet er gråt. <c>['c'; 'b'; 'd'; 'a']</c>. </example>
///<param name="name"> inputtet er en string som skal bestemme filens navn</param>
///<param name="figur"> inputtet er en figur/ flere figurer som kan enten være cirkler eller rektangler, bestemmes af typen figure</param>
///<param name="b"> inputtet er en integer der bestemmer hvor bredt selve billedet er</param>
///<param name="h"> inputtet er en integer der bestemmer hvor højt selve billedet er</param>
///<returns> Laver en .png fil </returns>
let makePicture (name:string) (figur:figure) (b:int) (h:int) : unit =
    let C = ImgUtil.mk b h
    let mutable x = 0 
    let mutable y = 0 
    let mutable i = 0 
    while i < b * h do
        let color = colorAt (x,y) figur
        if x = b then
            y <- y + 1
            x <- 0
        else
        match color with
        | Some color -> 
          ImgUtil.setPixel color (x,y) C
          i <- i + 1
          x <- x + 1
        | None ->
          ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128) ) (x,y) C
          i <- i + 1
          x <- x + 1 

    do ImgUtil.toPngFile (name + ".png") C

makePicture "figTest" figTest 100 150

///<summary> Funktionen checkFigure </summary>
///<param name="figure"> inputtet er en liste, som vi skal undersøge om det er en liste </param>
///<returns> Returne  </returns>
let rec checkFigure figure : bool =
    match figure with
    | Circle ((cx,cy), r, col) -> 
        r >= 0 
    | Rectangle ((x0,y0), (x1,y1), col) ->
        x0 < x1 && y0 < y1
    | Mix (f1,f2) -> 
        checkFigure f1 && checkFigure f2

// printfn "%b" (checkFigure figTest)

///<summary> Funktionen move </summary>
///<param name="figure"> inputtet er en liste, som vi skal undersøge om det er en liste </param>
///<param name="v"> inputtet er en liste, som vi skal undersøge om det er en liste </param>
///<returns> Returner  </returns>
let rec move figure (v: int*int) : figure =
    match figure with
    | Circle ((cx,cy), r, col) -> Circle ((cx + fst v, cy + snd v), r, col)
    | Rectangle ((x0,y0), (x1,y1), col) -> Rectangle ((x0 + fst v, y0 + snd v), (x1 + fst v, y1 + snd v), col)
    | Mix (f1,f2) -> Mix ((move f1 v), (move f2 v))

makePicture "moveTest" (move figTest (-20,20)) 100 150

///<summary> Funktionen checkFigure </summary>
///<param name="figure"> inputtet er en liste, som vi skal undersøge om det er en liste </param>
///<returns> Returner  </returns>
let rec boundingBox figure : (point*point) =
    match figure with 
    | Circle ((cx,cy), r, col) -> (cx - r, cy - r), (cx + r, cy + r)
    | Rectangle ((x0,y0), (x1,y1), col) -> (x0,y0), (x1,y1)
    | Mix (f1, f2) -> 
        let (a1,a2), (b1,b2) = boundingBox f1 
        let (c1,c2), (d1,d2) = boundingBox f2
        (min a1 c1, min a2 c2), (max b1 d1, max b2 d2)

printfn "%A" (boundingBox figTest)