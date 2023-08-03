namespace Comparer.Extensions
{
  using Unknown = System.Object;
  
  public abstract class ComparerBase : IComparer
  {
    public bool LessThan(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == -1;
    }

    public abstract int CompareTo(Unknown? lhs, Unknown? rhs);

    public bool LessThanOrEqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) <= 0;
    }

    public bool GreaterThan(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == 1;
    }

    public bool GreaterThanOrEqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) >= 0;
    }

    public bool EqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == 0;
    }
  }
}