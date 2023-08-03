namespace Comparer.UnitTests
{
  using System.Collections.Specialized;

  using Xunit;

  public class NameValueCollectionEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "b" } };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "c" } };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
}