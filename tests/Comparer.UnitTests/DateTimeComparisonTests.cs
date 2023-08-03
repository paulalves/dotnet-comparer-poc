namespace Comparer.UnitTests
{
  using System;

  public class DateTimeComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(new DateTime(2012, 1, 1), new DateTime(2011, 1, 1), true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(new DateTime(2012, 1, 1), new DateTime(2012, 1, 1), true);
      WhenGreaterThanOrEqual(new DateTime(2013, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), true);
      WhenLessThanOrEqual(new DateTime(2012, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(new DateTime(2012, 1, 1), new DateTime(2011, 1, 1), false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(new DateTime(2011, 1, 1), new DateTime(2013, 1, 1), false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(new DateTime(2013, 1, 1), new DateTime(2011, 1, 1), false);
    }
  }
}