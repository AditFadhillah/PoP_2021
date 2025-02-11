open System.Net
open System
open System.IO


//Function copied from Martin Elsman. lecture_inet.pdf
//Powerpoint "programering og problemløsning - Regulære udtryk og læsning fra internettet" slide 8 
let fetchUrl (url:string) : string =
    let req = WebRequest.Create(Uri(url)) // make request
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    in reader.ReadToEnd()


/// <summary> The function counts all links in a website </summary>
/// <param name="url"> A webadress </param>
/// <returns> returns the amount of links as an integer </returns>

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
        (printfn "%A" (countLinks (args.[0])))
        0
    else (printfn "Expects file name as argument"; 1)