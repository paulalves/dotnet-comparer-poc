namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

  public class HashSetEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "c" });
    }
  }
}