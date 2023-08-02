namespace Comparer.Extensions
{
  public static class ComparerExtensions
  {
    public static bool LessThan(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.LessThan(lhs, rhs);
    }
    
    public static bool LessThanOrEqualTo(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.LessThanOrEqualTo(lhs, rhs);
    }
    
    public static bool GreaterThan(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.GreaterThan(lhs, rhs);
    }
    
    public static bool GreaterThanOrEqualTo(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.GreaterThanOrEqualTo(lhs, rhs);
    }
    
    public static bool EqualTo(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.EqualTo(lhs, rhs);
    }

    public static int CompareTo(this object? lhs, object? rhs)
    {
      return AnyComparer.Default.CompareTo(lhs, rhs);
    }
  }
}