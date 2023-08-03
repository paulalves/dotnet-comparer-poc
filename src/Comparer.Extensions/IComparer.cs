namespace Comparer.Extensions
{
  public interface IComparer : IEqualsComparer
  {
    bool LessThan(object? lhs, object? rhs);
    bool LessThanOrEqualTo(object? lhs, object? rhs);
    bool GreaterThan(object? lhs, object? rhs);
    bool GreaterThanOrEqualTo(object? lhs, object? rhs);
    int CompareTo(object? lhs, object? rhs);
  }
}