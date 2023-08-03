namespace Comparer.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Specialized;
  using System.Linq;
  using System.Runtime.CompilerServices;

  public static class TypeExtensions
  {
    private const string ReservedNameForAnonymousObject = "AnonymousType";

    public static bool IsSameAs(this Type type, Type otherType)
    {
      return type == otherType;
    }
    
    public static bool ImplementsEqualityComparer(this Type type)
    {
      return type.Implements(typeof(IEqualityComparer));
    }
    
    public static bool ImplementsComparable(this Type type)
    {
      return type.Implements(typeof(IComparable));
    }
    
    public static bool IsNameValueCollection(this Type type)
    {
      return type.Implements(typeof(NameValueCollection));
    }
    
    public static bool IsAnonymous(this Type type)
    {
      var isCompilerGenerated = Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute));
      
      return isCompilerGenerated && type.Name.Contains(ReservedNameForAnonymousObject);
    }
    
    public static bool ImplementsDictionary(this Type type)
    {
      return type.Implements(typeof(IDictionary));
    }
    
    public static bool ImplementsList(this Type type)
    {
      return type.Implements(typeof(IList));
    }
    
    public static bool ImplementsArray(this Type type)
    {
      return type.IsArray || type.Implements(typeof(Array));
    }

    public static bool ImplementsCollection(this Type type)
    {
      return type.Implements(typeof(ICollection));
    }
    
    public static bool ImplementsEnumerable(this Type type)
    {
      return type.Implements(typeof(IEnumerable));
    }

    public static bool Implements(this Type type, Type implementationType)
    {
      return implementationType.IsAssignableFrom(type);
    } 

    public static bool IsNumeric(this Type type)
    {
      return type.InBetween(lowerBound: TypeCode.SByte, upperBound: TypeCode.Decimal);
    }
    
    public static bool IsCharOrString(this Type type)
    {
      return type.IsIn(typeCodes: new[]
      {
        TypeCode.String, 
        TypeCode.Char
      });
    }
    
    public static bool IsIn(this Type type, params TypeCode[] typeCodes)
    {
      return typeCodes.Contains(Type.GetTypeCode(type));
    }
    
    public static bool InBetween(this Type type, TypeCode lowerBound, TypeCode upperBound)
    {
      return InBetween(type, (int)lowerBound, (int)upperBound);
    }

    public static bool InBetween(this Type type, int lowerBound, int upperBound)
    {
      var typeCodeFlag = (int)Type.GetTypeCode(type);
      
      return typeCodeFlag >= lowerBound && typeCodeFlag <= upperBound;
    }
  }
}