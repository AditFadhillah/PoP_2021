
type Board = char list 
type Position = int

let create (n : uint32) : Board = 
    match n with 
     | n when n < 2u -> ['a'..'d']
     //| 2u -> ['a'..'d']       // Sådan her gjorde vi i starten indtil vi fandt en smartere måde.
     //| 3u -> ['a'..'i']
     //| 4u -> ['a'..'p']
     //| 5u -> ['a'..'y']
     | _ -> ['a'..'y'].[..(int n * int n)-1]


let board2Str (b:Board) : string = 
    let n = int(sqrt(float b.Length))
    let rec helper (b: Board) : string =
        match b with 
            | [] -> "\n"
            | x::xs when b.Length % n = 0  -> "\n" + sprintf "%c " x + helper xs
            | x::xs -> sprintf "%c " x + helper xs                
    helper b


let validRotation (b:Board) (p:Position) : bool = 
    let n = int(sqrt(float b.Length))
    match p with 
        | p when p > b.Length-n-1  -> false
        | p when p = (n-1) -> false 
        | p when p = (2 * n)-1 -> false 
        | p when p = (3 * n)-1 -> false 
        | p when p = (4 * n)-1 -> false 
        | _ -> true


let rec rotate (b:Board) (o:Position) : Board = 
    let n = (int(sqrt(float b.Length)))
    let p = o - 1
    if not (validRotation b p) then b
    else List.map (fun x -> if x = b.[p] then b.[p+n] 
                             elif x = b.[p+1] then b.[p] 
                             elif x = b.[p+n] then b.[p+n+1] 
                             elif x = b.[p+n+1] then b.[p+1] 
                             else x) b


let rnd = System.Random () 
let rec scramble (b:Board) (m:uint) : Board = 
    let x = rnd.Next (b.Length-1)
    match b with 
        | b when m = 0u -> b
        | b when not (validRotation b (x)) -> scramble b m 
        | _ -> scramble (rotate b (x+1)) (m-1u)



let solved (b:Board) : bool = 
    let n = (uint(sqrt(float b.Length)))
    match b with 
        | b when b = create n -> true 
        | _ -> false
















printfn "Welcome to Rotate"
printfn "Your new favorite game"
printfn "Start by typing the size of the board, choose from 2 to 5 and press enter"

let gameBoard = create (uint(System.Console.ReadLine()))

printfn "%s" <| board2Str gameBoard

printfn "Choose difficulty 1 - infinity and press enter"

let scrambledBoard = scramble gameBoard (uint(System.Console.ReadLine()))

printfn "This is your scrambled Board" 
printfn "You can turn 2 x 2 squares to go back to the original board%s"
printfn "Choose which one with the keybord by counting from the top left corner"

let rec gamePlay (b: Board) : Board =   
    printfn "Current Board: choose which 2 x 2 square to turn clockwise %s" <| board2Str b
    match b with 
        | b when solved b -> b
        | _ -> gamePlay (rotate b (int(System.Console.ReadLine()))) 

gamePlay scrambledBoard 

printfn "Congrats - YOU WON"