For køre cat.fsx og tac.fsx skal vi:
- Tilgå mappen hvori filerne ligger fra terminalen.
- Bruge komandoen "fsharpc -a readNWrite.fs" til at laver en dell fil i samme mappe
- Herefter kan vi køre biblotekket med cat.fsx og tac.fsx med komandoen: "
fsharpc -r readNWrite.dll cat.fsx". der er nu oprettet en "cat.exe" i mappen (samme for tac.fsx)
- Herefter kan vi bruge mono og køre cat.exe men an tekstfil. Eksempelvis kan vi bruge en fil med teksten "hello" og kalde den test.txt. Denne kan vi så køre med komandoen: "mono cat.exe test.txt" og den vil printe Some "hello" i terminalen.
- Havde vi brugt "tac.fsx" ville den have printet "Some "olleh".

for at køre countlinks.fsx:
- Først tilgåes mappen fra terminalen.
- Derefter bruger vi komandoen "fsharpc countLinks.fsx" som laver programmet countLinks.exe.
- Herefter bruger vi mono og en url: "mono countLinks.exe https://www.cafeen.org"
- Vi får outputtet: "4" i vores terminal, som antalet af links til andre hjemmesider på cafeens hjemmeside.  


