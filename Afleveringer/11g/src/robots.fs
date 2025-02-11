module robots

/// <summary> The Class BoardDisplay is used to show a board with given elements on it  </summary>
/// <param name="row_init"> The length of a row represented as an integer </param>
/// <param name="col_init"> the length of a collum represented as an integer </param>
/// <return> Does not return anything </return> 
type BoardDisplay (row_init:int , col_init:int)  = 
    let mutable BoardRow = row_init
    let mutable BoardCol = col_init
    let mutable BoardArray = Array2D.init (BoardRow*2+1) (BoardCol*2+1) (fun i j -> "  ")
    new () = BoardDisplay(0,0)
    member this.Messurements with get() = (BoardRow,BoardCol)
/// <summary> The function Set puts a given string in the BoardArray </summary>
/// <param name="row"> the row on a board represented as an integer </param>
/// <param name="col"> the row on a board represented as an integer </param>
/// <param name="cont"> a string </param>
/// <return> returns a unit </return> 
    member this.Set (row:int) (col:int) (cont:string) : unit = BoardArray.[row,col] <- cont
/// <summary> The function SetBottomWall puts a bottom wall (--) in the board array </summary>
/// <param name="row"> the row on a board represented as an integer </param>
/// <param name="col"> the row on a board represented as an integer </param>
/// <return> returns a unit </return>
    member this.SetBottomWall (row:int) (col:int) : unit = BoardArray.[row*2,col*2-1] <- "--"
/// <summary> The function SetBottomWall puts a right wall (|) in the board array </summary>
/// <param name="row"> the row on a board represented as an integer </param>
/// <param name="col"> the row on a board represented as an integer </param>
/// <return> returns a unit </return>
    member this.SetRightWall (row:int) (col:int) : unit = BoardArray.[row*2-1,col*2] <- "|"
/// <summary> The function Show i used printing a board </summary>
/// <return> returns a unit </return>
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
/// <summary> BoardElement is used to keep track of elemnts on the board </summary>
/// <return> returns a unit </return>
type BoardElement () =
/// <summary> RenderOn render an element on a board </summary>
/// <return> returns a unit </return>
    abstract member RenderOn : BoardDisplay -> unit
/// <summary> Interact is used to deside what action to take when a robot is moved </summary>
/// <return> returns an Action </return>
    abstract member Interact : Robot -> Direction -> Action 
    default __.Interact _ _ = Ignore
/// <summary> Interact is used to decide if the game is over </summary>
/// <return> returns a boolean </return>
    abstract member GameOver : Robot list -> bool
    default __.GameOver _ = false

/// <summary> The Class Robot is used to move a robot on the board </summary>
/// <param name="row"> The length of a row represented as an integer </param>
/// <param name="col"> the length of a collum represented as an integer </param>
/// <param name="name_init"> the name of a robot </param>
/// <return> Does not return anything </return> 
and Robot(row:int, col:int, name_init:string) = 
    inherit BoardElement()
    let mutable position = (row*2-1,col*2-1)
    let name = name_init
/// <summary> Renderon is used to render the robot on the board </summary>
/// <param name="board"> a BoardDisplay </param>
/// <return> Does not return anything </return>
    override this.RenderOn (board:BoardDisplay) = board.Set (fst position) (snd position) name
    member this.Position with get() = position and set (coordinates) =  position <- coordinates
/// <summary> Used to make the robot stop when moved into another robot </summary>
/// <param name="other"> A Robot </param>
/// <param name="dir"> A Direction </param>
/// <return> Does not return anything </return>
    override this.Interact (other:Robot) (dir:Direction) : Action = 
        let (x,y) = this.Position    // den vi er pa vej ind I    
        let (x1,y1) = other.Position // den robot vi rykker
        match dir with 
            | North when (x,y) = (x1-2,y1) -> Stop ((x1+1)/2,(y1+1)/2)
            | South when (x,y) = (x1+2,y1) -> Stop ((x1+1)/2,(y1+1)/2)
            | East  when (x,y) = (x1,y1+2) -> Stop ((x1+1)/2,(y1+1)/2)
            | West  when (x,y) = (x1,y1-2) -> Stop ((x1+1)/2,(y1+1)/2)
            | _ -> Ignore
/// <summary> is used to make the robot step in a given direction </summary>
/// <param name="dir"> A Direction </param>
/// <return> Does not return anything </return>
    member this.Step (dir:Direction) = 
        match dir with 
            | dir when dir = North -> this.Position <- (fst position - 2,snd position)
            | dir when dir = South -> this.Position <- (fst position + 2,snd position)
            | dir when dir = West -> this.Position <- (fst position,snd position - 2) 
            | _ -> this.Position <- (fst position,snd position + 2)
/// <summary> The Class goal is used to set a goal and deside weather a robot has landed on it </summary>
/// <param name="r"> The bords row </param>
/// <param name="c"> The bords colum </param>
/// <return> Does not return anything </return>
and Goal (r:int, c:int) =
    inherit BoardElement()
/// <summary> gameover is used to decide if the game is over </summary>
/// <param name="robo"> A Robot </param>
/// <return> does not return anything </return>
    member this.GameOver (robo: Robot) : bool =
        robo.Position = (r*2-1,c*2-1)
/// <summary> is used to place a goal on the board </summary>
/// <param name="board"> A BoardDisplay </param>
/// <return> Does not return anything </return>
    override this.RenderOn (board:BoardDisplay) = board.Set (r*2-1) (c*2-1) "GG"
/// <summary> The class BoardFrame is used to create the arrays for the board frame </summary>
/// <param name="r"> The row in on the board </param>
/// <param name="c"> the colums on the board </param>
/// <return> Does not return anything </return> 
and BoardFrame (r:int, c:int) =
    inherit BoardElement ()
/// <summary> RenderOn is used to render a boardframe on a board </summary>
/// <param name="array1"> a BoardDisplay </param>
/// <return> Does not return anything </return>
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
                    | _-> array1.Set j i " "  
    
/// <summary> Used to tell that the robot should stop when moved into the frame </summary>
/// <param name="other"> A Robot </param>
/// <param name="dir"> A Direction </param>
/// <return> Does not return anything </return>
    override this.Interact (other:Robot) (dir:Direction) : Action =      
        let (x,y) = other.Position // den robot vi rykker
        match other.Position with 
            | (x,_) when dir = North && x = 1 -> Stop ((x+1)/2,(y+1)/2)
            | (x,_) when dir = South && x = r*2-1 -> Stop ((x+1)/2,(y+1)/2)
            | (_,y) when dir = East  && y = c*2-1 -> Stop ((x+1)/2,(y+1)/2)
            | (_,y) when dir = West  && y = 1 -> Stop ((x+1)/2,(y+1)/2)
            | _ -> Ignore


/// <summary> The class VerticalWall is used to decide where to place a vall on the board </summary>
/// <param name="r"> The row in on the board </param>
/// <param name="c"> the colums on the board </param>
/// <param name="n"> The length of a wall </param>
/// <return> Does not return anything </return>
and VerticalWall (r:int, c:int, n:int) =
    inherit BoardElement ()  
/// <summary> RenderOn is used to render a wall on a board </summary>
/// <param name="board"> a BoardDisplay </param>
/// <return> Does not return anything </return>         
    override this.RenderOn (board:BoardDisplay) = 
        if n < 0 then
            for i in 0 .. (n * -1)-1 do
                board.SetRightWall (r-i) c
        else 
            for i in 0 .. n-1 do
                board.SetRightWall (r+i) c
/// <summary> Used to tell that the robot should stop when moved into a vertical wall </summary>
/// <param name="other"> A Robot </param>
/// <param name="dir"> A Direction </param>
/// <return> Does not return anything </return>
    override this.Interact (other:Robot) (dir:Direction) : Action =        
        let mutable result = Ignore
        let (x,y) = other.Position
        
        if n < 0 then
          for i in 0 .. (n * -1)-1 do 
            match dir with 
                | East when (x,y) = ((r*2-1)-i*2,c*2-1) -> result <- Stop ((x+1)/2,(y+1)/2)
                | West when (x,y-2) = ((r*2-1)-i*2,c*2-1) -> result <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()
        else 
          for i in 0 .. n-1 do 
            match dir with 
                | East when (x,y) = ((r*2-1)+i*2,c*2-1) -> result <- Stop ((x+1)/2,(y+1)/2)
                | West when (x,y-2) = ((r*2-1)+i*2,c*2-1) -> result <- Stop ((x+1)/2,(y+1)/2)
                | _ -> ()
        result
/// <summary> The class HorizontalWall is used to decide where to place a horizontal wall on the board </summary>
/// <param name="r"> The row in on the board </param>
/// <param name="c"> the colums on the board </param>
/// <param name="n"> The length of a wall </param>
/// <return> Does not return anything </return>
and HorizontalWall (r:int, c:int, n:int) =
    inherit BoardElement ()   
/// <summary> RenderOn is used to render a wall on a board </summary>
/// <param name="board"> a BoardDisplay </param>
/// <return> Does not return anything </return>         
    override this.RenderOn (board:BoardDisplay) = 
        if n < 0 then
            for i in 0 .. (n * -1)-1 do
                board.SetBottomWall r (c-i) 
        else 
            for i in 0 .. n-1 do
                board.SetBottomWall r (c+i)
/// <summary> Used to tell that the robot should stop when moved into a horizontal wall </summary>
/// <param name="other"> A Robot </param>
/// <param name="dir"> A Direction </param>
/// <return> Does not return anything </return> 
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
/// <summary> The class Victory is used to print "Victory" </summary>
/// <return> Does not return anything </return> 
and Victory () = 
    inherit BoardElement ()
/// <summary> RenderOn is used to render "Victory" on a board </summary>
/// <param name="board"> a BoardDisplay </param>
/// <return> Does not return anything </return>     
    override this.RenderOn (board:BoardDisplay) = 
        let (r,c) = board.Messurements
        let a = "VICTORY"
        for i in 0 .. 6 do 
            board.Set (r-1) (c/2-1+(2*i)) (string a.[i])
            
/// <summary> The Class Board is used to define a board with elements </summary>
/// <param name="r"> The boards rows </param>
/// <param name="c"> The boards colums </param>
/// <return> Does not return anything </return>
type Board (r:int, c:int) =
    let frame = BoardFrame(r,c)
    let mutable elements : BoardElement list = [frame]
    let mutable robots : BoardElement list = []
    member this.Elements with get() = elements and set(a) = elements <- a
    member this.Robots with get() = robots and set(a) = robots <- a
    new () = Board (0,0)
/// <summary> Addrobot is used to add robts to a list of robots and elements </summary>
/// <param name="robot"> BoardElement </param>
/// <return> Does not return anything </return>
    member this.AddRobot (robot:BoardElement) : unit = 
        elements <- elements @ [robot]  
        robots <- robot :: robots
/// <summary> AddElement is used to add new elemnts to a list of and elements </summary>
/// <param name="element"> BoardElement </param>
/// <return> Does not return anything </return> 
    member this.AddElement (element:BoardElement) : unit = 
        elements <- elements @ [element]
/// <summary> Move is used to move a robot in a given direction </summary>
/// <param name="robot"> Robot </param>
/// <param name="dir"> Direction </param>
/// <return> Does not return anything </return>   
    member this.Move (robot:Robot) (dir:Direction) : unit = 
        let mutable a = true
        for i in 0 .. elements.Length-1 do
                if elements.[i].Interact(robot) (dir) <> Ignore then 
                    a <- false
        if a then 
            robot.Step dir
            this.Move(robot) (dir)
/// <summary> RenderOn is used to render a board </summary>
/// <param name="board"> a BoardDisplay </param>
/// <return> Does not return anything </return>      
    member this.RenderOn (board:BoardDisplay) : unit = 
        for i in 0 .. elements.Length-1 do
            elements.[i].RenderOn(board)

