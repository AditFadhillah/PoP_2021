(*
let rec fac(n: uint32): uint32 =
    if n <= 1u then 
        1u
    else 
        n * fac (n-1u)

printfn "fac"
printfn "%A" (fac 5u)

let rec pow (n: int): int =
    match n with
    | x when (x > 1) -> x * pow (n-1)
    | x when x = 1 -> 2
    | x when x = 0 ->  1

printfn ""
printfn "pow"
printfn "%A" (pow -1)
printfn "%A" (pow 0)
printfn "%A" (pow 5)

let rec powN (N: int): int =
    if N < 0 then
        1
    else 
        N * powN (N-1)

printfn ""
printfn "powN"
printfn "%A" (powN -1)
printfn "%A" (powN 0)
printfn "%A" (powN 5)

let rec sumRec (n: uint32): uint32 =
    if n <= 1u then
        1u
    else 
        n + sumRec (n-1u)

printfn ""
printfn "sumRec"
printfn "%A" (sumRec 1u)
printfn "%A" (sumRec 0u)
printfn "%A" (sumRec 5u)

let rec sumPat (lst: int list): int = 
    match lst with
    | [] -> 0
    | head :: tail -> head + sumPat tail

printfn ""
printfn "sumPat"
printfn "%A" (sumPat [-1;0;1])
printfn "%A" (sumPat [2;4;6])
printfn "%A" (sumPat [1;3;1])

let rec lenPat (lst: 'a list): int =
    match lst with
    | [ ] -> 0
    | [ _ ] -> 1
    | _ :: tail -> 1 + lenPat tail

printfn ""
printfn "lenPat"
printfn "%A" (lenPat [])
printfn "%A" (lenPat [0])
printfn "%A" (lenPat [1;3;1])

let rec lengthAcc (acc: int)  (xs: 'a list): int =
    match xs with
    | [] -> acc
    | x::ys -> lengthAcc (acc+1) ys

printfn ""
printfn "lengthAcc"
printfn "%A" (lengthAcc 5 [1;2;3;4;5])
printfn "%A" (lengthAcc 10 [])
printfn "%A" (lengthAcc 0 [1;3;1])
*)

let rec float2cfrac2 (x: float) : int list =
  let qi = floor(System.Math.Round(x,6)) // Round up the number
  let ri = x - qi
  match ri with
  | y when y < 1e-6 -> [int qi]
  | _ -> (int qi) :: (float2cfrac2 (1.0/ri))

let rec float2cfrac1 (x: float): int list =
    if x = 0.0 then
        []
    elif abs (float(x - float(int(floor(x))))) < 1e-6 then
        [int(floor(x))]
    else
        int(floor(x)) :: (float2cfrac1 (1.0/float(x - float(int(floor(x))))))

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


printfn "%A" (float2cfrac2 3.245)
printfn "%A" (float2cfrac1 3.245)
printfn "%A" (float2cfrac 3.245)