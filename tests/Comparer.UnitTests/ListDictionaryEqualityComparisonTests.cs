namespace Comparer.UnitTests
{
  using System.Collections.Specialized;

  using Xunit;

  public class ListDictionaryEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new ListDictionary { { "a", "b" } };
      var rhs = new ListDictionary { { "a", "b" } };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new ListDictionary { { "a", "b" } };
      var rhs = new ListDictionary { { "a", "c" } };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
}