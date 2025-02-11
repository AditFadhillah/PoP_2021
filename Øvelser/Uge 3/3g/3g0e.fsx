printfn "Insert an integer to find its sum"
let int64 n = int(System.Console.ReadLine())

printfn "-----------------------"

let sum (n: int) : int =
    let mutable i = int64 0
    let mutable s = int64 0
    while i < n do 
      i <- i + int64 1
      s <- i + s
    s

let simpleSum (n : int) : int = (n*(n + 1))/2

printfn "%-4s %-4s %-4s" "n" "sum" "simpleSum"

for p = int64 1 to n do 
    printfn "%-4d %-4d %-4d" p (sum int64 p) (simpleSum int64 p)
