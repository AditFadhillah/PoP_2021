open simulate


printfn "++++++++++++++++++++++++++++++++++++++++++ \n Black-box tests of Drone class \n++++++++++++++++++++++++++++++++++++++++++"

printfn "========================================== \n Black-box tests of method getPosition \n=========================================="
let dPos1 = Drone ((2000,4000), (0,0), 400)
let dPos2 = Drone ((-2500,-5000), (0,0), 400)
let dPos3 = Drone ((-5500,1100), (0,0), 400)
let dPos4 = Drone ((0, -2300), (0,0), 400)
let dPos5 = Drone ((0,0), (0,0), 400)

printfn "%5b: A drone's start position : (dPos1.getPosition() = (2000,4000))" (dPos1.getPosition() = (2000,4000))
printfn "%5b: A drone's start position : (dPos2.getPosition() = (-2500,-5000))" (dPos2.getPosition() = (-2500,-5000))
printfn "%5b: A drone's start position : (dPos3.getPosition() = (-5500,1100))" (dPos3.getPosition() = (-5500,1100))
printfn "%5b: A drone's start position : (dPos4.getPosition() = (0, -2300))" (dPos4.getPosition() = (0, -2300))
printfn "%5b: A drone's start position : (dPos5.getPosition() = (0,0))" (dPos5.getPosition() = (0,0))


printfn "========================================== \n Black-box tests of method Fly \n=========================================="
let dFly1 = Drone ((2000,4000), (0,0), 400)
let dFly2 = Drone ((-2500,-5000), (0,0), 500)
let dFly3 = Drone ((-5500,1100), (0,0), 900)
let dFly4 = Drone ((0, -2300), (0,0), 200)
let dFly5 = Drone ((0,0), (0,0), 100)

dFly1.Fly()
dFly2.Fly()
dFly3.Fly()
dFly4.Fly()
dFly5.Fly()

printfn "%5b: A drone's new position after one second of flight : (dFly1.getPosition() = (1821, 3642))" (dFly1.getPosition() = (1821, 3642))
printfn "%5b: A drone's new position after one second of flight : (dFly2.getPosition() = (-2276, -4552))" (dFly2.getPosition() = (-2276, -4552))
printfn "%5b: A drone's new position after one second of flight : (dFly3.getPosition() = (-4617, 923))" (dFly3.getPosition() = (-4617, 923)) 
printfn "%5b: A drone's new position after one second of flight : (dFly4.getPosition() = (0, -2100))" (dFly4.getPosition() = (0, -2100))
printfn "%5b: A drone's new position after one second of flight : (dFly5.getPosition() = (0,0))" (dFly5.getPosition() = (0,0))

printfn "========================================== \n Black-box tests of method resetAll \n=========================================="

dFly1.resetAll()
dFly2.resetAll()
dFly3.resetAll()
dFly4.resetAll()
dFly5.resetAll()

printfn "%5b: The position of a drone returns to its start position : (dFly1.getPosition() = (2000,4000))" (dFly1.getPosition() = (2000,4000))
printfn "%5b: The position of a drone returns to its start position : (dFly2.getPosition() = (-2500,-5000))" (dFly2.getPosition() = (-2500,-5000))
printfn "%5b: The position of a drone returns to its start position : (dFly3.getPosition() = (-5500,1100))" (dFly3.getPosition() = (-5500,1100)) 
printfn "%5b: The position of a drone returns to its start position : (dFly4.getPosition() = (0, -2300))" (dFly4.getPosition() = (0, -2300))
printfn "%5b: The position of a drone returns to its start position : (dFly5.getPosition() = (0,0))" (dFly5.getPosition() = (0,0))

printfn "========================================== \n Black-box tests of method AtDestination \n=========================================="

for t = 1 to 11 do
            dFly1.Fly()
for t = 1 to 11 do
            dFly2.Fly()
for t = 1 to 6 do
            dFly3.Fly()
for t = 1 to 11 do
            dFly4.Fly()
for t = 1 to 1 do
            dFly5.Fly()

printfn "%5b: After 11 seconds of flight this drone still hasn't reached its destination : (dFly1.AtDestination() = false)" (dFly1.AtDestination() = false)
printfn "%5b: After 11 seconds of flight this drone still hasn't reached its destination : (dFly2.AtDestination() = false)" (dFly2.AtDestination() = false)
printfn "%5b: After 6 seconds of flight this drone still hasn't reached its destination : (dFly3.AtDestination() = false)" (dFly3.AtDestination() = false)
printfn "%5b: After 11 seconds of flight this drone still hasn't reached its destination : (dFly4.AtDestination() = false)" (dFly4.AtDestination() = false)
printfn "%5b: After 1 second of flight this drone has reached its destination : (dFly5.AtDestination() = true)" (dFly5.AtDestination() = true)

printf "\n"

dFly1.Fly()
dFly2.Fly()
dFly3.Fly()
dFly4.Fly()

printfn "%5b: After one more second of flight this drone finally reached its destination : (dFly1.AtDestination() = true)" (dFly1.AtDestination() = true)
printfn "%5b: After one more second of flight this drone finally reached its destination : (dFly2.AtDestination() = true)" (dFly2.AtDestination() = true)
printfn "%5b: After one more second of flight this drone finally reached its destination : (dFly3.AtDestination() = true)" (dFly3.AtDestination() = true)
printfn "%5b: After one more second of flight this drone finally reached its destination : (dFly4.AtDestination() = true)" (dFly4.AtDestination() = true)

printfn "++++++++++++++++++++++++++++++++++++++++++ \n Black-box tests of Airspace class \n++++++++++++++++++++++++++++++++++++++++++"

printfn "========================================== \n Black-box tests of method DroneDist \n=========================================="
let AirFly1 = Drone ((2000,4000), (10000,10000), 400)
let AirFly2 = Drone ((-2500,-5000), (0,5000), 500)
let AirFly3 = Drone ((-5500,1100), (5500,1100), 900)
let AirFly4 = Drone ((0, -2300), (-2300,0), 200)
let AirFly5 = Drone ((0,0), (0,0), 100)
let Sky1 = Airspace ([AirFly1; AirFly2; AirFly3; AirFly4; AirFly5])

printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly1) (AirFly2) = 10062)" (Sky1.DroneDist (AirFly1) (AirFly2) = 10062)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly1) (AirFly3) = 8041)" (Sky1.DroneDist (AirFly1) (AirFly3) = 8041)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly1) (AirFly4) = 6609)" (Sky1.DroneDist (AirFly1) (AirFly4) = 6609)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly1) (AirFly5) = 4472)" (Sky1.DroneDist (AirFly1) (AirFly5) = 4472)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly2) (AirFly3) = 6797)" (Sky1.DroneDist (AirFly2) (AirFly3) = 6797)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly2) (AirFly4) = 3679)" (Sky1.DroneDist (AirFly2) (AirFly4) = 3679)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly2) (AirFly5) = 5590)" (Sky1.DroneDist (AirFly2) (AirFly5) = 5590)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly3) (AirFly4) = 6466)" (Sky1.DroneDist (AirFly3) (AirFly4) = 6466)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly3) (AirFly5) = 5608)" (Sky1.DroneDist (AirFly3) (AirFly5) = 5608)
printfn "%5b: The distance between two different drones : (Sky1.DroneDist (AirFly4) (AirFly5) = 2300)" (Sky1.DroneDist (AirFly4) (AirFly5) = 2300)

printfn "========================================== \n Black-box tests of method getDrones \n=========================================="

let Sky2 = Airspace ([AirFly2; AirFly3; AirFly5])
let Sky3 = Airspace ([AirFly5])
let Sky4 = Airspace ([AirFly5; AirFly4])
let Sky5 = Airspace ([])


printfn "%5b: List of drones in the airspace : (Sky1.getDrones() = ([AirFly1; AirFly2; AirFly3; AirFly4; AirFly5]))" (Sky1.getDrones() = [AirFly1; AirFly2; AirFly3; AirFly4; AirFly5])
printfn "%5b: List of drones in the airspace : (Sky2.getDrones() = ([AirFly2; AirFly3; AirFly5]))" (Sky2.getDrones() = ([AirFly2; AirFly3; AirFly5]))
printfn "%5b: List of drones in the airspace : (Sky3.getDrones() = ([AirFly5; AirFly4]))" (Sky3.getDrones() = [AirFly5])
printfn "%5b: List of drones in the airspace : (Sky4.getDrones() = ([AirFly5; AirFly4]))" (Sky4.getDrones() = ([AirFly5; AirFly4]))
printfn "%5b: List of drones in the airspace : (Sky5.getDrones() = ([]))" (Sky5.getDrones() = ([]))

printfn "========================================== \n Black-box tests of method FlyDrones \n=========================================="

Sky1.FlyDrones()

printfn "%5b: The drone returns to its start position : (AirFly1.getPosition() = (2320, 4240))" (AirFly1.getPosition() = (2320, 4240))
printfn "%5b: The drone returns to its start position : (AirFly2.getPosition() = (-2378, -4514))" (AirFly2.getPosition() = (-2378, -4514))
printfn "%5b: The drone returns to its start position : (AirFly3.getPosition() = (-4600, 1100))" (AirFly3.getPosition() = (-4600, 1100))
printfn "%5b: The drone returns to its start position : (AirFly4.getPosition() = (-141, -2158))" (AirFly4.getPosition() = (-141, -2158))
printfn "%5b: The drone returns to its start position : (AirFly5.getPosition() = (0,0))" (AirFly5.getPosition() = (0,0))

printfn "========================================== \n Black-box tests of method FlyDrones \n=========================================="

Sky1.resetAllDrones()

printfn "%5b: A drone's new position after one second of flight : (AirFly1.getPosition() = (2000, 4000))" (AirFly1.getPosition() = (2000, 4000))
printfn "%5b: A drone's new position after one second of flight : (AirFly2.getPosition() = (-2500, -5000))" (AirFly2.getPosition() = (-2500, -5000))
printfn "%5b: A drone's new position after one second of flight : (AirFly3.getPosition() = (-5500, 1100))" (AirFly3.getPosition() = (-5500, 1100))
printfn "%5b: A drone's new position after one second of flight : (AirFly4.getPosition() = (0, -2300))" (AirFly4.getPosition() = (0, -2300))
printfn "%5b: A drone's new position after one second of flight : (AirFly5.getPosition() = (0,0))" (AirFly5.getPosition() = (0,0))

printfn "========================================== \n Black-box tests of method AddDrones \n=========================================="

Sky2.AddDrone (AirFly1)
Sky3.AddDrone (AirFly4)
Sky4.AddDrone (AirFly2)
Sky5.AddDrone (AirFly3)

printfn "%5b: List of drones in the airspace : (Sky2.getDrones() = ([AirFly2; AirFly3; AirFly5]))" (Sky2.getDrones() = ([AirFly2; AirFly3; AirFly5; AirFly1]))
printfn "%5b: List of drones in the airspace : (Sky4.getDrones() = ([AirFly5; AirFly4]))" (Sky3.getDrones() = [AirFly5; AirFly4])
printfn "%5b: List of drones in the airspace : (Sky3.getDrones() = ([AirFly5; AirFly4]))" (Sky4.getDrones() = ([AirFly5; AirFly4; AirFly2]))
printfn "%5b: List of drones in the airspace : (Sky5.getDrones() = ([]))" (Sky5.getDrones() = ([AirFly3]))

printfn "========================================== \n Black-box tests of method WillCollide \n=========================================="

let CrashFly1 = Drone ((2000,4000), (7000,4000), 400)
let CrashFly2 = Drone ((8000,4000), (1000,4000), 400)
let CrashFly3 = Drone ((-5000, 0), (-5000,-5000), 600)
let CrashFly4 = Drone ((0, -5000), (-5000,-5000), 600)
let CrashFly5 = Drone ((0,0), (0,0), 100)
let CrashSky = Airspace ([CrashFly1; CrashFly2; CrashFly3; CrashFly4; CrashFly5])

printfn "%5b: Pair of drones that collided with one another after 1 minute of flight : (CrashSky.WillCollide 1 = ([(CrashFly1, CrashFly2); (CrashFly3, CrashFly4)]))" (CrashSky.WillCollide 1 = ([(CrashFly1, CrashFly2); (CrashFly3, CrashFly4)]))

// I made my code so that only two drones can crash in one crash site, so the third drone will continue its flight towards its destination