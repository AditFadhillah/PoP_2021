Hvordan koden oversættes og køres:
- Først går vi ind i mappen hvor 5g0.fsx og 5g1.fsx ligger
- Herefter bruger vi fsharpc komandoen til at oversætte vores fsx filer til exe: "fsharpc 5g0.fsx" (samme gælder for 5g1.fsx)
- Der er nu oprettet en 5g0.exe i mappen som kan køres med mono: "mono 5g0.exe" (samme gælder for 5g1.exe)
- Dernæst printes outputtet for whitebox testne i den givne opgave


Whitebox test af 5g0 (a, b, c, d)


Unit           linje    branch          Condition              Input          Expected output        Comment
isTable          1        1         llst.Head.IsEmpty    
                 2        1a              true                   []                false             Tomt array
                 9        1b              false            [[1;2;3]; [4;5;6]]       true                

firstColum       6        1        llst.[0].IsEmpty ||           
                                   llst.[1].IsEmpty              
                 7        1a              true                   [[]]                []              Tjekker om en af listerne er tom.
                 8        1b              false            [[1;2;3]; [4;5;6]]      [1; 4]                 

dropfirstColum            1        llst.[0].IsEmpty || 
                                   llst.[1].IsEmpty 
                 2        1a              true                   [[]]                []              Tomt array  
                 3        1b              false           [[1;2;3]; [4;5;6]]   [[2; 3]; [5; 6]]


transposeLstLst  1        1           llst.IsEmpty              
                 6        1a             true                    []              LISTEN ER TOM      
                                                                                      []
                 8        1b             false                                                       -> branch 2    
                 9        2      List.exists (fun (x:'a 
                                 list) ->  x.IsEmpty)
                10        2a              true             [[1;2;3]; []]       DER ER MINDST EN 
                                                                               TOM INDRE LISTE
                                                                                      []
                11        2b             false           [[1;2;3]; [4;5;6]]    [[1; 4]; [2; 5]; [3; 7]]
            



Whitebox test af 5g1 transposeArr

Unit           linje    branch          Condition              Input          Expected output        Comment
TransposeArr    12        1       fun x y -> oldarr.[y,x]  [[1;2;3]; [4;5;6]]     [[1; 4]        Hvis ikke de to arrays er 
                                                                                   [2; 5]       lige lange, vil funktionen
                                                                                   [3; 6]]      Array2D.init ikke køre og 
											   der kommer en fejl da vores
											   funktion slet ikke vil mod-
											   tage indputtet. Derfor kan vi 
											   ikke bruge "conditionals" til
											   at lave en "gracefully" fail.
											   Terminalen outputter en 
											   fejlmeddelse om at de to
   											   arrays ikke er lige lange. 

Resultater af whitebox tests:

"White-box - isTable"
true: Branch 1a
true: Branch 1b

"White-box - firstColumn"
true: Branch 1a
true: Branch 1b

"White-box - dropFirstColumn"
true: Branch 1a
true: Branch 1b

"White-box - transposeLstLst"
"LISTEN ER TOM"
true: Branch 1a
"DER ER MINDST EN TOM INDRE LISTE"
true: Branch 2a
true: Branch 2b

WHITE-BOX - transposeArr
true: Branch 1

Vi kan se alle vores tests returnere true, og kan derfor sige at vores funktioner virker som forventet.














