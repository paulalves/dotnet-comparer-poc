namespace Comparer.UnitTests
{
  using Xunit;

  public class CharArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'b' });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'c' });
    }
  }
}