open robots

type Game() = 
    let mutable counter = 1
    let moveAndShow (boardElem:Board) (robo:Robot) (dir:Direction) (boardCanvas:BoardDisplay) (gamePlay) : unit =
        boardElem.Move robo dir
        boardElem.RenderOn boardCanvas
        System.Console.Clear()
        boardCanvas.Show
        gamePlay robo
    
    let readAndMove (boardElem:Board) (robo:Robot) (boardCanvas:BoardDisplay) (gamePlay) : unit = 
        match (System.Console.ReadKey(true)).Key with 
            | System.ConsoleKey.Enter -> 
                counter <- counter + 1
            | System.ConsoleKey.UpArrow -> 
                moveAndShow (boardElem:Board) (robo:Robot) (North:Direction) (boardCanvas:BoardDisplay) (gamePlay)
            | System.ConsoleKey.DownArrow -> 
                moveAndShow (boardElem:Board) (robo:Robot) (South:Direction) (boardCanvas:BoardDisplay) (gamePlay)
            | System.ConsoleKey.LeftArrow -> 
                moveAndShow (boardElem:Board) (robo:Robot) (West:Direction) (boardCanvas:BoardDisplay) (gamePlay)
            | System.ConsoleKey.RightArrow -> 
                moveAndShow (boardElem:Board) (robo:Robot) (East:Direction) (boardCanvas:BoardDisplay) (gamePlay)
            | _ -> gamePlay (robo)

    member this.Play1() : int =
        System.Console.Clear()
        printfn "Welcome to robot raze - level 1"
        let mutable (r,c) = (5,10)
        printfn "Your board has messurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        let PARADIZE = Goal(3,8)
        let Vic = Victory ()
        let AA = Robot (1,1,"AA")

        let VWall1 = VerticalWall (2,9,3)
        let VWall2 = VerticalWall (4,1,-2)
        let VWall3 = VerticalWall (3,8,1)
        let HWall1 = HorizontalWall (1,1,9)
        let HWall2 = HorizontalWall (4,9,-8)
        let HWall3 = HorizontalWall (2,2,7)
        let HWall4 = HorizontalWall (3,3,6)

        boardElem.AddRobot AA
        boardElem.AddElement VWall1
        boardElem.AddElement VWall2
        boardElem.AddElement VWall3
        boardElem.AddElement HWall1
        boardElem.AddElement HWall2
        boardElem.AddElement HWall3
        boardElem.AddElement HWall4
        boardElem.AddElement PARADIZE

        printfn "This is your board, you have to make one of the robots land on the Goal GG"
        boardElem.RenderOn boardCanvas
        boardCanvas.Show
        
        let mutable winning = false
        let rec gamePlay (robo:Robot) = 
            if PARADIZE.GameOver(robo) then 
                Vic.RenderOn boardCanvas
                System.Console.Clear()
                boardCanvas.Show
                printfn "You've won"
                winning <- true
                while (System.Console.KeyAvailable = false) do 
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Blue
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Red
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"    
                counter <- 1
                    
            else 
                printfn "Choose direction"  
                readAndMove (boardElem:Board) (robo:Robot) (boardCanvas:BoardDisplay) (gamePlay)
        
        let rec play () = 
            if not winning then
              printfn "Choose robot: a(AA) - current score : %A" counter 
              match (System.Console.ReadKey(true)).Key with 
                | System.ConsoleKey.A -> 
                    gamePlay (AA)
                    play()
                | _ -> 
                    play()
        play()        
        
        gamePlay (AA)
        counter
    
    member this.Play2() : int = 
        System.Console.Clear()
        printfn "Welcome to robot raze - Level 2"
        let mutable (r,c) = (10,10)
        printfn "Your board has messurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        let PARADIZE = Goal(r/2+1,c/2)

        let Vic = Victory ()

        let AA = Robot (1,5,"AA")
        let BB = Robot (10,5,"BB")
        let CC = Robot (2,1,"CC")

        let VWall1 = VerticalWall (2,5,2)
        let VWall2 = VerticalWall (3,2,1)
        let VWall3 = VerticalWall (7,3,3)
        let VWall4 = VerticalWall (8,6,-5)
        let VWall5 = VerticalWall (3,2,1)
        let HWall1 = HorizontalWall (3,2,3)
        let HWall2 = HorizontalWall (4,2,-2)
        let HWall3 = HorizontalWall (8,2,6)
        let HWall4 = HorizontalWall (5,2,2)
        let HWall5 = HorizontalWall (4,2,-2)

        boardElem.AddRobot AA
        boardElem.AddRobot BB
        boardElem.AddRobot CC
        boardElem.AddElement VWall1
        boardElem.AddElement VWall2
        boardElem.AddElement VWall3
        boardElem.AddElement VWall4
        boardElem.AddElement VWall5
        boardElem.AddElement HWall1
        boardElem.AddElement HWall2
        boardElem.AddElement HWall3
        boardElem.AddElement HWall4
        boardElem.AddElement HWall5
        boardElem.AddElement PARADIZE


        printfn "This is your board, you have make one of the robots land on the Goal GG"
        boardElem.RenderOn boardCanvas
        boardCanvas.Show
        

        let mutable winning = false
        let rec gamePlay (robo:Robot) = 
            if PARADIZE.GameOver(robo) then 
                Vic.RenderOn boardCanvas
                System.Console.Clear()
                boardCanvas.Show
                printfn "You've won"
                winning <- true
                while (System.Console.KeyAvailable = false) do 
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Blue
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Red
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"    
                counter <- 1

            else 
                printfn "Choose direction or press enter to choose a new robot"  
                readAndMove (boardElem:Board) (robo:Robot) (boardCanvas:BoardDisplay) (gamePlay)
        

        let rec play () = 
            if not winning then
              printfn "Choose robot: a(AA), b(BB) og c(CC) - current score : %A" counter 
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
        counter

    member this.Play3() : int =
        System.Console.Clear()
        printfn "Welcome to robot raze - Level 3 - the hardest one.."
        let mutable (r,c) = (20,10)
        printfn "Your board has messurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        let PARADIZE = Goal(10,5)

        let Vic = Victory ()

        let AA = Robot (9,5,"AA")
        let BB = Robot (9,6,"BB")
        let CC = Robot (10,6,"CC")

        boardElem.AddRobot AA
        boardElem.AddRobot BB
        boardElem.AddRobot CC
        boardElem.AddElement PARADIZE

        printfn "This is your board, you have make one of the robots land on the Goal GG"
        boardElem.RenderOn boardCanvas
        boardCanvas.Show
        

        let mutable winning = false
        let rec gamePlay (robo:Robot) = 
            if PARADIZE.GameOver(robo) then 
                Vic.RenderOn boardCanvas
                System.Console.Clear()
                boardCanvas.Show
                printfn "You've won"
                winning <- true
                while (System.Console.KeyAvailable = false) do 
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Blue
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"
                    System.Threading.Thread.Sleep(500)
                    System.Console.BackgroundColor <- System.ConsoleColor.Red
                    System.Console.Clear()
                    boardCanvas.Show
                    printfn "Your score: %A" counter
                    printfn "Press any key to play again"    
                counter <- 1

            else 
                printfn "Choose direction or press enter to choose a new robot"  
                readAndMove (boardElem:Board) (robo:Robot) (boardCanvas:BoardDisplay) (gamePlay)
        
        let rec play () = 
            if not winning then
              printfn "Choose robot: a(AA), b(BB) og c(CC) - current score : %A" counter 
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
        counter


let spil = Game() 

let rec leveler () : unit = 
    System.Console.Clear()
    printfn "WARNING: This game may potentially trigger seizures for people with photosensitive epilepsy. Viewer discretion is advised."
    System.Threading.Thread.Sleep(3000)
    System.Console.Clear()
    printfn "Choose level 1, 2 or 3" 
    match (System.Console.ReadKey(true)).Key with        
      | System.ConsoleKey.D1 -> 
        printfn "Your score was %A" (spil.Play1())
        System.Console.BackgroundColor <- System.ConsoleColor.Black
        System.Console.Clear()
        leveler()
      | System.ConsoleKey.D2 -> 
        printfn "Your score was %A" (spil.Play2())
        System.Console.BackgroundColor <- System.ConsoleColor.Black
        System.Console.Clear()
        leveler()
      | System.ConsoleKey.D3 -> 
        printfn "Your score was %A" (spil.Play3())
        System.Console.BackgroundColor <- System.ConsoleColor.Black
        System.Console.Clear()
        leveler()
      | _ -> 
        leveler()


leveler()