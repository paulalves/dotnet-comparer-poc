namespace Comparer.UnitTests
{
  using System.Collections;

  using Xunit;

  public class ArrayListEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new ArrayList { 1, 2, 3 };
      var rhs = new ArrayList { 1, 2, 3 };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new ArrayList { 1, 2, 3 }; 
      var rhs = new ArrayList { 1, 2, 4 };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
}