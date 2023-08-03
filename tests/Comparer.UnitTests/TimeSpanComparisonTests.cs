namespace Comparer.UnitTests
{
  using System;

  public class TimeSpanComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 0), true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0), true);
      WhenGreaterThanOrEqual(new TimeSpan(2, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), true);
      WhenLessThanOrEqual(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 0), false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0), false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(new TimeSpan(2, 0, 0), new TimeSpan(0, 0, 0), false);
    }
  }
}