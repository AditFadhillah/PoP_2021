

    member this.Play() : int =
        let mutable counter = 1
        System.Console.Clear()
        printfn "Welcome to Ricochet Robots"
        let mutable (r,c) = (6,10)
        printfn "Your board has measurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        
        let PARADIZE = Goal(4,6)

        let AA = Robot (1,9,"AA")
        let BB = Robot (3,5,"BB")
        let CC = Robot (2,5,"CC")

        let VWall1 = VerticalWall (2,5,-2)
        let VWall2 = VerticalWall (6,2,1)
        let HWall1 = HorizontalWall (3,3,3)
        let HWall2 = HorizontalWall (5,10,-2)

        boardElem.AddRobot AA
        boardElem.AddRobot BB
        boardElem.AddRobot CC
        boardElem.AddElement VWall1
        boardElem.AddElement VWall2
        boardElem.AddElement HWall1
        boardElem.AddElement HWall2
        boardElem.AddElement PARADIZE