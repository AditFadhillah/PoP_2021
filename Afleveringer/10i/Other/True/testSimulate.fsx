open simulate

let flyer2 = Drone ((1000,0), (1000,5400), 900) 
let flyer1 = Drone ((0,4000), (0,8000), 2)
let flyer3 = Drone ((6,0), (-6,0), 3)
//printfn "%A" flyer2.getPosition

let sky1 = Airspace ()
let flyer1 = Drone ((0,4000), (0,8000), 400)
let flyer2 = Drone ((1000,0), (1000,5400), 900) 
let flyer3 = Drone ((600,500), (-600,500), 500)

printfn "%5b: Empty Airspce" (sky1.getDrones = [])




//air1.FlyDrones
//air1.AddDrone flyer3

(*
air1.WillCollide 2

printfn "%A" flyer2.getPosition
printfn "%A" flyer2.AtDestination

printfn "Drone with"
printfn "%5b: Branch 1a - Finished" (d4.isFinished())
printfn "%5b: Branch 1b - Not Finished" (d4.isFinished() = false)
printfn "%5b: Branch 2a - Overshooting" (vectorLength(d4.getDestination() +- d4.getPosition()) < d4.getSpeed())
printfn "%5b: Branch 2b - Reached Destination" ((vectorLength(d4.getDestination() +- d4.getPosition())) = (d4.getSpeed()))
*)