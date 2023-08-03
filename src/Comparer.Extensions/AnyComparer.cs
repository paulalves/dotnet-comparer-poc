// ReSharper disable MergeIntoPattern
// ReSharper disable MergeIntoLogicalPattern
// ReSharper disable MemberCanBePrivate.Global
namespace Comparer.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Specialized;
  using System.Linq;
  using System.Runtime.CompilerServices;

  public class AnyComparer : IComparer
  {
    static AnyComparer()
    {
      Default = new AnyComparer();
    }

    private AnyComparer()
    {
    }
    
    public static IComparer Default { get; }
    
    public bool LessThan(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == -1;
    }

    public bool LessThanOrEqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) <= 0;
    }

    public bool GreaterThan(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == 1;
    }

    public bool GreaterThanOrEqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) >= 0;
    }

    public bool EqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == 0;
    }

    public int CompareTo(object? lhs, object? rhs)
    {
      if (lhs == null || rhs == null)
      {
        return 0; // should return -1?
      }

      var lhsType = lhs.GetType();
      var rhsType = rhs.GetType();

      var typeCodeLhs = Type.GetTypeCode(lhsType);
      var typeCodeRhs = Type.GetTypeCode(rhsType);

      var isTheSameType = typeCodeLhs == typeCodeRhs;
      if (isTheSameType)
      {
        if (typeCodeLhs != TypeCode.Object)
        {
          return Comparer.Default.Compare(lhs, rhs);
        }

        if (Object.ReferenceEquals(lhs, rhs))
        {
          return 0;
        }
        
        if (lhsType.IsAnonymous() && rhsType.IsAnonymous())
        {
          return Compare(lhs, rhs, lhsType, rhsType);
        }

        if (lhs is IComparable lhsComparable)
        {
          return lhsComparable.CompareTo(rhs);
        }

        if (lhsType.IsNameValueCollection() && rhsType.IsNameValueCollection())
        {
          return Compare((NameValueCollection)lhs, (NameValueCollection)rhs);
        }
        
        if (lhsType.ImplementsDictionary() && rhsType.ImplementsDictionary())
        {
          return Compare((IDictionary)lhs, (IDictionary)rhs); 
        }
        
        if (lhsType.ImplementsList() && rhsType.ImplementsList())
        {
          return Compare((IList)lhs, (IList)rhs);
        }

        if (lhsType.ImplementsEnumerable() && rhsType.ImplementsEnumerable())
        {
          return Compare((IEnumerable)lhs, (IEnumerable)rhs); 
        }
        
        if (lhsType.ImplementsCollection() && rhsType.ImplementsCollection())
        {
          return Compare((ICollection)lhs, (ICollection)rhs);
        }
        
        if (lhsType.ImplementsArray() && rhsType.ImplementsArray())
        {
          return Compare((Array)lhs, (Array)rhs);
        }

        return -1;
      }

      if (lhsType.IsNumeric() && rhsType.IsNumeric())
      {
        return Compare(Convert.ToDouble(lhs), Convert.ToDouble(rhs));
      }

      if (!(lhsType.IsCharOrString() && rhsType.IsCharOrString()))
      {
        return -1;
      }

      string lhsString = lhs.ToString()!, rhsString = rhs.ToString()!;

      return StringComparer.InvariantCultureIgnoreCase.Compare(lhsString, rhsString);
    }

    private int Compare(object lhs, object rhs, Type lhsType, Type rhsType)
    {
      var lhsProperties = lhsType.GetProperties();
      var rhsProperties = rhsType.GetProperties();

      if (lhsProperties.Length != rhsProperties.Length)
      {
        return lhsProperties.Length.CompareTo(rhsProperties.Length);
      }

      for (var i = 0; i < lhsProperties.Length; i++)
      {
        var lhsProp = lhsProperties[i];
        var rhsProp = rhsProperties[i];

        var lhsPropValue = lhsProp.GetValue(lhs);
        var rhsPropValue = rhsProp.GetValue(rhs);

        var comparison = CompareTo(lhsPropValue, rhsPropValue);
        if (comparison != 0)
        {
          return comparison;
        }
      }

      return 0;
    }

    private int Compare(IDictionary lhs, IDictionary rhs)
    {
      if (lhs.Count != rhs.Count)
      {
        return lhs.Count.CompareTo(rhs.Count);
      }

      var lhsKeys = lhs.Keys.Cast<object>();
      var rhsKeys = rhs.Keys.Cast<object>();
      
      var keysComparison = Compare(lhsKeys, rhsKeys);
      if (keysComparison != 0)
      {
        return keysComparison;
      }
      
      var lhsValues = lhs.Values.Cast<object>().ToArray();
      var rhsValues = rhs.Values.Cast<object>().ToArray();
      
      return Compare(lhsValues, rhsValues);
    }
   
    private int Compare(IEnumerable lhs, IEnumerable rhs)
    {
      var lhsEnumerator = lhs.GetEnumerator();
      var rhsEnumerator = rhs.GetEnumerator();
      
      while (lhsEnumerator.MoveNext() && rhsEnumerator.MoveNext())
      {
        var lhsElement = lhsEnumerator.Current;
        var rhsElement = rhsEnumerator.Current;

        var comparison = CompareTo(lhsElement, rhsElement);
        if (comparison != 0)
        {
          return comparison;
        }
      }
      return 0; 
    }

    private static int Compare(double lhs, double rhs)
    {
      return Comparer.Default.Compare(lhs, rhs);
    }

    private int Compare(Array lhs, Array rhs)
    {
      if (lhs.Length != rhs.Length)
      {
        return lhs.Length.CompareTo(rhs.Length);
      }

      for (var i = 0; i < lhs.Length; i++)
      {
        var lhsElement = lhs.GetValue(i);
        var rhsElement = rhs.GetValue(i);

        var comparison = CompareTo(lhsElement, rhsElement);
        if (comparison != 0)
        {
          // if they are different, no need to continue
          return comparison;
        }
      }

      // otherwise, they are equal
      return 0;
    }

    private int Compare(NameValueCollection lhs, NameValueCollection rhs)
    {
      var lhsEnumerator = lhs.GetEnumerator();
      var rhsEnumerator = rhs.GetEnumerator();

      while (lhsEnumerator.MoveNext() && rhsEnumerator.MoveNext())
      {
        var lhsKey = lhsEnumerator.Current;
        var rhsKey = rhsEnumerator.Current;
        
        var keyComparison = CompareTo(lhsKey, rhsKey);
        if (keyComparison != 0)
        {
          return keyComparison;
        }
        
        var lhsValue = lhs.Get(lhsKey.ToString()!);
        var rhsValue = rhs.Get(rhsKey.ToString()!);

        if (lhsValue == null && rhsValue == null)
        {
          continue;
        }
        
        var valueComparison = CompareTo(lhsValue, rhsValue);
        if (valueComparison != 0)
        {
          return valueComparison;
        }
      }

      return 0;
    }
    
    private int Compare(ICollection lhs, ICollection rhs)
    {
      return Compare((IEnumerable)lhs, (IEnumerable)rhs);
    }
    
    private int Compare(IList lhs, IList rhs)
    {
      if (lhs.Count != rhs.Count)
      {
        return lhs.Count.CompareTo(rhs.Count);
      }

      for (var index = 0; index < lhs.Count; index++)
      {
        var lhsElement = lhs[index];
        var rhsElement = rhs[index];

        var comparison = CompareTo(lhsElement, rhsElement);
        if (comparison != 0)
        {
          // if they are different, no need to continue
          return comparison;
        }
      }

      // otherwise, they are equal
      return 0;
    }
  }
  
  public static class TypeExtensions
  {
    private const string ReservedNameForAnonymousObject = "AnonymousType";

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