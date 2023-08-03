namespace Comparer.UnitTests
{
  public class DoubleComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2.0, 1.0, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1.0, 2.0, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2.0, 2.0, true);
      WhenGreaterThanOrEqual(3.0, 2.0, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1.0, 2.0, true);
      WhenLessThanOrEqual(2.0, 2.0, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1.0, 2.0, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2.0, 1.0, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1.0, 3.0, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3.0, 1.0, false);
    }
  }
}