
(*
let fac (n:int) : int =
    match n with
    | 0 | 1 -> 1
    | _ -> n * fac (n-1)

let fac (n:int) : int =


let fac (n:int) : int =
    let rec loop i acc =
        match i with
        | 0 | 1 -> acc
        | _ -> loop (i-1) (acc * i)
    loop n 1
*)

(*
let fac (n:int) : int = 
    if n < 1 then
        raise (invalidArg ("n is required to be a positive value"))
    else
        [1..n] |> List.fold (*) 1

*)

(*
exception MyExnArg of int 

let fac (n:int) : int = 
    if n < 1 then
        raise (System.ArgumentException (sprintf "The value is too low:  %A" n))
    else
        (List.fold (*) 1) [1..n]
*)

let rec fac (n:int) : int =
    match n with
     | n when n < 1 -> invalidArg "n" (sprintf "The value is too low:  %A" n)
     | 0 | 1 -> 1
     | n -> n * fac (n-1)

printfn "%A" <|fac 3
printfn "%A" <|fac 0
printfn "%A" <|fac -1

