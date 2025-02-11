/// A 2 dimensional vector library.
/// Vectors are represented as pairs of floats
module vec2d

/// <summary> The length of a vector. E.g., len (6.0,8.0) = 10.0 </summary>
/// <example> The call <c>len (6.0,8.0)</c> returns <c>10.0</c>. </example>
/// <param name="v"> A vector shown as two float values in a tuple. </param>
/// <returns> The length of a vector as a float </return> 
val len : float * float -> float

/// <summary> The angle of a vector, given as radian. E.g., ang (6.0,8.0) = 0.6435011088 </summary>
/// <example> The call <c>ang (6.0,8.0)</c> returns <c>0.6435011088</c>. </example>
/// <param name="v"> A vector shown as two float values in a tuple. </param>
/// <returns> The angle of a vector, given as radian and as a float </return> 
val ang : float * float -> float

/// <summary> Addition of two vectors. E.g., add (6.0,8.0) (8.0,6.0) = (14.0,14.0) </summary>
/// <example> The call <c>add (6.0,8.0) (8.0,6.0)</c> returns <c>(14.0,14.0)</c>. </example>
/// <param name="v1"> A vector shown as two float values in a tuple. </param>
/// <param name="v2"> A vector shown as two float values in a tuple. </param>
/// <returns> A new vector that was the result of addition of two vectors shown as two float values in a tuple </return> 
val add : float * float -> float * float -> float * float