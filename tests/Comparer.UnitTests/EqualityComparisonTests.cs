namespace Comparer.UnitTests
{
  using Comparer.Extensions;

  using FluentAssertions;

  using Xunit;

  public abstract class EqualityComparisonTests
  {
    [Fact]
    public abstract void AreEqual();

    protected void WhenBothAreEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeTrue();
    }
    
    [Fact]
    public abstract void AreNotEqual();
    
    protected void WhenBothAreNotEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeFalse();
    }
  }
}