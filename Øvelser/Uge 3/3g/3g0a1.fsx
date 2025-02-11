//Opgave a

/// Vi laver en funktion som regner summen af en heltal, ved hjælp af en tæller værdi, en lokal variabel og en while-løkke

printfn "Insert an integer to find its sum" //her printer scripten en tekst på terminalen som spørger brugeren om en heltal for at finde dens sum.
let n = int(System.Console.ReadLine()) //her er scripten der tillader brugeren til at taste en heltal ind og trykke enter for at bekræfte tallet. 

let sum (n: int) : int = //her defineres sum som en funktion der opereres med heltal
  let mutable i = 0 //i erklæres som en variabel som kan ændre dens værdi, men at den nu blev tildelt en værdi 0
  let mutable s = 0 //det samme gøres med variablen s
  while i < n do //den her while-løkke tjekker om i er mindre en n, før den går videre ind i løkken
   i <- i + 1 //i ændres med 1, det kan gøres fordi i er en mutable variabel, altså en variabel der kan ændre dens værdi
   s <- i + s //s ændres med den ny i værdi, s er også en mutable variabel
  s //når i ikke længere mindre end n, så skal funktionen give s

do printfn "%A" (sum n) //her printer scripten funktionen sum der regner efter værdien n