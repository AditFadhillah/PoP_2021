

printfn ""
printfn "Whitebox testing of create"
printfn "%5b: create branch 1a" <| (Rotate.create 0u = ['a'..'d'])
printfn "%5b: create branch 1a" <| (Rotate.create 1u = ['a'..'d'])
printfn "%5b: create branch 2a" <| (Rotate.create 2u = ['a'..'d'])
printfn "%5b: create branch 2a" <| (Rotate.create 4u = ['a'..'p'])
printfn "%5b: create branch 2a" <| (Rotate.create 6u = ['a'..'y'])

printfn ""
printfn "Whitebox testing of board2Str"
printfn "%5b: board2Str branch 1a" <| (Rotate.board2Str [] = "\n \n")
printfn "%5b: board2Str branch 1a" <| (Rotate.board2Str ['a';'e';'g';'h';'k';'r';'v';'e';'c';'a';'g';'e';'q';'m';'y';'z'] = "\na e g h \nk r v e \nc a g e \nq m y z \n" )
printfn "%5b: board2Str branch 2a" <| (Rotate.board2Str 2u = ['a'..'d'])
printfn "%5b: board2Str branch 2a" <| (Rotate.board2Str 4u = ['a'..'p'])
printfn "%5b: board2Str branch 2a" <| (Rotate.board2Str 6u = ['a'..'y'])