namespace Comparer.UnitTests
{
  using Xunit;

  public class IntEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1, 2);
    }
  }
}