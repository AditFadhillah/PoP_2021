type coor = int*int

let origin : coor = (0.,0.)
let upwards : coor = (0.,1.)
let right : coor = (1.,0.)
let downwards : coor = (0.,-1.)
let left : coor = (-1.,0.)

// Scale the coortor with a float
let (+@) (A:coor) (B:float) : coor =
    (fst A*B, snd A*B)

// Add two coortors together
let (+|) (A:coor) (B:coor) : coor = 
    (fst A + fst B, snd A + snd B)

// Subtract two coortors from eachother
let (+-) (A:coor) (B:coor) : coor =
    (fst A - fst B, snd A - snd B)

let Length (A:coor) : float =
    int(sqrt(float(fst A)**2. + float(snd A)**2.))

let newPos (A:coor) : coor =
    let length = vectorLength A 
    (fst A / length, snd A / length)

type drone (position:int*int, destination:int*int, speed: int) = 
    let mutable Position = position
    let mutable Destination = destination
    let mutable Speed = speed
    member this.PositionTrue = Position
    member this.Fly = 
        let mutable (s_x,s_y) = Position
        let mutable (d_x,d_y) = Destination
        let mutable Length = int(sqrt(float(d_x-s_x)**2.0 + float(d_y-s_y)**2.0))
        Position <- (s_x - speed, s_y - speed)
        if Length <= speed then
            printfn "he drone has reached its destination"
    member this.AtDestination = 
        if Position = Destination then
            true
        else
            false
(*
type Airspace () =
    member this.Drones
    member this.DroneDist
    member this.FlyDrones
    member this.AddDrones
    member this.WillCollide
*)