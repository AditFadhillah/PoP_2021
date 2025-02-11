

type BoardDisplay (row_init:int , col_init:int)  = 
    let mutable BoardRow = row_init
    let mutable BoardCol = col_init
    let mutable BoardArray = Array2D.init (BoardRow*2+1) (BoardCol*2+1) (fun i j -> "  ")
    new () = BoardDisplay(0,0)
    member this.Set (row:int) (col:int) (cont:string) : unit = BoardArray.[row,col] <- cont
    member this.SetBottomWall (row:int) (col:int) : unit = BoardArray.[row*2,col*2-1] <- "--"
    member this.SetRightWall (row:int) (col:int) : unit = BoardArray.[row*2-1,col*2] <- "|"
    member this.Show with get() = 
        for i in 0 .. (BoardRow*2+1)-1 do
            for j in 0 .. (BoardCol*2+1)-1 do 
                    printf "%s" (BoardArray.[i,j])
            printfn ""
    

type Direction = North | South | East | West 
type Position = (int * int)
type Action =
    | Stop of Position
    | Continue of Direction * Position
    | Ignore


[<AbstractClass >] 
type BoardElement () =
    abstract member RenderOn : BoardDisplay -> unit
    abstract member Interact : Robot -> Direction -> Action 
    default __.Interact _ _ = Ignore
    abstract member GameOver : Robot list -> bool
    default __.GameOver _ = false


and Robot(row:int, col:int, name_init:string) = 
    inherit BoardElement()
    let mutable position = (row*2-1,col*2-1)
    let name = name_init
    override this.RenderOn (board:BoardDisplay) = board.Set (fst position) (snd position) name
    member this.Position with get() = position and set (coordinates) =  position <- coordinates

    override this.Interact (other:Robot) (dir:Direction) : Action = 
        let (x,y) = this.Position    // den vi er pa vej ind I    
        let (x1,y1) = other.Position // den robot vi rykker
        match dir with 
            | North when (x,y) = (x1-2,y1) -> Stop ((x1+1)/2,(y1+1)/2)
            | South when (x,y) = (x1+2,y1) -> Stop ((x1+1)/2,(y1+1)/2)
            | East  when (x,y) = (x1,y1+2) -> Stop ((x1+1)/2,(y1+1)/2)
            | West  when (x,y) = (x1,y1-2) -> Stop ((x1+1)/2,(y1+1)/2)
            | _ -> Ignore

    
    member val Name = name
    member this.Step (dir:Direction) = 
        match dir with 
            | dir when dir = North -> this.Position <- (fst position - 2,snd position)
            | dir when dir = South -> this.Position <- (fst position + 2,snd position)
            | dir when dir = West -> this.Position <- (fst position,snd position - 2) 
            | _ -> this.Position <- (fst position,snd position + 2)


and Goal (r:int, c:int) =
    inherit BoardElement()
    member this.GameOver (robo: Robot) : bool =
        robo.Position = (r*2-1,c*2-1)
    override this.RenderOn (board:BoardDisplay) = board.Set (r*2-1) (c*2-1) "GG"
    
and BoardFrame (r:int, c:int) =
    inherit BoardElement ()
    override this.RenderOn (array1:BoardDisplay) = 
        for j in 0 .. (r*2) do
            for i in 0 .. (c*2) do
                match i with 
                    | i when (i % 2 = 0) && (j = 0 || j = (r*2)) -> array1.Set j i "+"
                    | i when (i % 2 = 1) && (j = 0 || j = (r*2)) -> array1.Set j i "--"
                    | i when (i = 0 || i = c*2) && j % 2 = 0 -> array1.Set j i "+"
                    | i when (i = 0 || i = c*2) && j % 2 = 1 -> array1.Set j i "|"
                    | i when i % 2 = 1 && j % 2 = 1 -> array1.Set j i "  "
                    | i when i % 2 = 1 && j % 2 = 0 -> array1.Set j i "  "
                    | i when i % 2 = 0 && j % 2 = 0 -> array1.Set j i "+"
                    | _-> array1.Set j i " " //  | i when i % 2 = 0 && j % 2 = 0 -> array1.[j,i] <-  "+"  
    
    override this.Interact (other:Robot) (dir:Direction) : Action =   // den vi er pa vej ind I    
        let (x,y) = other.Position // den robot vi rykker
        match other.Position with 
            | (x,_) when dir = North && x = 1 -> Stop ((x+1)/2,(y+1)/2)
            | (x,_) when dir = South && x = r*2-1 -> Stop ((x+1)/2,(y+1)/2)
            | (_,y) when dir = East  && y = c*2-1 -> Stop ((x+1)/2,(y+1)/2)
            | (_,y) when dir = West  && y = 1 -> Stop ((x+1)/2,(y+1)/2)
            | _ -> Ignore


and VerticalWall (r:int, c:int, n:int) =
    inherit BoardElement ()           
    override this.RenderOn (board:BoardDisplay) = 
        if n < 0 then
            for i in 0 .. (n * -1)-1 do
                board.SetRightWall (r-i) c
        else 
            for i in 0 .. n-1 do
                board.SetRightWall (r+i) c
    override this.Interact (other:Robot) (dir:Direction) : Action =        
        let mutable s = Ignore
        let (x,y) = other.Position
        
        if n < 0 then
          for i in 0 .. (n * -1)-1 do 
            match dir with 
                | East when (x,y) = ((r*2-1)-i*2,c*2-1) -> s <- Stop ((x+1)/2,(y+1)/2)
                | West when (x,y-2) = ((r*2-1)-i*2,c*2-1) -> s <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()
        else 
          for i in 0 .. n-1 do 
            match dir with 
                | East when (x,y) = ((r*2-1)+i*2,c*2-1) -> s <- Stop ((x+1)/2,(y+1)/2)
                | West when (x,y-2) = ((r*2-1)+i*2,c*2-1) -> s <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()
        s


and HorizontalWall (r:int, c:int, n:int) =
    inherit BoardElement ()           
    override this.RenderOn (board:BoardDisplay) = 
        if n < 0 then
            for i in 0 .. (n * -1)-1 do
                board.SetBottomWall r (c-i) 
        else 
            for i in 0 .. n-1 do
                board.SetBottomWall r (c+i) 
    override this.Interact (other:Robot) (dir:Direction) : Action =        
        let mutable s = Ignore
        let (x,y) = other.Position
        if n < 0 then
            for i in 0 .. (n*(-1))-1 do 
              match dir with 
                | North when (x-2,y) = ((r*2-1),(c*2-1)-i*2) -> s <- Stop ((x+1)/2,(y+1)/2)
                | South when (x,y) = (r*2-1,(c*2-1)-i*2) -> s <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()

        else
          for i in 0 .. n-1 do 
            match dir with 
                | North when (x-2,y) = ((r*2-1),(c*2-1)+i*2) -> s <- Stop ((x+1)/2,(y+1)/2)
                | South when (x,y) = (r*2-1,(c*2-1)+i*2) -> s <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()
        s


type Board (r:int, c:int) = 
    let frame = BoardFrame(r,c)
    let mutable elements : BoardElement list = [frame]
    let mutable robots : BoardElement list = []
    member this.Elements with get() = elements and set(a) = elements <- a
    member this.Robots with get() = robots and set(a) = robots <- a
    new () = Board (0,0)
    member this.AddRobot (robot:BoardElement) : unit = 
        elements <- elements @ [robot]  
        robots <- robot :: robots 
    member this.AddElement (element:BoardElement) : unit = 
        elements <- elements @ [element]  
    member this.Move (robot:Robot) (dir:Direction) : unit = 
        let mutable a = true
        for i in 0 .. elements.Length-1 do
                if elements.[i].Interact(robot) (dir) <> Ignore then 
                    a <- false
        if a then 
            robot.Step dir
            this.Move(robot) (dir)
     
    member this.RenderOn (board:BoardDisplay) : unit = 
        for i in 0 .. elements.Length-1 do
            elements.[i].RenderOn(board)



type Game() = 
    //new : Board -> Game
    member this.Play() : int =
        let mutable counter = 1
        System.Console.Clear()
        printfn "Welcome to Ricochet Robots"
        let mutable (r,c) = (10,10)
        printfn "Your board has measurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        let PARADIZE = Goal(5,5)

        let AA = Robot (1,5,"AA")
        let BB = Robot (10,5,"BB")
        let CC = Robot (2,1,"CC")

        let VWall1 = VerticalWall (2,5,2)
        let VWall2 = VerticalWall (3,2,1)
        let HWall1 = HorizontalWall (3,2,3)
        let HWall2 = HorizontalWall (4,2,-2)

        boardElem.AddRobot AA
        boardElem.AddRobot BB
        boardElem.AddRobot CC
        boardElem.AddElement VWall1
        boardElem.AddElement VWall2
        boardElem.AddElement HWall1
        boardElem.AddElement HWall2
        boardElem.AddElement PARADIZE


        printfn "This is your board, you have to make it so that one of the robots lands on the goal 'GG'. Hint: the robot has to stop at the goal."
        boardElem.RenderOn boardCanvas
        boardCanvas.Show
        
        
        let mutable winning = false
        let rec gamePlay (robo:Robot) = 
            if PARADIZE.GameOver(robo) then 
                printfn "YOU WON"
                winning <- true
            else 
              printfn "Choose direction(s) and press enter to confirm your move and choose a new robot."  

              match (System.Console.ReadKey(true)).Key with 
                | System.ConsoleKey.Enter -> 
                    counter <- counter + 1
                    ()
                | System.ConsoleKey.UpArrow -> 
                    boardElem.Move robo North
                    boardElem.RenderOn boardCanvas
                    System.Console.Clear()
                    boardCanvas.Show
                    gamePlay robo
                    ()
                | System.ConsoleKey.DownArrow -> 
                    boardElem.Move robo South
                    boardElem.RenderOn boardCanvas
                    System.Console.Clear()
                    boardCanvas.Show
                    gamePlay robo
                    ()
                | System.ConsoleKey.LeftArrow -> 
                    boardElem.Move robo West
                    boardElem.RenderOn boardCanvas
                    System.Console.Clear()
                    boardCanvas.Show
                    gamePlay robo
                    ()
                | System.ConsoleKey.RightArrow -> 
                    boardElem.Move robo East
                    boardElem.RenderOn boardCanvas
                    System.Console.Clear()
                    boardCanvas.Show
                    gamePlay robo
                    ()
                | _ -> gamePlay (robo)
        

        let rec play () = 
            if not winning then
              printfn "Choose a robot. Hint: to choose a robot press 'a', 'b' or 'c'." 
              match (System.Console.ReadKey(true)).Key with 
                 
                | System.ConsoleKey.A -> 
                    gamePlay (AA)
                    play()
                | System.ConsoleKey.B -> 
                    gamePlay (BB)
                    play()
                | System.ConsoleKey.C -> 
                    gamePlay (CC)
                    play()
                | _ -> 
                    play()

        play()
        

        printfn "Your score: %A" counter
        counter

let spil = Game() 

spil.Play()

