open readNWrite

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