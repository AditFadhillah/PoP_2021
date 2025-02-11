

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

    member this.Play1() : int =
        let mutable counter = 1
        System.Console.Clear()
        printfn "Welcome to robot raze - level 1"
        let mutable (r,c) = (8,8)
        printfn "your board has messurements: %A" <| (r,c)
        let boardCanvas = new BoardDisplay(r,c)
        let boardElem = Board(r,c)
        let Vic = Victory ()
        
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