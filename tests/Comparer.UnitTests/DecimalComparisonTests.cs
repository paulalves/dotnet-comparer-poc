namespace Comparer.UnitTests
{
  public class DecimalComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2.0m, 1.0m, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1.0m, 2.0m, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2.0m, 2.0m, true);
      WhenGreaterThanOrEqual(3.0m, 2.0m, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1.0m, 2.0m, true);
      WhenLessThanOrEqual(2.0m, 2.0m, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1.0m, 2.0m, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2.0m, 1.0m, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1.0m, 3.0m, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3.0m, 1.0m, false);
    }
  }
}