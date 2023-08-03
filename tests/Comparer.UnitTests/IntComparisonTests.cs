namespace Comparer.UnitTests
{
  public class IntComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2, 1, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1, 2, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2, 2, true);
      WhenGreaterThanOrEqual(3, 2, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1, 2, true);
      WhenLessThanOrEqual(2, 2, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1, 2, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2, 1, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1, 3, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3, 1, false);
    }
  }
}