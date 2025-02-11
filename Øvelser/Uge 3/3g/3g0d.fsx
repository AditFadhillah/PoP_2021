printfn "Insert an integer to find its sum"
let n = int(System.Console.ReadLine())

printfn "-----------------------"

let sum (n: int) : int =
    let mutable i = 0
    let mutable s = 0
    while i < n do 
      i <- i + 1
      s <- i + s
    s

let simpleSum (n : int) : int = (n*(n+1))/2

printfn "%-4s %-4s %-4s" "n" "sum" "simpleSum"

for p = 1 to n do 
    printfn "%-4d %-4d %-4d" p (sum p) (simpleSum p)
