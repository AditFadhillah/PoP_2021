module vec2d

let len (v : float*float) : float =
    let (x,y) = v
    sqrt(x**2.0+y**2.0)

let ang (v : float*float) : float =
    let (x,y) = v
    (atan2 y x)

let add (v1 : float*float) (v2 : float*float) : float*float =
    let (x1,y1) = v1
    let (x2,y2) = v2
    ((x1+x2),(y1+y2))