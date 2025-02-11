/// a)
///<summary> Funktionen transposeArr transponerer en multidimensionel array, eller en array af arrays </summary>
///<param name="oldarr"> inputtet er en liste som man konverterer til en multidimensionel array </param>
///<returns> Returnerer oldarr som et nyt transponeret multidimensionel array </returns>


let transposeArr (oldarr: 'a [,]) : 'a [,] = 
  Array2D.init (Array2D.length2 oldarr) (Array2D.length1 oldarr) (fun x y -> oldarr.[y,x])

/// b)
printfn "WHITE-BOX - transposeArr"
printfn "%b: Branch 1" (transposeArr (array2D [[1;2;3]; [4;5;6]])=(array2D [[1; 4];[2; 5];[3; 6]]))

/// c)
// Begge funktioner gør det samme, (transponerer et talsæt). 
// Fordelen ved at gøre det med arrays er at man kan gøre koden meget kortere
// En ulempe er dog at man først skal konvertere sit array til et 2D-array med 
// kommandoen array2D.init. En anden grund til at det svært med lister er
// at de ikke er mutable. 

/// d)
// Lister fungere bedst i imperativ programmering, da det er her vi kan bruge 
// b.la loops og funktioner der er vigtige når vi skal redigere i lister da de
// ikke er mutable er vi nødt til at generere nye lister hele tiden. 
// Her er loops nyttige. Arrays er bedst i funktionel programmering da vi her
// kalder funktioner (fun-kommandoen). 