Hvordan koden oversættes og køres:
- Først går vi ind i mappen hvor 5g0.fsx og 5g1.fsx ligger
- Herefter bruger vi fsharpc komandoen til at oversætte vores fsx filer til exe: "fsharpc 5g0.fsx" (samme gælder for 5g1.fsx)
- Der er nu oprettet en 5g0.exe i mappen som kan køres med mono: "mono 5g0.exe" (samme gælder for 5g1.exe)
- Dernæst printes outputtet for whitebox testne i den den givne opgave


Whitebox test af 5g0 (a, b, c, d)


+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
| Unit            | Branch | Condition                                          | Input              | Expexted              | Comment     |
|                 |        |                                                    |                    | Input                 |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
| isTable         | 1      | llst.IsEmpty                                       |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1a     | true                                               | []                 | false                 |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1b     | false                                              | [[1;2;3]; [4;5;6]] |                       | -> Branch 2 |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2      | List.exists (fun (x:'a list) -> x.IsEmpty) llst    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2a     | true                                               | [[1;2;3]: []]      | false                 |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2b     | false                                              | [[1;2;3]; [4;5;6]] | true                  |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 |        |                                                    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
| firstColumn     | 1      | llst.IsEmpty                                       |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1a     | true                                               | []                 | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1b     | false                                              | [[1;2;3]; [4;5;6]] |                       | -> Branch 2 |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2      | List.exists (fun (x:'a list) -> x.IsEmpty) llst    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2a     | true                                               | [[1;2;3]: []]      | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2b     | false                                              | [[1;2;3]; [4;5;6]] | [[1; 4]]              |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 |        |                                                    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
| dropFirstColumn | 1      | llst.IsEmpty                                       |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1a     | true                                               | []                 | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1b     | false                                              | [[1;2;3]; [4;5;6]] |                       | -> Branch 2 |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2      | List.exists (fun (x:'a list) -> x.IsEmpty) llst    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2a     | true                                               | [[1;2;3]: []]      | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2b     | false                                              | [[1;2;3]; [4;5;6]] |                       | -> Branch 3 |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 3      | List.exists (fun (x:'a list) -> x.Length = 1) llst |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 3a     | true                                               | [[1;2;3]; [4]]     | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 3b     | false                                              | [[1;2;3]; [4;5;6]] | [[2;3]; [5;6]]        |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 |        |                                                    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
| transposeLstLst | 1      | llst.IsEmpty                                       |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1a     | true                                               | []                 | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 1b     | false                                              | [[1;2;3]; [4;5;6]] |                       | -> Branch 2 |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2      | List.exists (fun (x:'a list) -> x.IsEmpty) llst    |                    |                       |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2a     | true                                               | [[1;2;3]: []]      | []                    |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
|                 | 2b     | false                                              | [[1;2;3]; [4;5;6]] | [[1;4]; [2;5]; [3;6]] |             |
+-----------------+--------+----------------------------------------------------+--------------------+-----------------------+-------------+
            



Whitebox test af 5g1 transposeArr

+--------------+--------+-----------------------------------------------------------------+--------------------+----------+------------------------------------------+
| Unit         | Branch | Condition                                                       | Input              | Expexted | Comment                                  |
|              |        |                                                                 |                    | Input    |                                          |
+--------------+--------+-----------------------------------------------------------------+--------------------+----------+------------------------------------------+
| TransposeArr | 1      | Array2D.init (Array2D.length2 oldarr) (Array2D.length1 oldarr)  | [[1;2;3]; [4;5;6]] | [[1;4]   | Hvis ikke de to arrays er lige lange,    |
|              |        | (fun x y -> oldarr.[y,x])                                       |                    |  [2;5]   | vil funktionn Array2D.init ikke køre og  |
|              |        |                                                                 |                    |  [3;6]]  | der kommer en fejl da vores funktion     |
|              |        |                                                                 |                    |          | slet ikke vil mod- tage indputtet.       |
|              |        |                                                                 |                    |          | Derfor kan vi ikke bruge "conditionals"  |
|              |        |                                                                 |                    |          | til at lave en "gracefully" fail.        |
|              |        |                                                                 |                    |          | Terminalen outputter en fejlmeddelse om  |
|              |        |                                                                 |                    |          | at de to arrays ikke er lige lange.      |
+--------------+--------+-----------------------------------------------------------------+--------------------+----------+------------------------------------------+

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














