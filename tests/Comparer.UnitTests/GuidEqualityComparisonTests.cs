namespace Comparer.UnitTests
{
  using System;

  using Xunit;

  public class GuidEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"));
    }
  }
}