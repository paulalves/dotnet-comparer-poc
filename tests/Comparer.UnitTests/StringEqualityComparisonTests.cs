namespace Comparer.UnitTests
{
  using Xunit;

  public class StringEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal("abc", "abc");
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal("a", "b");
    }
  }
}