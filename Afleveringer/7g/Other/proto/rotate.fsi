module rotate

type Board = char list 
type Position = int

/// <summary> Funktionen (create) laver en (char list) med (int n * int n) elementer. (Char list) kan længst være ['a'..'y'] </summary>
/// <example> Kaldet <c>create 4u</c> returnere <c>['a'..'p']</c>. </example>
/// <param name="n"> en udefineret 32-bit integer </param>
/// <returns> Funktionen returnere en (char list) </return> 
val create : uint -> Board

/// <summary> Funktionen (board2str) laver en string som er sat op så den er (int n) lang og (int n) bred </summary>
/// <example> Kaldet <c>board2str ['a'..'p']</c> returnere <c> a  b  c  d </c>. </example>
/// <example>                                              <c> e  f  g  h </c>. </example>
/// <example>                                              <c> i  j  k  l </c>. </example>
/// <example>                                              <c> m  n  o  p </c>. </example>
/// <param name="b"> en (char list) som kan længst være ['a'..'y']</param>
/// <param name="n"> kvadratroden af længden af (b) som integer </param>
/// <param name="helper"> en funktion der konvertere (char list) til (string) som laver en ny linje, for hver (n)-te elementer </param>
/// <returns> Funktionen returnerer en string som er sat op som en (n * n) kvadrat  </return> 
val board2Str : Board -> string

/// <summary> Funktionen (validRotation) tester om det (Position) man vælger er gyldigt for at blive roteret </summary>
/// <example> Kaldet <c>validRotation 4u 3 </c> returnerer <c>false</c>. </example>
/// <example> Kaldet <c>validRotation 4u 2 </c> returnerer <c>false</c>. </example>
/// <param name="b"> en (char list) som kan længst være ['a'..'y'] </param>
/// <param name="p"> en 0-indekseret integer, som svarer til elementerne i (b)  </param
/// <param name="n"> kvadratroden af længden af (b) som integer </param>
/// <returns> funktionen returnerer (false), hvis (p) er et nummer fra aller højre kolonne og nedeste række, ellers returnerer den (true)  </return> 
val validRotation : Board -> Position -> bool

/// <summary> Converting a list with integer elements to a floating point number </summary>
/// <example> Kaldet <c>rotate 2u 0 </c> returnere <c>['c'; 'a'; 'd'; 'b']</c>. </example>
/// <param name="b"> en (char list) </param>
/// <param name="p"> en integer, som svarer til elementernes pladser i (b) </param>
/// <param name="n"> kvadratroden af længden af (b) som integer </param>
/// <param name="o"> en integer, som laver (p) om til en 1-indeksering </param>
/// <param name="validRotation"> tester om (p) er gyldigt for at blive roteret </param>
/// <returns> Funktionen returnerer et nyt (char list)</return> 
val rotate : Board -> Position -> Board

/// <summary> Funktionen blander rækkefølge af elementerne i (Board) </summary>
/// <example> Kaldet <c>scramble 2u 2</c> returnerer <c>['c'; 'b'; 'd'; 'a']</c>. </example>
/// <param name="b"> en (char list) </param>
/// <param name="m"> en udefineret integer </param>
/// <param name="rnd"> en funktion som finder et tilfældigt tal mellem 0 til (m) </param>
/// <returns> Funktionen returnerer en (char list) som er blevet blandet, sådan så 4 tilfældige elementer blev blandet en gang, det fortsætter så (m) gange  </return> 
val scramble : Board -> uint -> Board

/// <summary> Funktionen (solved) tjekker om spillet er løst eller ej </summary>
/// <example> Kaldet <c>solved ['a'; 'b'; 'c'; 'd']</c> returns <c>true</c>. </example>
/// <example> Kaldet <c>solved ['c'; 'a'; 'd'; 'b']</c> returns <c>false</c>. </example>
/// <param name="b"> en (char list) som kan længst være ['a'..'y'] </param>)
/// <param name="n"> kvadratroden af længden af (b) som integer </param>
/// <param name="create"> en funktion som laver en (char list) med (int n * int n) elementer. (char list) kan længst være ['a'..'y'] </param>
/// <returns> Funktionen returnerer (true) hvis (char list) fra (b) er det samme som (char list) fra (create n), ellers vil det returnerer (false) </return> 
val solved : Board -> bool