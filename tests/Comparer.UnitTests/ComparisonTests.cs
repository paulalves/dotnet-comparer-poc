namespace Comparer.UnitTests
{
  using Comparer.Extensions;

  using FluentAssertions;

  using Xunit;

  public abstract class ComparisonTests
  {
    [Fact]
    public abstract void GreaterThan_ShouldBeTrue();
    
    [Fact]
    public abstract void LessThan_ShouldBeTrue();

    [Fact]
    public abstract void GreaterThanOrEqual_ShouldBeTrue();
    
    [Fact]
    public abstract void LessThanOrEqual_ShouldBeTrue();
    
    [Fact]
    public abstract void GreaterThan_ShouldBeFalse();
    
    [Fact]
    public abstract void LessThan_ShouldBeFalse();

    [Fact]
    public abstract void GreaterThanOrEqual_ShouldBeFalse();
    
    [Fact]
    public abstract void LessThanOrEqual_ShouldBeFalse();

    protected virtual void WhenLessThanOrEqual(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.LessThanOrEqualTo(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenGreaterThanOrEqual(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.GreaterThanOrEqualTo(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenLessThan(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.LessThan(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenGreaterThan(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.GreaterThan(lhs, rhs).Should().Be(expectedToBe);
    }
  }
}