module continuedFraction

let rec cfrac2float (lst: int list): float =
    match lst with 
        | [] -> 0.0        
        | lst when List.length lst = 1 -> float(lst.[0])
        | x::xs -> float(x) + (1.0/(float(cfrac2float xs)))


let rec float2cfrac (x: float): int list =
    let qi = floor(x)
    let ri = x - float(qi)
    let xii = (1.0/ri)
    if x = 0.0 then
        []
    elif abs ri < 1e-6 then
        [int(qi)]
    else
        int(qi) :: (float2cfrac xii)
