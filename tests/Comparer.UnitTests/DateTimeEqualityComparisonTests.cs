namespace Comparer.UnitTests
{
  using System;

  using Xunit;

  public class DateTimeEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 1));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
    }
  }
}