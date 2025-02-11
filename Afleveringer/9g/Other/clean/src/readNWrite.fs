module readNWrite
open System.Net
open System
open System.IO


/// <summary> The function readfile outputs the content of a given file  </summary>
/// <param name="filename"> The name of a file </param>
/// <returns> Either "None" if the file is empty or "Some()" with the content of the file"  </returns> 

let readFile (filename:string) : string option =
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




/// <summary> The function cat prints the content of a given file  </summary>
/// <param name="filenames"> The name of the file(s) </param>
/// <returns> Either "None" if the file(s) are empty or "Some()" with the content of the file(s)"  </returns>

let cat (filenames:string list) : string option =
    try 
        Some (List.fold (fun acc file -> acc + (readFile(file) |> Option.get)) "" filenames)
    with 
        _ -> None




/// <summary> The function tac prints the content of a file in reversed order </summary>
/// <param name="filenames"> The name of the file(s) </param>
/// <returns> Either "None" if the file(s) are empty or "Some()" with the content of the file(s) reversed" </returns>

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
    





        

