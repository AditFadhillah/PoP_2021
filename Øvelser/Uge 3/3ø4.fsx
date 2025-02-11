let f (a : int) (b : int) (x : int) : int = a * x + b //rækkefælge afhængig af (a:int) (b:int) (x:int)

// a
let y0 = f 3 4 0 in do printfn "%A" y0
let y1 = f 3 4 1 in do printfn "%A" y1
let y2 = f 3 4 2 in do printfn "%A" y2
let y3 = f 3 4 3 in do printfn "%A" y3
let y4 = f 3 4 4 in do printfn "%A" y4
let y5 = f 3 4 5 in do printfn "%A" y5

printfn "%A" "-----------------------"

// b
for i_b = 0 to 5 do
    let y_b = f 3 4 i_b in do printfn "%A" y_b

printfn "%A" "-----------------------"

// c
let mutable i_c = 0
while i_c < 6 do
      let y_c = f 3 4 i_c
      i_c <- i_c + 1
      printfn "%A" y_c
     