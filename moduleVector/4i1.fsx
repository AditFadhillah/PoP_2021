open vec2d

printfn "Blackbox testing of len v"
printfn "%5b: v = (x,y), x > 0, y > 0" (len (6.0,8.0) = 10.0 )
printfn "%5b: v = (x,y), x < 0, y < 0" (len (-6.0,-8.0) = 10.0 )
printfn "%5b: v = (x,y), x > 0, y < 0" (len (6.0,-8.0) = 10.0 )
printfn "%5b: v = (x,y), x = 0, y = 0" (len (0.0,0.0) = 0.0 )

printfn "Blackbox testing of ang v"
printfn "%5b: v = (x,y), x > 0, y > 0" (ang (4.0,4.0) - 0.7853 <= 0.0001 )
printfn "%5b: v = (x,y), x < 0, y < 0" (ang (-4.0,-4.0) - (-2.3561) <= 0.0001 )
printfn "%5b: v = (x,y), x > 0, y < 0" (ang (4.0,-4.0) - 2.3561 <= 0.0001 ) // angiver at det kun regnes efter de 4 første cifre
printfn "%5b: v = (x,y), x = 0, y > 0" (ang (0.0,4.0)  - 1.5707 <= 0.0001 ) // x kan godt være 0, men y må ikke være 0

printfn "Blackbox testing of add v1 v2"
printfn "%5b: v = (x1,y1), x1 > 0, y1 > 0, v2 = (x2,y2), x2 > 0, y2 > 0"(add (6.0,8.0) (8.0,6.0) = (14.0,14.0) )
printfn "%5b: v = (x1,y1), x1 < 0, y1 < 0, v2 = (x2,y2), x2 < 0, y2 < 0"(add (-6.0,-8.0) (-8.0,-6.0) = (-14.0,-14.0) )
printfn "%5b: v = (x1,y1), x1 < 0, y1 > 0, v2 = (x2,y2), x2 > 0, y2 < 0"(add (-6.0,8.0) (8.0,-6.0) = (2.0,2.0) )
printfn "%5b: v = (x1,y1), x1 > 0, y1 < 0, v2 = (x2,y2), x2 < 0, y2 > 0"(add (6.0,-8.0) (-8.0,6.0) = (-2.0,-2.0) )
printfn "%5b: v = (x1,y1), x1 = 0, y1 = 0, v2 = (x2,y2), x2 = 0, y2 = 0"(add (0.0,0.0) (0.0,0.0) = (0.0,0.0) )