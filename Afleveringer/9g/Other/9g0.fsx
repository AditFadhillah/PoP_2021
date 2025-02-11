//9g0
let readFile (filename:string) : string option =
    try
        let printFile (reader : System.IO.StreamReader) : string = 
            let mutable s = ""
            while not (reader.EndOfStream) do 
                s <- s + string((char)(reader.Read ()))
            s
        let reader = System.IO.File.OpenText filename
        try 
            Some (printFile reader)
        with 
            _ -> None
    with
        | ex -> None



let cat (filenames:string list) : string option =
    try 
        Some (List.fold (fun acc file -> acc + (readFile(file) |> Option.get)) "" filenames)
    with 
        _ -> None



let tac (filenames:string list) : string option =
    let revString (s:string) : string = 
            let mutable str = ""
            for i = 0 to s.Length-1 do 
                str <- str + string s.[(s.Length-1)-i]
            str
    try 
        Some (revString ((cat filenames) |> Option.get))
    with 
        _ -> None
    

open System.Net
open System
open System.IO

let fetchUrl (url:string) : string =
    let req = WebRequest.Create(Uri(url)) // make request
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    in reader.ReadToEnd()


let countLinks (url:string) : int = 
    let mutable c = 0
    let url1 = fetchUrl(url)
    for i = 0 to url1.Length-1 do 
        if url1.[i..(i+1)] = "<a" then 
            c <- c + 1
    c  

[<EntryPoint>]
let main (args:string array) : int = 
    if Array.length args > 0 then
        (printfn "%A" (cat (args |> Array.toList)))
        (printfn "%A" (tac (args |> Array.toList)))
        0
    else (printfn "Expects file name as argument"; 1)
