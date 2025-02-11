
///<summary> Funktionen isTable kontrollere om listen mindst har en element og at alle elementerne er lige lange </summary>
///<param name="llst"> inputtet er en liste, som vi skal undersøge om det er en liste </param>
///<returns> Returnerer en boolean værdi, returnerer true hvis listen mindst har en element og at alle de indre lister  er lige lange </returns>


let isTable (llst: 'a list list) : bool = // 'a list list betyder at elementerne i listen er lister, funktionen skal så give en boolean værdi
   if llst.IsEmpty then // tjekker om listen er tom eller ej, hvis den er returnerer false
      false
   else if List.exists (fun (x:'a list) -> x.IsEmpty) llst then // tjekker om der findes en tom indre liste, hvis der gøre returnerer false 
      false
   else
      let list_1 = List.length (List.head llst) // længden af den første element defineres som list_1
      List.forall (fun x -> List.length x = list_1) llst // tjekker om længden af alle elementer er lige så langt som líst_1, hvis ja returnerer true


printfn "%A" (isTable  [[1]])


///<summary> Funktionen firstColumn samler de første elementer fra de indre lister, og laver en ny liste ud fra dem </summary>
///<param name="llst"> inputtet er en liste </param>
///<returns> Returnerer en liste der består af de første elementer fra de indre lister </returns>


let firstColumn (llst: 'a list list) : 'a list  = // en liste med indre lister bliver til en liste med integer elementer
   if llst.IsEmpty then // tjekker om listen er tom eller ej, hvis den er returnerer []
      []
   else if List.exists (fun (x:'a list) ->  x.IsEmpty) llst  then // tjekker om der findes en tom indre liste, hvis der gøre returnerer []
      []
   else  
      List.map (fun (x: 'a list) -> x.Head) llst // en funktion der samler de første elementer fra de indre lister.

printfn "%A" (firstColumn  [[1;2];[2;3]])


///<summary> Funktionen dropFirstColumn fjerner de første elementer fra de indre lister, og laver en ny liste ud fra det </summary>
///<param name="llst"> inputtet er en liste </param>
///<returns> Returnerer en liste der består af de indre lister uden deres første elementer </returns>

let dropFirstColumn (llst: 'a list list) : 'a list list  = // liste med indre lister 
   if llst.IsEmpty then
      []
   else if List.exists (fun (x:'a list) ->  x.IsEmpty) llst  then
      []
   else if List.exists (fun (x:'a list) ->  x.Length = 1) llst  then // tjekker om der er en indre liste med kun en element 
      []
   else
      List.map (fun (x: 'a list) -> x.Tail) llst // en funktion der fjerner de første elementer fra de indre lister

printfn "%A" (dropFirstColumn  [[1];[2;3]])



///<summary>Funktionen transposeLstLst transponere alle ellementer i en liste af lister.</summary>
///<param name="llst">Det indput vi giver til funktionen den skal transponere</param>
///<param name="newlst og oldlst">De to lister vi arbejder med, oldlst er den oprindelige liste, og newlst er den liste vi genererer.</param>
///<returns>Den returnere den transponerede liste.</returns>



let transposeLstLst (llst: 'a list list) : 'a list list = 
   if llst.IsEmpty then
      []
   else if List.exists (fun (x:'a list) ->  x.IsEmpty) llst  then
      []
   else   
      let mutable newlst = [[]]
      let mutable oldlst = llst
      let  n = List.length (List.head llst)
      for i = 0 to (List.length (List.head llst))-1 do
         newlst <- (newlst @ ([firstColumn oldlst]))
         oldlst <- dropFirstColumn oldlst
      List.tail newlst


printfn "%A" (transposeLstLst  [[]; [3;4;5]; [4;5;6]])





(*
let list (llst: 'a list list) : 'a list =
   List.map (fun x -> List.head) llst

printfn "%A" (list  [[-1;4;5]; [2;3]])
*)

(*
let lst = [3.0; 4.0]
printfn "%d" (lst.Length)
*)

(*
let dropfirstColumn (llst: 'a list list) : 'a list list  =
   if llst.[0].IsEmpty || llst.[1].IsEmpty then
    []
   else
    List.map List.tail llst.[0..]
    //let x = List.tail llst.[0] // de første elementer i elementerne [0] og [1] fjernes, og de nye elementer defineres som x og v
    //let v = List.tail llst.[1]
    //[x;v]


printfn "%A" (dropfirstColumn [[1;3;4]; [3;4;3]])
*)



