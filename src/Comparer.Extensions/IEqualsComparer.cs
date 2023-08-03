namespace Comparer.Extensions
{
  public interface IEqualsComparer
  {
    bool EqualTo(object? lhs, object? rhs);
  }
}