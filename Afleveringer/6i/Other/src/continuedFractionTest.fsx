open continuedFraction


printfn ""
printfn "Blackbox testing of cfrac2float"
printfn "%b: cfrac2float [3;4;12;4]" <| (cfrac2float [3;4;12;4] = 3.245)
printfn "%b: cfrac2float [-3;4;12;4]" <| (cfrac2float [-3;4;12;4] = -2.755)
printfn "%b: cfrac2float [1;2]" <| (cfrac2float [1;2] = 1.5)
printfn "%b: cfrac2float [1]" <| (cfrac2float [1] = 1.0)
printfn "%b: cfrac2float []" <| (cfrac2float [] = 0.0)

printfn ""
printfn "Blackbox testing of cfrac2float (float2cfrac )"
printfn "%b: cfrac2float (float2cfrac 3.245)" <| (cfrac2float (float2cfrac 3.245) = 3.245)
printfn "%b: cfrac2float (float2cfrac -2.755)" <| (cfrac2float (float2cfrac -2.755) = -2.755)
printfn "%b: cfrac2float (float2cfrac 0.0)" <| (cfrac2float (float2cfrac 0.0) = 0.0)

printfn ""
printfn "Blackbox testing of float2cfrac"
printfn "%b: float2cfrac 3.245" <| (float2cfrac 3.245 = [3;4;12;3;1])
printfn "%b: float2cfrac -3.245" <| (float2cfrac -3.245 = [-4; 1; 3; 12; 3; 1])
printfn "%b: float2cfrac 2.0" <| (float2cfrac 2.0 = [2])
printfn "%b: float2cfrac 0.1" <| (float2cfrac 0.1 = [0;10])
printfn "%b: float2cfrac 0.0" <| (float2cfrac 0.0 = [])

printfn ""
printfn "Blackbox testing of float2cfrac (cfrac2float )"
printfn "%b: float2cfrac (cfrac2float [3;4;12;3;1])" <| (float2cfrac (cfrac2float [3;4;12;3;1]) = [3;4;12;3;1])
printfn "%b: float2cfrac (cfrac2float [-4; 1; 3; 12; 3; 1])" <| (float2cfrac (cfrac2float [-4; 1; 3; 12; 3; 1]) = [-4; 1; 3; 12; 3; 1])
printfn "%b: float2cfrac (cfrac2float [])" <| (float2cfrac (cfrac2float []) = [])

printfn ""
printfn "Whitebox testing of cfrac2float"
printfn "%b: cfrac2float branch 1a" <| (cfrac2float [] = 0.0)
printfn "%b: cfrac2float branch 2a" <| (cfrac2float [1] = 1.0)
printfn "%b: cfrac2float branch 2a" <| (cfrac2float [2] = 2.0)
printfn "%b: cfrac2float branch 3a" <| (cfrac2float [3; 7; 16; 1; 3; 4; 2; 4] = 3.14165)
printfn "%b: cfrac2float branch 3a" <| (cfrac2float [-3;4;12;4] = -2.755)

printfn ""
printfn "Whitebox testing of float2cfrac"
printfn "%b: float2cfrac branch 1a" <| (float2cfrac 0.0 = [])
printfn "%b: float2cfrac branch 2a" <| (float2cfrac 1.0 = [1]) 
printfn "%b: float2cfrac branch 2a" <| (float2cfrac 2.0 = [2]) 
printfn "%b: float2cfrac branch 3a" <| (float2cfrac 3.14165 = [3; 7; 16; 1; 3; 4; 2; 4])
printfn "%b: float2cfrac branch 3a" <| (float2cfrac -2.755 = [-3;4;12;3;1])


