module simulate

type Drone (position:int*int, destination:int*int, speed: int) = 
    let mutable Position = position
    let mutable Destination = destination
    let mutable Speed = speed
    let mutable crashed = false
    member this.setCrashed() = crashed <- true
    member this.isCrashed() = crashed
    member this.getPosition() = Position
    member this.getDestination() = Destination
    member this.getSpeed() = Speed
    
    ///<summary>The method this.resetAll resets the position and crashed status of the drone</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns the start position of the drone and returns the drone to its uncrashed state</returns>
    member this.resetAll() = 
        Position <- position
        crashed <- false

    ///<summary>The method this.Fly moves the drone according to its speed</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns a new position</returns>
    member this.Fly() = 
        let mutable (s_x,s_y) = Position
        let mutable (d_x,d_y) = Destination
        let mutable Length = int(sqrt(float(d_x - s_x)**2.0 + float(d_y - s_y)**2.0))
        if crashed = false && Length < Speed then
            Position <- Destination
        else
            Position <- (int(float(s_x) + float(speed)/float(Length) * float(d_x-s_x)), int(float(s_y) + float(speed)/float(Length) * float(d_y-s_y)))
    
    ///<summary>The method this.AtDestination checks whether or not the drone has reached its position</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns a boolean value, true if the drone reached its destination, false otherwise</returns>
    member this.AtDestination() = 
        if Position = Destination then
            true    
        else
            false

type Airspace (sdrones : Drone list) =
    let mutable drones = sdrones

    ///<summary>The method this.DroneDist gives the distance between two drones</summary>
    ///<param name="d1">The method takes a type Drone</param>
    ///<param name="d2">The method takes a type Drone</param>
    ///<returns>Returns an integer of the distance between two drones</returns>
    member this.DroneDist (d1: Drone) (d2: Drone) = 
        let pos1 = d1.getPosition()
        let pos2 = d2.getPosition()
        int(sqrt(float(fst pos2 - fst pos1)**2.0 + float(snd pos2 - snd pos1)**2.0))
    
    ///<summary>the method this.getDrones gives the list of drones</summary>
    ///<param name="">Unit for the running the method</param>
    ///<returns>Returns the list of drones in the collection</returns>
    member this.getDrones() = drones

    ///<summary>The method this.FlyDrones advance the position of all flying drones in the collection by one second</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns a new position for all flying drones</returns>
    member this.FlyDrones() = 
        for i = 0 to (drones.Length - 1) do
            drones.[i].Fly()
            
    ///<summary>The method this.resetAllDrones resets the position and crashed status of all the drones in the airspace</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns the start position of all the drones and returns the drones to its uncrashed states</returns>
    member this.resetAllDrones() =
        for i = 0 to (drones.Length - 1) do
            drones.[i].resetAll()

    ///<summary>The method this.AddDrone add a new drone to the collection by one second</summary>
    ///<param name="()">The method takes a unit</param>
    ///<returns>Returns a new collection where the added drone is in</returns>
    member this.AddDrone moreDrone = 
        drones <- drones @ [moreDrone]

    ///<summary>The method this.WillCollide determines whether or not the drone in the collection will crash during their flight</summary>
    ///<param name="minute">The method takes an integer, that denotes minutes</param>
    ///<returns>Returns a list of pairs of drones that collided in the time interval</returns>
    member this.WillCollide (minute: int) : (Drone*Drone) list =
        let mutable CollidedDrone : (Drone*Drone) list = []
        for t = 1 to (minute * 60) do
            this.FlyDrones()
            for i = 0 to (drones.Length - 1) do
                for j = (i + 1) to (drones.Length - 1) do
                    if((this.DroneDist(drones.[i])(drones.[j])) < 500 && not ((drones.[i].isCrashed() = true) || (drones.[j].isCrashed() = true))) then
                        CollidedDrone <- CollidedDrone @ [drones.[i], drones.[j]]
                        (drones.[i].setCrashed())
                        (drones.[j].setCrashed())
                        printfn " Collided at: %A %A " (drones.[i].getPosition()) (drones.[j].getPosition())
        CollidedDrone
