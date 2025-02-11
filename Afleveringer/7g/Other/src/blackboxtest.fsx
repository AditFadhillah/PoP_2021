//Black-box test of create
//For n = (2..5), n > 5 og n < 2:
printfn "%A" "Black-box - create"
printfn "%5b: n = 2u )" (rotate.create 2u = ['a'..'d'])
printfn "%5b: n = 3u  )" (rotate.create 3u = ['a'..'i'])
printfn "%5b: n = 4u )" (rotate.create 4u = ['a'..'p']) 
printfn "%5b: n = 5u )" (rotate.create 5u = ['a'..'y'])
printfn "%5b: n = 10u)" (rotate.create 10u = ['a'..'y'])
printfn "%5b: n = 1u)" (rotate.create 1u = ['a'..'d'])
printfn "\n"

//Black-box test of board2Str
//:The four boards
printfn "%A" "Black-box - board2Str"
printfn "%5b: ['a'..'d']" (rotate.board2Str ['a'..'d'] = "\na b \nc d \n")
printfn "%5b: ['a'..'i']" (rotate.board2Str ['a'..'i'] = "\na b c \nd e f \ng h i \n")
printfn "%5b: ['a'..'p']" (rotate.board2Str ['a'..'p'] = "\na b c d \ne f g h \ni j k l \nm n o p \n") 
printfn "%5b: ['a'..'y']" (rotate.board2Str ['a'..'y'] = "\na b c d e \nf g h i j \nk l m n o \np q r s t \nu v w x y \n")
printfn "\n"


//Black-box test of validRotation
//Valid and invalid positions, shown by true or false, of the four boards:
printfn "%A" "Black-box - validRotation"
printfn "%5b: ['a'..'d'] = true" (rotate.validRotation ['a'..'d'] 0 = true )
printfn "%5b: ['a'..'d'] = false" (rotate.validRotation ['a'..'d'] 2 = false )
printfn "%5b: ['a'..'d'] = false" (rotate.validRotation ['a'..'d'] 3 = false )
printfn "%5b: ['a'..'d'] = false" (rotate.validRotation ['a'..'d'] 4 = false )
printfn "%5b: ['a'..'i'] = true" (rotate.validRotation ['a'..'i'] 3 = true )
printfn "%5b: ['a'..'i'] = true" (rotate.validRotation ['a'..'i'] 4 = true )
printfn "%5b: ['a'..'i'] = false" (rotate.validRotation ['a'..'i'] 6 = false )
printfn "%5b: ['a'..'i'] = false" (rotate.validRotation ['a'..'i'] 7 = false )
printfn "%5b: ['a'..'p'] = false" (rotate.validRotation ['a'..'p'] 3 = false ) 
printfn "%5b: ['a'..'p'] = true" (rotate.validRotation ['a'..'p'] 4 = true )
printfn "%5b: ['a'..'y'] = true " (rotate.validRotation ['a'..'y'] 7 = true )
printfn "%5b: ['a'..'y'] = false" (rotate.validRotation ['a'..'y'] 14 = false)
printfn "\n"

//Black-box test of rotate
//Valid and invalid positions, shown by a rotation, of the four boards:
printfn "%A" "Black-box - rotate"
printfn "%5b: ['a'..'d'] 2 " (rotate.rotate ['a'..'d'] 2 = ['a'; 'b'; 'c'; 'd'])
printfn "%5b: ['a'..'d'] 1 " (rotate.rotate ['a'..'d'] 1 = ['c'; 'a'; 'd'; 'b'])
printfn "%5b: ['a'..'i'] 2 " (rotate.rotate ['a'..'i'] 2 = ['a'; 'e'; 'b'; 'd'; 'f'; 'c'; 'g'; 'h'; 'i']) 
printfn "%5b: ['a'..'i'] 3 " (rotate.rotate ['a'..'i'] 3 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "%5b: ['a'..'i'] 7 " (rotate.rotate ['a'..'i'] 7 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "%5b: ['a'..'i'] 8 " (rotate.rotate ['a'..'i'] 8 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'])
printfn "%5b: ['a'..'p'] 7 " (rotate.rotate ['a'..'p'] 7 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'k'; 'g'; 'i'; 'j'; 'l'; 'h'; 'm'; 'n'; 'o'; 'p'])
printfn "%5b: ['a'..'p'] 16 " (rotate.rotate ['a'..'p'] 16 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'; 'j'; 'k'; 'l'; 'm'; 'n'; 'o'; 'p'])
printfn "%5b: ['a'..'y'] 25  " (rotate.rotate ['a'..'y'] 25 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'; 'j'; 'k'; 'l'; 'm'; 'n'; 'o'; 'p';
 'q'; 'r'; 's'; 't'; 'u'; 'v'; 'w'; 'x'; 'y'])
printfn "%5b: ['a'..'y'] 19 " (rotate.rotate ['a'..'y'] 19 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'; 'j'; 'k'; 'l'; 'm'; 'n'; 'o'; 'p';
 'q'; 'r'; 'x'; 's'; 'u'; 'v'; 'w'; 'y'; 't']) 
printfn "\n"

//Black-box test of scramble
//Small and large uints for "scrambeling" of all four boards:
printfn "%A" "Black-box - scramble"
printfn "%5b: ['a'..'d'] 4u" (rotate.scramble ['a'..'d'] 4u = ['a'; 'b'; 'c'; 'd'])
printfn "%5b: ['a'..'d'] 3u" (rotate.scramble ['a'..'d'] 3u = ['b'; 'd'; 'a'; 'c'])
printfn "%5b: ['a'..'d'] 199u" (rotate.scramble ['a'..'d'] 199u = ['b'; 'd'; 'a'; 'c'])
printfn "%5b: ['a'..'i'] 6u" (rotate.scramble ['a'..'i'] 6u <> ['a'..'i'])
printfn "%5b: ['a'..'i'] 155u" (rotate.scramble ['a'..'i'] 155u <> ['a'..'i']) 
printfn "%5b: ['a'..'p'] 3u" (rotate.scramble ['a'..'p'] 3u <> ['a'..'p'])
printfn "%5b: ['a'..'p'] 180u" (rotate.scramble['a'..'p'] 180u <> ['a'..'p'])
printfn "%5b: ['a'..'y'] 9u" (rotate.scramble['a'..'y'] 9u <> ['a'..'y'])
printfn "%5b: ['a'..'y'] 700u" (rotate.scramble['a'..'y'] 700u <> ['a'..'y'])
printfn "\n"

//Black-box test of solved
//Solved and unsolved board for all four types of boards:
//The function solve uses "create" so we wont have an empty list. 
//Therefore we will only test with "legal" lists:
printfn "%A" "Black-box - solve"
printfn "%5b: ['a'..'d']" (rotate.solved ['a'..'d'] = true )
printfn "%5b: " (rotate.solved ['b'; 'd'; 'a'; 'c'] = false )
printfn "%5b: ['a'..'i']" (rotate.solved ['a'..'i'] = true )
printfn "%5b: " (rotate.solved ['b'; 'c'; 'g'; 'a'; 'd'; 'h'; 'e'; 'i'; 'f'] = false )
printfn "%5b: ['a'..'p']" (rotate.solved ['a'..'p'] = true ) 
printfn "%5b: " (rotate.solved ['m'; 'p'; 'a'; 'f'; 'n'; 'b'; 'c'; 'i'; 'o'; 'g'; 'h'; 'e'; 'd'; 'k'; 'l'; 'j'] = false )
printfn "%5b: ['a'..'y']" (rotate.solved ['a'..'y'] = true )
printfn "%5b: " (rotate.solved ['o'; 'r'; 'e'; 'p'; 't'; 'm'; 'j'; 'l'; 'b'; 'w'; 'c'; 'n'; 'y'; 's'; 'f'; 'x';
 'd'; 'a'; 'g'; 'h'; 'k'; 'i'; 'v'; 'u'; 'q'] = false )
printfn "\n"