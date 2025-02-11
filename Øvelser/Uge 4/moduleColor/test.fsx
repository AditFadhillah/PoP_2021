let trunc v =
 let mutable p = v
 if v < 0 then
  p <- 0
 elif v > 255 then
  p <- 255
 p

(*
// let add ((r1,g1,b1) : int*int*int) ((r2,g2,b2) : int*int*int) : (int*int*int) =
let add (c1 : int*int*int) (c2 : int*int*int) : int*int*int =
 let (r1,g1,b1) = c1
 let (r2,g2,b2) = c2
 (trunc(r1 + r2), trunc(g1 + g2), trunc(b1 + b2))
 //trunc(c1 + c2)
*)

(*
let add ((r1,g1,b1) : int*int*int) ((r2,g2,b2) : int*int*int) : (int*int*int) =
 let ri = trunc(r1+r2)
 let gi = trunc(g1+g2)
 let bi = trunc(b1+b2)
 let ci = (ri,gi,bi)
 ci
*)


let add (c1 : int*int*int) (c2 : int*int*int) : int*int*int =
 let (r1,g1,b1) = c1
 let (r2,g2,b2) = c2
 (trunc(r1 + r2), trunc(g1 + g2), trunc(b1 + b2))


let red = (255,0,0)
let blue = (0,0,255)

printfn "%A" add (255,0,0) (0,0,255)