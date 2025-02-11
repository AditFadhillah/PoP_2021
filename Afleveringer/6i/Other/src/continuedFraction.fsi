module continuedFraction

/// <summary> Converting a list with integer elements to a floating point number </summary>
/// <example> The call <c>cfrac2float [3;4;12;4]</c> returns <c>3.245</c>. </example>
/// <param name="lst"> A list with integer elements </param>
/// <param name="x"> The first element of the list </param>
/// <param name="xs"> The next element after the first </param>
/// <returns> The function returns a floating point number </return> 
val cfrac2float : int list -> float

/// <summary> Converting a floating point number to a c </summary>
/// <remarks> The two functions are interchangeable, which means that <c>cfrac2float(floatcfrac (3.245))</c> returns <c>3.245</c> </remarks>
/// <remarks> And <c>floatcfrac(cfrac2float [3;4;12;4])</c> returns <c>[3;4;12;4]</c> </remarks>
/// <example> The call <c>floatcfrac 3.245</c> returns <c>[3;4;12;4]</c>. </example>
/// <param name="x"> A floating point number </param>
/// <param name="qi"> <c>qi</c> has the value <c>int(floor(x))<c> </param>
/// <param name="ri"> <c>ri</c> has the value <c>float(x - float(qi))</c> </param>
/// <param name="xii"> <c>xii</c> has the value <c>(1.0/ri)</c> </param>
/// <returns> The function returns a list with integer elements </return> 
val float2cfrac : float -> int list
