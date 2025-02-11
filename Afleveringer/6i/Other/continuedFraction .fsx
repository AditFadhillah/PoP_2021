//module continuedFrac =

let rec cfrac2float (lst: int list): float =
    match lst with 
       | [] -> 0.0
       | x::xs -> float(x) + (1.0/(float(cfrac2float xs)))
 
printfn "%.3f" <| cfrac2float [3;4;12;4]

let rec float2cfrac (x: float): int list =
    let qi = int(floor(x))
    let ri = float(x - float(qi))
    if abs ri < 1e-10 then
       []
    else
       qi :: (float2cfrac (1.0/ri))
 
printfn "%A" <| float2cfrac 3.245
printfn "%.3f" <| cfrac2float (float2cfrac 3.245)
