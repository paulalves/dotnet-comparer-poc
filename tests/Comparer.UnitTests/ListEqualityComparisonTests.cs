namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

  public class ListEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "c" });
    }
  }
}