namespace Comparer.UnitTests
{
  using Xunit;

  public class DoubleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1.0, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
}