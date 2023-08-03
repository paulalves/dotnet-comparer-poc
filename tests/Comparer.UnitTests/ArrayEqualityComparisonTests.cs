namespace Comparer.UnitTests
{
  using Xunit;

  public class ArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "c" });
    }
  }
}