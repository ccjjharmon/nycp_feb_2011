#Rules For Framework Equality Checking

1. Is it a class (reference type)
    * Does the type implement IEquatable<T> for itself - use it
    * Does it override Equals - use it
    * Reference equality check

2. Is it a value type (struct)
    * Does it override Equals - use it
    * Reflective field by field equality check



