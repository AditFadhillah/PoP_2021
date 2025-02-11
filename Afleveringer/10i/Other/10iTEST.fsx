


type drone1 (position:int*int, destination:int*int, speed: int) = 
    let mutable Position = position
    let mutable Destination = destination
    let mutable Speed = speed
    member this.getPosition = Position
    member this.Fly = 
        let mutable (s_x,s_y) = Position
        let (d_x,d_y) = Destination
        let mutable Length = int(sqrt(float(d_x - s_x)**2.0 + float(d_y - s_y)**2.0))
        let mutable a = float(System.Math.Atan2 (float(d_x-s_x),float(d_y-s_y))*180.0/System.Math.PI)
        if Length <= speed then
            printfn "The drone has reached its destination"
            Position <- Destination
        else 
            Position <- (int(float(s_x) + cos(a) * float(Speed)), int(float(s_y) + sin(a) * float(Speed)))
    member this.AtDestination = 
        if Position = Destination then
            true    
        else
            false

let flyer1 = drone1 ((0,8), (0,0), 2) 
printfn "%A" flyer1.getPosition
flyer1.Fly
flyer1.Fly
printfn "%A" flyer1.getPosition

type Drone (position:int*int, destination:int*int, speed: int) = 
    let mutable Position = position
    let mutable Destination = destination
    let mutable Speed = speed
    member this.getPosition = Position
    member this.Fly = 
        let mutable (s_x,s_y) = Position
        let mutable (d_x,d_y) = Destination
        let mutable Length = int(sqrt(float(d_x - s_x)**2.0 + float(d_y - s_y)**2.0))
        if Length = 0 then
            printfn "The drone has reached its destination"
            Position <- Destination
        else 
            Position <- (int(float(s_x) + float(speed)/float(Length) * float(d_x-s_x)), int(float(s_y) + float(speed)/float(Length) * float(d_y-s_y)))
    member this.AtDestination = 
        if Position = Destination then
            true    
        else
            false

let flyer2 = Drone ((7,8), (0,0), 2) 
printfn "%A" flyer2.getPosition
flyer2.Fly
flyer2.Fly
flyer2.Fly
flyer2.Fly
flyer2.Fly


printfn "%A" flyer2.getPosition


type Airspace () =
    let mutable drones : Drone list 
    member this.DroneDist (d1: Drone) (d2: Drone) = 
        let pos1 = d1.getPosition()
        let pos2 = d2.getPosition()
        int(sqrt(float(fst pos2 - fst pos1)**2.0 + float(snd pos2 - snd pos1)**2.0))
    member this.GetDrones = drones
    member this.FlyDrones () = 
        for i in[0..(drones.Length - 1)] do
            drones.[i].Fly()
     member this.AddDrones (list: Drone list) = 
        for i in [0..(list.Length - 1)] do
            this.AddDrone (list.[i])
    member this.WillCollide (loop: int) : (Drone*Drone) list =
        let mutable collidedDrone : (Drone*Drone) list = []
        for x in 0..loop - 1 do
            this.flyDrones()
            for i in [0..(drones.Length - 1)] do
                for j in [i+1..(drones.Length - 1)] do
                    if((this.droneDist(drones.[i])(drones.[j])) <= 5. && not ((drones.[i].AtDestination()) || drones.[j].AtDestination())) then
                        collidedDrone <- collidedDrone @ [drones.[i], drones.[j]]
                        (drones.[i].setFinished())
                        (drones.[j].setFinished())
                        printfn "%s %A %A" "Collided at: " (drones.[i].getPosition()) (drones.[j].getPosition())
                        ()
                    else
                        ()
        collidedDrone
(**)
