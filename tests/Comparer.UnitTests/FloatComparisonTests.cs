namespace Comparer.UnitTests
{
  public class FloatComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2.0f, 1.0f, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1.0f, 2.0f, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2.0f, 2.0f, true);
      WhenGreaterThanOrEqual(3.0f, 2.0f, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1.0f, 2.0f, true);
      WhenLessThanOrEqual(2.0f, 2.0f, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1.0f, 2.0f, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2.0f, 1.0f, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1.0f, 3.0f, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3.0f, 1.0f, false);
    }
  }
}