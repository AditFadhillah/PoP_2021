
exception ArgumentTooBig of string
exception ArgumentTooSmall of string

let rec fac1 (n:int) : int =
    match n with
     | 0 | 1 -> 1
     | n when n < 0 -> raise (ArgumentTooSmall (sprintf "The value is too low:  %A" n))
     | n when n > 7 -> raise (ArgumentTooBig (sprintf "The value is too big:  %A" n))
     | _ -> n * fac1 (n-1)

(*
let tryPrint (n:int) =
    try printfn "%A" <| fac n
    with
        | :? System.ArgumentException as ex -> printfn "Exception caught with message: %s" ex.Message
        | :? System.DivideByZeroException as ex -> printfn "failed with %s" ex.Message 

printfn "%A" <|tryPrint 3
printfn "%A" <|tryPrint 0
printfn "%A" <|tryPrint -1
*)

(*
let rec fac2 (n:int) : int =
    try
        match n with
            | 0 | 1 -> 1
            | n when n < 0 -> raise (System.ArgumentException (sprintf "The value is too low:  %A" n))
            | n -> n * fac2 (n-1)
    with 
        | :? System.ArgumentException as ex -> printfn "Exception caught with message: %s" ex.Message
        | :? System.DivideByZeroException as ex -> printfn "failed with %s" ex.Message 
*)

(*
try printfn "%A" (fac1 8)
with
    | :? System.ArgumentException as ex -> printfn "Exception caught with message: %s" ex.Message
    | ArgumentTooBig ex -> printfn "Exception caught with message: %s" ex
*)
//9g0
try printfn "%A" (fac1 -4) with | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex
try printfn "%A" (fac1 0) with | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex
try printfn "%A" (fac1 1) with | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex
try printfn "%A" (fac1 4) with | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex


//9g1
try printfn "%A" (fac1 -1)
with
    | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex
    | ArgumentTooBig ex -> printfn "Exception caught with message: %s" ex

try printfn "%A" (fac1 9)
with
    | ArgumentTooSmall ex -> printfn "Exception caught with message: %s" ex
    | ArgumentTooBig ex -> printfn "Exception caught with message: %s" ex

//9g2
let rec facFailWith (n:int) : int =
    match n with
     | 0 | 1 -> 1
     | n when n < 0 -> raise (failwith (sprintf "argument must be greater than 0:  %A" n))
     | n when n > 3 -> raise (failwith (sprintf "calculation would result in an overflow:  %A" n))
     | _ -> n * facFailWith (n-1)

try printfn "%A" (facFailWith -4) with | failwith as ex -> printfn "Exception caught with message: %s" ex.Message
try printfn "%A" (facFailWith 0) with | failwith as ex -> printfn "Exception caught with message: %s" ex.Message
try printfn "%A" (facFailWith 1) with | failwith as ex -> printfn "Exception caught with message: %s" ex.Message
try printfn "%A" (facFailWith 4) with | failwith as ex -> printfn "Exception caught with message: %s" ex.Message

//9g3
let facOption (n:int) : int option =
    match n with
     | n when n < 0 -> None
     | n when n > 3 -> None
     | _ -> Some n

printfn "%A" (facOption -4)
printfn "%A" (facOption 0)
printfn "%A" (facOption 1)
printfn "%A" (facOption 4)
