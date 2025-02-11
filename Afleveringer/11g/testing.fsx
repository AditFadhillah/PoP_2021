type BoardDisplay (row_init:int , col_init:int)  = 
    let mutable BoardRow = row_init
    let mutable BoardCol = col_init
    let mutable BoardArray = 
        let topBottom = Array.append [| for i in 1 .. BoardRow -> "+--" |] [|"+"|]
        let pipes = Array.concat [ [|"|"|] ; [| for i in 1 .. BoardRow -> "  " |] ; [|"|"|] ]
        let plusses = Array.append [| for i in 1 .. BoardRow -> "+  " |] [|"+"|]
        for c = 1 to BoardCol do    
            Array.concat [topBottom;pipes;plusses;pipes;topBottom]
    member this.print with get() = 
        for i in 0 .. BoardArray.Length - 1 do
            printf "%s" (Array.get BoardArray i)
    new () = 
        
        BoardDisplay(0,0)

let testBoard = BoardDisplay (10, 10)

printfn "%A" <| testBoard.print