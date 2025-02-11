module rgb



let trunc v =
    let mutable p = v
    if v < 0 then
        p <- 0
    elif v > 255 then
        p <- 255
    p



let add (c1:int*int*int) (c2:int*int*int) : int * int * int =
    let (r1,g1,b1)=c1
    let (r2,g2,b2)=c2
    (trunc(r1+r2),trunc(g1+g2),trunc(b1+b2))

let scale (c1:int*int*int) (a:int) : int * int * int =
    let (r1,g1,b1)=c1
    (trunc(r1*a),trunc(g1*a),trunc(b1*a))

let gray (c1:int*int*int) : int * int * int =
    let (r1,g1,b1)=c1
    (((r1+g1+b1)/3),(r1+g1+b1)/3,(r1+g1+b1)/3)