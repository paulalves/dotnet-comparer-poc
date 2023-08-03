namespace Comparer.UnitTests
{
  using Xunit;

  public class ByteArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x2 });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x3 });
    }
  }
}