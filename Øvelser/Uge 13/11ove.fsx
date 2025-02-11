
//11ove0

// War is a card game for two players using the so-called French-suited deck of cards.
// The deck is initially divided equally between the two players, which is organized as
// a stack of cards. A turn is played by each player showing the top of their stack. The
// player with the highest card wins the hand. Aces are the highest. The won cards are
// placed at the bottom of the winner’s stack. When one player has all the cards, then
// that player wins the game

// Class: 
// War is card game
// Two player using deck of cards
// Deck is devided equally between two players

// Methods:
// Deck organized as a stack of cards
// Player with highest card wins the hand
// Aces are the highest
// The won cards are placed at the bottom of the winner's deck
// When one player has all the cards, they win

//11ove1
type Person (name:string, address:string, tlpNumber:string) =
    member val Name = name with get, set
    member val Address = address with get, set
    member val TlpNumber = tlpNumber with get, set

type Costumer(n, a, t, willing: bool) = 
    inherit Person (n, a, t)
    static let mutable total = 0
    let myID = Costumer.NextID()
    member obj.ID = myID
    static member Total = total
    static member NextID () =
        total <- total + 1
        total
    member this.mailList = willing

let person1 = Costumer ("Jon", "Rævvej, 2", "12341234", true)
let person2 = Costumer ("Kasper", "Nyvej, 22", "43214321", true)
let person3 = Costumer ("Nina", "Brogade, 7", "11112222", false)
let person4 = Costumer ("Gary", "Finhøj, 1", "32425262", false)


printfn "%A" <| person4.Address
printfn "%A" Costumer.Total 

//11ove2

//11ove3
type account (name:string, accNum:string, transac:(string*int) list ) =
    member val Name = name with get, set
    member val AccNum = accNum with get, set    
    member val Transac = transac with get, set    
    member this.add (tA:(string*int) list) = this.Transac <- tA @ transac
    member this.balance = this.Transac.Head

type lastAccountNumber (n, aN, tA) = 
    inherit account (n, aN, tA)
    static let mutable lastAccount = 0
    let myID = lastAccountNumber.NextID()
    member obj.ID = myID
    static member LastAccount = lastAccount
    static member NextID () =
        lastAccount <- lastAccount + 1
        lastAccount

let hum1 = lastAccountNumber ("Jon", "12341234", ([("Mad",25); ("Mad",50); ("Mad",45); ("Tøj",500)]))
let hum2 = lastAccountNumber ("Kasper", "43214321", ([("Mad",25); ("Mad",50); ("Mad",45); ("Tøj",500)]))
let hum3 = lastAccountNumber ("Nina", "11112222", ([("Mad",25); ("Mad",50); ("Mad",45); ("Tøj",500)]))
let hum4 = lastAccountNumber ("Gary", "32425262", ([("Mad",25); ("Mad",50); ("Mad",45); ("Tøj",500)]))

printfn "%A" <| hum1.Transac
hum1.add (["Gave",400])
printfn "%A" <| hum1.Transac
printfn "%A" <| hum1.balance
printfn "%A" lastAccountNumber.LastAccount

//11ove4
// The gregorian calendar consists of dates (day/month/year), with 12 months per year,
// and with months consisting of 28, 29, 30 or 31 days. The years are counted numerically
// with Jesus Christus’ first year being called 1 AD, followed by 2 AD, etc., and
// the year prior is called 1 BC, preceded by 2 BC, etc. Thus, this calendar has no
// year 0, and the traditional time line is . . . , 2 BC, 1 BC, 1 AD, 2 AD, . . . .

//11ove5
// Checkers is a turn-based strategy game for two players. The game is (typically)
// played on an 8   sx 8 checkerboard of alternating dark- and light-colored squares. Each
// player starts with 12 pieces, where player one’s pieces are light, and player two’s
// pieces are dark in color, and the initial position of the pieces is shown in Figure 1.
// Players take turns moving one of their pieces. A player must move a piece if possible,
// and when one player has no more pieces, then that player has lost the game.
// A piece may only move diagonally into an unoccupied adjacent square. If the adjacent
// square contains an opponent’s piece and the square immediately beyond is
// vacant, then the piece jumps over the opponent’s piece and the opponent’s piece is
// removed from the board.

//11ove6

