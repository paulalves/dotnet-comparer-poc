namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

  public class StronglyTypedObjectThatImplementsComparerTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new Entity { Id = 1 };
      var rhs = new Entity { Id = 1 };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new Entity { Id = 1 };
      var rhs = new Entity { Id = 2 };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
    
    private class Entity : IEqualityComparer<Entity>
    {
      public int Id { get; set; }

      public bool Equals(Entity x, Entity y)
      {
        if (ReferenceEquals(x, y))
        {
          return true;
        }

        if (ReferenceEquals(x, null))
        {
          return false;
        }

        if (ReferenceEquals(y, null))
        {
          return false;
        }

        if (x.GetType() != y.GetType())
        {
          return false;
        }

        return x.Id == y.Id;
      }

      public int GetHashCode(Entity obj)
      {
        return obj.Id.GetHashCode();
      }
    }
  }
}