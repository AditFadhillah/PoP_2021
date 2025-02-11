open robots

type Game() = 
    //new : Board -> Game
    member this.Play() : int =
        let mutable counter = 1
        System.Console.Clear()
        printfn "Welcome to Ricochet Robots"
        let mutable (r,c) = (8,8)
        printfn "Your board has measurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        
        let PARADIZE = Goal(2,2)

        let AA = Robot (1,3,"AA")
        let BB = Robot (4,4,"BB")
        let CC = Robot (7,7,"CC")

        let VWall1 = VerticalWall (2,3,1)
        let VWall2 = VerticalWall (2,5,1)
        let VWall3 = VerticalWall (1,6,1)
        let VWall4 = VerticalWall (2,8,1)
        let VWall5 = VerticalWall (3,4,1)
        let VWall6 = VerticalWall (4,3,1)
        let VWall7 = VerticalWall (6,3,1)
        let VWall8 = VerticalWall (7,5,1)
        let VWall9 = VerticalWall (5,6,1)
        let HWall1 = HorizontalWall (3,3,3)
        let HWall2 = HorizontalWall (5,8,-2)
        let HWall3 = HorizontalWall (7,5,1)
        let HWall4 = HorizontalWall (6,3,1)

        boardElem.AddRobot AA
        boardElem.AddRobot BB
        boardElem.AddRobot CC
        boardElem.AddElement VWall1 
        boardElem.AddElement VWall2
        boardElem.AddElement VWall3
        boardElem.AddElement VWall4
        boardElem.AddElement VWall5
        boardElem.AddElement VWall6
        boardElem.AddElement VWall7
        boardElem.AddElement VWall8
        boardElem.AddElement VWall9
        boardElem.AddElement HWall1
        boardElem.AddElement HWall2
        boardElem.AddElement HWall3
        boardElem.AddElement HWall4
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