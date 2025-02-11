open readNWrite

[<EntryPoint>]
let main (args:string array) : int = 
    if Array.length args > 0 then
        (printfn "%A" (tac (args |> Array.toList)))
        0
    else (printfn "Expects file name as argument"; 1)