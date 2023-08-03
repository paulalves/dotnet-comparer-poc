namespace Comparer.UnitTests
{
  using Microsoft.VisualBasic;

  using Xunit;

  public class CollectionEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new Collection { 1, 2, 3 };
      var rhs = new Collection { 1, 2, 3 };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new Collection { 1, 2, 3 }; 
      var rhs = new Collection { 1, 2, 4 };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
}