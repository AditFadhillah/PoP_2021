
type weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

//7o1
let dayToNumber weekday : int =
    match weekday with
     | Monday -> 1
     | Tuesday -> 2
     | Wednesday -> 3
     | Thursday -> 4
     | Friday -> 5
     | Saturday -> 6
     | Sunday -> 7

printfn "%A" (dayToNumber Monday)

//7o2
let nextDay weekday : weekday =
    match weekday with
     | Monday -> Tuesday
     | Tuesday -> Wednesday
     | Wednesday -> Thursday
     | Thursday -> Friday
     | Friday -> Saturday
     | Saturday -> Sunday
     | Sunday -> Monday

printfn "%A" (nextDay Monday)

//7o3
(*let numberToDay (n : int) : weekday option =
    type weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
    match n with
     | m when m < 0 -> None
     | m when m < 8 -> Some(weekday) 
     | m when m > 7 -> None

    match n with
     | 1 -> Some(Monday)
     | 2 -> Some(Tuesday)
     | 3 -> Some(Wednesday)
     | 4 -> Some(Thursday)
     | 5 -> Some(Friday)
     | 6 -> Some(Saturday)
     | 7 -> Some(Sunday)
     | _ -> None
*)

//printfn "%A" (numberToDay 1)

//7o4
type suit = Hearts | Diamonds | Clubs | Spades 

type rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

type card = rank * suit

let succSuit suit : suit option =
    match suit with
     | Hearts -> Some(Diamonds)
     | Diamonds -> Some(Clubs)
     | Clubs -> Some(Spades)
     | Spades -> None

printfn "%A" (succSuit Hearts)
printfn "%A" (succSuit Spades)

//7o5
let succRank rank : rank option =
    match rank with
     | Two -> Some(Three)
     | Three -> Some(Four)
     | Four -> Some(Five)
     | Five -> Some(Six)
     | Six -> Some(Seven)
     | Seven -> Some(Eight)
     | Eight -> Some(Nine)
     | Nine -> Some(Ten)
     | Ten -> Some(Jack)
     | Jack -> Some(Queen)
     | Queen -> Some(King)
     | King -> Some(Ace)
     | Ace -> None

printfn "%A" (succRank Ten)
printfn "%A" (succRank Ace)

//7o6
let succCard (c: card) : card option =
    match (succRank(fst c), succSuit(snd c)) with
     | (Some x, _) -> Some(x, snd c)
     | (None, Some x) -> Some(Two, x)
     | _ -> None

printfn "%A" <| succCard (Ace, Spades)

//7o7
(*
let helper (c: card option): card =
    match c with
     | Some x -> x
     | None -> (Ace, Spades)

let rec listHelper (c: card) : card List =
    if c = (Ace, Spades) then
        [(Ace, Spades)]
    else
       c :: listHelper(helper(succCard (c)))

let initDeck unit : card List =
    listHelper (Two, Hearts)

*)

let initDeck unit : card List =
    let rec helper card : card list =
        match succCard card with
        | None -> [card]
        | Some newCard -> card :: helper newCard
    helper (Two, Hearts)

printfn "%A" <| initDeck ()

//7o8
let sameRank (a:card) (b:card) : bool =
    match (a,b) with
     | (a,b) when (fst a) = (fst b) -> true
     | _ -> false

printfn "%A" <| sameRank (Two, Hearts) (Two, Diamonds)


//7o9
let sameSuit (a:card) (b:card) : bool =
    match (a,b) with
     | (a,b) when (snd a) = (snd b) -> true
     | _ -> false

printfn "%A" <| sameSuit (Ace, Spades) (Two, Spades)

//7o10
let highCard (a:card) (b:card) : card =
    match (a, b) with
     | (a, b) when (fst a) >= (fst b) -> a
     | _ -> b 

printfn "%A" <| highCard (Two, Hearts) (Two, Spades)

//7o11
let safeDivOption (a:int) (b:int) : int option =
    match (a, b) with
     | (a, b) when b = 0 -> None
     | (a, b) -> Some(a/b) 

printfn "%A" <| safeDivOption (12) (2)

//7o12
type ('a, 'b) result = Ok of 'a | Err of 'b

let safeDivResult (a:int) (b:int) : result< int, string > =
    match (a, b) with
     | (a, b) when b = 0 -> Err "Divide by zero"
     | (a, b) -> Ok (a/b) 

printfn "%A" <| safeDivResult (12) (2)

//7o13
type expr = Const of int | Add of expr * expr | Mul of expr * expr

let rev eval (x: espr) : int =
    
