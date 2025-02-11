let column (n : int) : in = 10
let simpleSum (n : int) : int = (n*(n+1))/2


let sum (n : int) : int =
 let mutable i = 0
 let mutable s = 0
 if n < 1 then printfn "0"
 while i < n do
  i <- i + 1
  s <- i + s
  
printfn "%d %d %d" n (simpleSum n)(sum n)