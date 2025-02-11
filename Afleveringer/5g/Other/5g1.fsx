(*
let arrayOfArrays = [| [| 1; 2; 3 |]; [|4; 5; 6 |] |]




let array2d arr=
       Array2D.init 2 3 (fun r c -> arr.[r].[c])     

//let transposeArr (arr: 'a [,]): 'a [,] =


//let newArray = Array2D.init (array2d |> Array2D.length2) (array2d |> Array2D.length1) (fun r c -> array2d.[c,r])

printfn "%A" (array2d ([ [ 1; 2; 3 ]; [4; 5; 6 ] ]))
//printfn "%A" newArray
*)

(*
let transpose (arr : 'T [,]): 'T [,] =
   Array2D.init (Array2D.length2 arr)  (Array2D.length1 arr) (fun x y -> array2D.[y,x])
  
printfn "%A" (transpose (array2D [|[|1;2;3|]; [|4;5;6|]|]))

*)
(*
let convert (oldArr: 'a list list) : 'a [,] =
   if oldArr.IsEmpty then
      []
   else if List.exists (fun (x:'a list) ->  x.IsEmpty) oldArr  then
      []
   else
      array2D oldArr

let transposeArr (newArr: 'a [,]) : 'a [,] =
   Array2D.init (Array2D.length2 newArr) (Array2D.length1 newArr) (fun x y -> newArr.[y,x])
*)


let t = [[]]
printfn "%A" (array2D t)
//printfn "%A" (transposeArr (convert t))
