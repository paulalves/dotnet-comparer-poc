namespace Comparer.Extensions
{
  using System.Collections.Generic;

  public interface IComparer : IEqualsComparer, System.Collections.IComparer
  {
    bool LessThan(object? lhs, object? rhs);
    bool LessThanOrEqualTo(object? lhs, object? rhs);
    bool GreaterThan(object? lhs, object? rhs);
    bool GreaterThanOrEqualTo(object? lhs, object? rhs);
    int CompareTo(object? lhs, object? rhs);
  }
}