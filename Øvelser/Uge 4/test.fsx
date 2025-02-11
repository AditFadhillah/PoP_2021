let len (v1 : float*float) : float =
    let (x1,y1) = v1
    sqrt(x1**2.0+y1**2.0)



let ang (v1 : float*float) : float =
    let (x1,y1) = v1
    (atan2 y1 x1)



let add (v1 : float*float) (v2 : float*float) : float*float =
    let (x1,y1) = v1
    let (x2,y2) = v2
    ((x1+x2),(y1+y2))
(*
let w = (1.3,1.2)

printfn "%A"(ang (-5.0,-5.0))
*)
(*
let cirka(a : float) (b : float) : float =
    if  a + 0.00001 > a > b - 0.00001 > b
*)


printfn "Blackbox testing of len v"
printfn "%5b: v = (x,y), x > 0, y > 0" (len (6.0,8.0) = 10.0 )
printfn "%5b: v = (x,y), x < 0, y < 0" (len (-6.0,-8.0) = 10.0 )
printfn "%5b: v = (x,y), x > 0, y < 0" (len (6.0,-8.0) = 10.0 )
printfn "%5b: v = (x,y), x = 0, y = 0" (len (0.0,0.0) = 0.0 )

printfn "Blackbox testing of ang v"
printfn "%5b: v = (x,y), x > 0, y > 0" (ang (4.0,4.0) = System.Math.PI/4.0)
printfn "%5b: v = (x,y), x < 0, y = 0" (ang (-4.0,0.0) = (System.Math.PI))
printfn "%5b: v = (x,y), x > 0, y < 0" (ang (4.0,-4.0) = -(System.Math.PI/4.0))
printfn "%5b: v = (x,y), x = 0, y = 0" (ang (0.0,0.0) = 0.0)

printfn "Blackbox testing of add v1 v2"
printfn "%5b: v = (x1,y1), x1 > 0, y1 > 0, v2 = (x2,y2), x2 > 0, y2 > 0"(add (6.0,8.0) (8.0,6.0) = (14.0,14.0) )
printfn "%5b: v = (x1,y1), x1 < 0, y1 < 0, v2 = (x2,y2), x2 < 0, y2 < 0"(add (-6.0,-8.0) (-8.0,-6.0) = (-14.0,-14.0) )
printfn "%5b: v = (x1,y1), x1 < 0, y1 > 0, v2 = (x2,y2), x2 > 0, y2 < 0"(add (-6.0,8.0) (8.0,-6.0) = (2.0,2.0) )
printfn "%5b: v = (x1,y1), x1 > 0, y1 < 0, v2 = (x2,y2), x2 < 0, y2 > 0"(add (6.0,-8.0) (-8.0,6.0) = (-2.0,-2.0) )
printfn "%5b: v = (x1,y1), x1 = 0, y1 = 0, v2 = (x2,y2), x2 = 0, y2 = 0"(add (0.0,0.0) (0.0,0.0) = (0.0,0.0) )


printfn "%A"(ang (4.0,4.0))
printfn "%A"(ang (-4.0,4.0))
printfn "%A"(ang (4.0,-4.0))
printfn "%A"(ang (0.0,0.0))