

printfn ""
printfn "Whitebox testing of create"
printfn "create branch 1a : create 0u : %5b" <| (rotate.create 0u = ['a'..'d'])
printfn "create branch 1a : create 1u : %5b" <| (rotate.create 1u = ['a'..'d'])
printfn "create branch 2a : create 2u : %5b" <| (rotate.create 2u = ['a'..'d'])
printfn "create branch 2a : create 3u : %5b" <| (rotate.create 3u = ['a'..'i'])
printfn "create branch 2a : create 4u : %5b" <| (rotate.create 4u = ['a'..'p'])
printfn "create branch 2a : create 5u : %5b" <| (rotate.create 5u = ['a'..'y'])
printfn "create branch 2a : create 6u : %5b" <| (rotate.create 6u = ['a'..'y'])


printfn ""
printfn "Whitebox testing of board2Str"
printfn "board2Str branch 1a : board2Str [] : %5b" <| (rotate.board2Str [] = "\n")
printfn "board2Str branch 2a : board2Str (create 2u) : %5b" <| (rotate.board2Str ['a'..'d'] = "\na b \nc d \n")
printfn "board2Str branch 2a : board2Str (create 3u) : %5b" <| (rotate.board2Str ['a'..'i'] = "\na b c \nd e f \ng h i \n")
printfn "board2Str branch 2a : board2Str (create 4u) : %5b" <| (rotate.board2Str ['a'..'p'] = "\na b c d \ne f g h \ni j k l \nm n o p \n")
printfn "board2Str branch 2a : board2Str (create 5u) : %5b" <| (rotate.board2Str ['a'..'y'] = "\na b c d e \nf g h i j \nk l m n o \np q r s t \nu v w x y \n")

printfn ""
printfn "Whitebox testing of validRotation"
printfn "validRotation branch 1a : validRotation (create 5u) 20 : %5b" <| (rotate.validRotation ['a'..'y'] 20  = false)
printfn "validRotation branch 2a : validRotation (create 5u) 4 : %5b" <| (rotate.validRotation ['a'..'y'] 4 = false)
printfn "validRotation branch 3a : validRotation (create 5u) 9 : %5b" <| (rotate.validRotation ['a'..'y'] 9 = false)
printfn "validRotation branch 4a : validRotation (create 5u) 14 : %5b" <| (rotate.validRotation ['a'..'y'] 14 = false)
printfn "validRotation branch 5a : validRotation (create 5u) 19 : %5b" <| (rotate.validRotation ['a'..'y'] 19 = false)
printfn "validRotation branch 6a : validRotation (create 5u) 0 : %5b" <| (rotate.validRotation ['a'..'y'] 0 = true)
printfn "validRotation branch 6a : validRotation (create 5u) 3 : %5b" <| (rotate.validRotation ['a'..'y'] 3 = true)
printfn "validRotation branch 6a : validRotation (create 5u) 8 : %5b" <| (rotate.validRotation ['a'..'y'] 8 = true)
printfn "validRotation branch 6a : validRotation (create 5u) 13 : %5b" <| (rotate.validRotation ['a'..'y'] 13 = true)
printfn "validRotation branch 6a : validRotation (create 5u) 18 : %5b" <| (rotate.validRotation ['a'..'y'] 18 = true)

printfn ""
printfn "Whitebox testing of rotate"
printfn "rotate branch 1a : rotate (create 3u) 3 : %5b" <| (rotate.rotate (rotate.create 3u) 3 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "rotate branch 1a : rotate (create 3u) 6 : %5b" <| (rotate.rotate (rotate.create 3u) 6 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "rotate branch 1a : rotate (create 3u) 7 : %5b" <| (rotate.rotate (rotate.create 3u) 7 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "rotate branch 3a : rotate (create 3u) 1 : %5b" <| (rotate.rotate (rotate.create 3u) 1 = ['d'; 'a'; 'c'; 'e'; 'b'; 'f'; 'g'; 'h'; 'i'])
printfn "rotate branch 3a : rotate (create 3u) 2 : %5b" <| (rotate.rotate (rotate.create 3u) 2 = ['a'; 'e'; 'b'; 'd'; 'f'; 'c'; 'g'; 'h'; 'i'])
printfn "rotate branch 3a : rotate (create 3u) 5 : %5b" <| (rotate.rotate (rotate.create 3u) 5 = ['a'; 'b'; 'c'; 'd'; 'h'; 'e'; 'g'; 'i'; 'f'])

printfn ""
printfn "Whitebox testing of scramble"
printfn "scramble branch 1a : scramble (create 3u) 0u : %5b" <| (rotate.scramble (rotate.create 3u) 0u = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "scramble branch 2a : scramble (create 3u) 1u : %5b" <| (rotate.scramble (rotate.create 3u) 1u <> ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "scramble branch 2a : scramble (create 3u) 2u : %5b" <| (rotate.scramble (rotate.create 3u) 2u <> ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "scramble branch 2a : scramble (create 3u) 4u : %5b" <| (rotate.scramble (rotate.create 3u) 4u <> ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "scramble branch 2a : scramble (create 3u) 8u : %5b" <| (rotate.scramble (rotate.create 3u) 8u <> ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])

printfn ""
printfn "Whitebox testing of solved"
printfn "solved branch 1a : solved ['a';'b';'c';'d'] : %5b" <| (rotate.solved ['a';'b';'c';'d'] = true)
printfn "solved branch 2a : solved ['c';'a';'d';'b'] : %5b" <| (rotate.solved ['c';'a';'d';'b'] = false)
printfn "solved branch 2a : solved ['d';'c';'b';'a'] : %5b" <| (rotate.solved ['d';'c';'b';'a'] = false)
printfn "solved branch 2a : solved ['b';'d';'a';'c'] : %5b" <| (rotate.solved ['d';'c';'b';'a'] = false)





