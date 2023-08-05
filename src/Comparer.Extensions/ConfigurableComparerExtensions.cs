namespace Comparer.Extensions
{
  public static class ConfigurableComparerExtensions
  {
    public static bool LessThan(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.LessThan(lhs, rhs);
    }
    
    public static bool LessThanOrEqualTo(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.LessThanOrEqualTo(lhs, rhs);
    }
    
    public static bool GreaterThan(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.GreaterThan(lhs, rhs);
    }
    
    public static bool GreaterThanOrEqualTo(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.GreaterThanOrEqualTo(lhs, rhs);
    }
    
    public static bool EqualTo(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.EqualTo(lhs, rhs);
    }
    
    public static int CompareTo(this object? lhs, object? rhs, AnyComparerOptions options)
    {
      var comparer = new AnyComparer(options);
      return comparer.CompareTo(lhs, rhs);
    }
  }
}