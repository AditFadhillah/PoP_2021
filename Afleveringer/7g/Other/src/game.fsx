
printfn "Welcome to Rotate"
printfn "Your new favorite game"
printfn "Start by typing the size of the board, choose from 2 to 5 and press enter"

let gameBoard = rotate.create (uint(System.Console.ReadLine()))

printfn "%s" <| rotate.board2Str gameBoard

printfn "Choose difficulty 1 - infinity and press enter"

let scrambledBoard = rotate.scramble gameBoard (uint(System.Console.ReadLine()))

printfn "This is your scrambled Board" 
printfn "You can turn 2 x 2 squares to go back to the original board"
printfn "Choose which one with the keybord by counting from the top left corner"

type Board = char list 

let rec gamePlay (b: Board) : Board =   
    printfn "Current Board: choose which 2 x 2 square to turn clockwise %s" <| rotate.board2Str b
    match b with 
        | b when rotate.solved b -> b
        | _ -> gamePlay (rotate.rotate b (int(System.Console.ReadLine()))) 

gamePlay scrambledBoard 

printfn "Congrats - YOU WON"