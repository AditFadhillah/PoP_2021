
type Board = char list

let create (n: uint32) : Board =
    match n with
     | _ -> ['a'..'y'].[0..int n]

printfn "%A" <| create 6u


let board2Str (b: Board) : string =
    let n = int(sqrt(float b.Length))
    let rec helper (b:Board) : string =
        match b with
         | [] -> "\n"
         | b when b.Length % n = 0 -> "\n" + sprintf "%c" b.[0] + helper b.Tail
         | x::xs -> sprintf "%c" x + helper xs
    helper b

printfn "%s" <| board2Str (create 1u)
printfn "%s" <| board2Str (create 2u)
printfn "%s" <| board2Str (create 3u)
printfn "%s" <| board2Str (create 4u)
printfn "%s" <| board2Str (create 5u)



let validRotation (b: Board) (p:Position) : bool =
    match p with 
     |  

(*

let rotate (b:Board) p:Position : Board


let scramble (b:Board) (m:uint) : Board


let solved (b:Board) : bool
*)