(*
let fib (i : int) : int =
 if i < 1 then
  0
 else
  let mutable prevPrev 0
  let mutable prev = 1
  let mutable curr = 1
  for n = 2 to i do
   curr <- prevPrev + prev
   prevPrev <- prev
   prev <- curr
  prev
printfn "fib 3 = %d" (fib 3)
*)

let fib n =
 if n < 1 then 0
 else
  let mutable prev = (0,1)
  for i = 2 to n do
   prev <- (snd prev, (fst prev)+(snd prev))
  snd prev

let N = 10
printfn "%d: %d" N (fib N)