open readNWrite

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