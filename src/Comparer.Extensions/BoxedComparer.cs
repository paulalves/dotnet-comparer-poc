// ReSharper disable MergeIntoPattern
// ReSharper disable MergeIntoLogicalPattern
// ReSharper disable MemberCanBePrivate.Global
namespace Comparer.Extensions
{
  using System.Collections;

  public ref struct BoxedComparer
  {
    public static bool LessThan(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == -1;
    }

    public static bool LessThanOrEqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) <= 0;
    }

    public static bool GreaterThan(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == 1;
    }

    public static bool GreaterThanOrEqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) >= 0;
    }

    public static bool EqualTo(object? lhs, object? rhs)
    {
      return CompareTo(lhs, rhs) == 0;
    }

    public static int CompareTo(object? lhs, object? rhs)
    {
      if (lhs == null || rhs == null)
      {
        return -1;
      }

      var lhsType = lhs.GetType();
      var rhsType = rhs.GetType();
      
      var typeCodeLhs = Type.GetTypeCode(lhsType);
      var typeCodeRhs = Type.GetTypeCode(rhsType);

      var lhsTypeFlag = (int)typeCodeLhs;
      var rhsTypeFlag = (int)typeCodeRhs;

      var isTheSameType = lhsTypeFlag == rhsTypeFlag;
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

        if (lhs is IComparable lhsComparable)
        {
          return lhsComparable.CompareTo(rhs);
        }

        if (!lhsType.IsArray || !rhsType.IsArray)
        {
          return 0;
        }
        
        var lhsArray = (Array)lhs;
        var rhsArray = (Array)rhs;

        if (lhsArray.Length != rhsArray.Length)
        {
          return lhsArray.Length.CompareTo(rhsArray.Length);
        }

        for (var i = 0; i < lhsArray.Length; i++)
        {
          var lhsElement = lhsArray.GetValue(i);
          var rhsElement = rhsArray.GetValue(i);

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

      var isNumber = (lhsTypeFlag >= 5 && lhsTypeFlag <= 15) &&
                     (rhsTypeFlag >= 5 && rhsTypeFlag <= 15);
      if (isNumber)
      {
        var lhsAsDouble = Convert.ToDouble(lhs);
        var rhsAsDouble = Convert.ToDouble(rhs);

        return Comparer.Default.Compare(lhsAsDouble, rhsAsDouble);
      }

      var isCharOrString = (lhsTypeFlag == 18 || lhsTypeFlag == 4) &&
                           (rhsTypeFlag == 18 || rhsTypeFlag == 4);

      if (!isCharOrString)
      {
        return -1;
      }
      
      string lhsString = lhs.ToString()!, rhsString = rhs.ToString()!;

      return StringComparer.InvariantCultureIgnoreCase.Compare(lhsString, rhsString);
    }
  }
}