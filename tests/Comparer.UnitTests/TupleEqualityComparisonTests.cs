namespace Comparer.UnitTests
{
  using System;

  using Xunit;

  public class TupleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "b"));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "c"));
    }
  }
}