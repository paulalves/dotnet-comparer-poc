namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

  public class DictionaryEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "b" } });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "c" } });
    }
  }
}