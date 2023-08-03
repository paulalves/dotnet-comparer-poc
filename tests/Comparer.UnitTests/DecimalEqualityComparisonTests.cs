namespace Comparer.UnitTests
{
  using Xunit;

  public class DecimalEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1m, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
}