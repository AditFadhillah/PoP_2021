open readNWrite

let cat (filenames:string list) : string option =
    try 
        Some (List.fold (fun acc file -> acc + (readFile(file) |> Option.get)) "" filenames)
    with 
        _ -> None