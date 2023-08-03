# dotnet-comparer-poc

A poc to compare two clr objects when we don't know the type at compile time for * whatever * reason.

> Whenever possible work with strongly typed objects in C#. If you can't, this might help you.

The implementation still simple so it's easy to follow and understand.

It supports the following types so far:

- Anonymous objects
- Reference types by value
- Boxed objects
- `String`
- `Int`
- `Double`
- `Long`
- `Byte`
- `Float`
- `Decimal`
- `DateTime`
- `TimeSpan`
- `Guid`
- `Enum`
- `Nullable`
- `Array`
- `ICollection`
- `IEnumerable`
- `IList`
- `IDictionary`
- `IComparable`
- `IEqualityComparer`
- `NameValueCollection`

This implementation also export extension methods such as: 
 
- `EqualTo`
- `CompareTo`
- `GreaterThan`
- `GreaterThanOrEqualTo`
- `LessThan`
- `LessThanOrEqualTo`

Check the tests to see how to use it.