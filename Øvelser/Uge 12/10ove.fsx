(*
type student (name:string) =
    member this.Name = name

let obj1 = student ("jon")
let obj2 = student ("hans")

printfn "%A" <| obj1.Name
printfn "%A" <| obj2.Name
*)

type student (name:string) =
    let mutable name_mut = name
    member this.Name = name_mut
    member this.getValue = name_mut
    member this.setValue new_val = name_mut <- new_val

let obj1 = student ("Jon")
let obj2 = student ("Hans")

let newStudent (newName:string) : string =
    printfn "%A" <| obj2.getValue 
    obj2.setValue newName
    printfn "%A" <| obj2.getValue
    newName

newStudent "Kevin"

type Counter() =
    let mutable x_mut = 0
    member this.X = x_mut
    member this.get = x_mut
    member this.incr = x_mut <- x_mut + 1

let go = Counter()
printfn "%A" go.get
go.incr
printfn "%A" go.get

//type cCounter()=
    


//type xCounter()
(*
type Car ( econ:float, fuel:float ) =
    let mutable curr_gas = fuel // liters in the tank
    do printfn " Created a car (%.1f, %.1f)" econ fuel
    member this.gasLeft = curr_gas
    member this.addGas plusGas = curr_gas <- curr_gas + plusGas 
    member this.drive distance =
        if curr_gas < (distance/econ) then
            curr_gas
        else
            curr_gas <- curr_gas - distance / econ

let car1 = Car (8.0, 0.0)
car1.addGas 45.0
car1.drive 100.0
printfn "%A" car1.gasLeft
*)
type Car ( econ:float, fuel:float ) =
    let mutable currFuel = fuel // liters in the tank
    do printfn " Created a car (%.1f, %.1f)" econ fuel
    member this.gasLeft = currFuel
    member this.addGas plusGas = currFuel <- currFuel + plusGas 
    member this.drive distance =
        if currFuel > (distance/econ) then
            currFuel <- currFuel - distance / econ
        else
            currFuel <- currFuel

let car1 = Car (8.0, 0.0)
car1.addGas 15.0
car1.drive 100.0
printfn "%A" car1.gasLeft

type Moth (x_init:float, y_init:float) =
    let mutable x = x_init
    let mutable y = y_init
    member this.moveToLight = (x <- x/2.0), (y <- y/2.0)
    member this.getPosition = (x, y)

let boi = Moth (30.0, 20.0)
printfn "%A" boi.getPosition
boi.moveToLight 
printfn "%A" boi.getPosition


(*
let (+@) (A:int*int) (B:int) : int*int =
    (fst A*B, snd A*B)
let (++) (A:int*int) (B:int) : int*int =
    (fst A+B, snd A+B)

let (+|) (A:int*int) (B:int*int) : int*int = 
    (fst A + fst B, snd A + snd B)

let (+-) (A:int*int) (B:int*int) : int*int =
    (fst A - fst B, snd A - snd B)

let Length (A:int*int) : int =
    int(sqrt(float(fst A)**2. + float(snd A)**2.))

let newPos (A:int*int) : int*int =
    let length = Length A 
    (int(fst A / length), int(snd A / length))

type drone (startpos:int*int, destination:int*int, speed:int) = 
    let mutable Position = startpos
    let mutable Destination = destination
    let mutable Speed = speed
    let mutable AtDestination = false
    member this.getSpeed = Speed
    member this.getPosition = Position
    member this.getDestination = Destination
    member this.newPosition = (newPos(Destination +- Position) +@ speed)
    member this.setAtDestination = AtDestination <- true
    member this.atDestination = 
        if Position = Destination then
            true
        else
            false
    member this.Fly = 
        if (this.atDestination = true) then
            ()
        else
            if (Length(Destination +- Position) < Speed) then
                Position <- Destination
                AtDestination <- true
                ()
            else
                if(Length(Destination +- Position) = Speed) then 
                    Position <- Destination
                    AtDestination <- true
                    ()
                else 
                    Position <- Position +| this.newPosition
                    ()
                
let drone1 = drone ((3,9), (0,0), 6)
drone1.Fly
printfn "%A" drone1.getPosition


type Car (acc, bra, gSpe)
    member this.yearOfModel
    member this.make
    member this.speed
    member this.accelerate
    member this.brake
    member this.getSpeed
*)