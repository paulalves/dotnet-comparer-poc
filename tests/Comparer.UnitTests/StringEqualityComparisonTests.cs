namespace Comparer.UnitTests
{
  using Xunit;

  public class StringEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal("abc", "abc");
      WhenBothAreEqualInternal(null, "");
      WhenBothAreEqualInternal("", null);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal("a", "b");
      WhenBothAreNotEqualInternal('a', "b");
    }
  }
}