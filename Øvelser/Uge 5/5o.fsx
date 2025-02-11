(*
// 5o3
let printLstAlt (lst : 'a list) : unit =
  for elm in lst do
    printf "%A " elm
  printfn ""

printLstAlt ["aa"; "bb"; "cc"; "dd"; "ee";]
printLstAlt [1; 2; 3; 4; 5;]
*)

(*
let printLst (lst : 'a list) : unit =
  List.iter (fun x -> printfn "%A" x ) lst
  
printLst ["aa"; "bb"; "cc"; "dd"; "ee";]
printLst [1; 2; 3; 4; 5;]
*)

(*
let printDiv2Lst (lst : int list) : unit =
  let newlist = List.map (fun  x -> float x / 2.0)  lst
  printfn "%A" newlist

printDiv2Lst [1; 2; 3;]
*)

let even (lst : int list) : bool =
  let mutable x = List.filter ((x = (x % 2) = 0) = true) lst
  if x = (x % 2) = 0 then
    true
  else
    false
  
even [2; 4; 6;]


(*
let lst = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let n = 9
for i = 0 to n do
     printfn "%A" (lst.[i])
*)

(*
List.iter (fun x -> printfn "%d" x) [1;3;4]
*)

(*
let animals = ["cat"; "bird"; "fish"; "fox"]
let numbers = [5; 10; 15; 20]
let f = numbers
*)

(*
printLstAlt x =
  for f in f do
    printfn "%A" f
*)