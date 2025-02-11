
exception MyError
exception MyArgExn of int

let e1 : exn = MyError
let e2 : exn = MyArgExn 5

let isMyError = e1 = e2

let isMyArgExn =
    match e2 with 
        | MyArgExn _ -> "yes"
        | _ -> "no"

printfn "%A" <| isMyArgExn


//----------------------------------------------------------------------


let mydiv a b : int option =
    try Some (a / b) with
        :? System.DivideByZeroException -> None

// val failwith : string -> 'a

// val invalidArg : string -> string -> 'a

let toFahrenheit c =
    if c < -273.15 then invalidArg "c" "below absolute zero"
    else 9.0/5.0*float(c)+32.0

printfn "%A" <| toFahrenheit 4.3


//----------------------------------------------------------------------

let (>>=) x y = Option.bind y x
mydiv 8 3 >>= (fun x -> Some(float(x)+1.0));;

//----------------------------------------------------------------------

type 'a result = Ok of 'a | Error of string
// val (>>=) : 'a result -> ('a -> 'b result) -> 'b result

let mydiv a b : int result =
    try Ok (a / b) with
        :? System.DivideByZeroException -> Error "div"

let (>>=) a f =
    match a with 
        | Ok v -> f v
        | Error s -> Error s

do printfn "%A" (mydiv 8 3 >>= (fun x -> Ok(float(x)+1.0)))

//----------------------------------------------------------------------

