namespace Comparer.UnitTests
{
  public class LongComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2L, 1L, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1L, 2L, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2L, 2L, true);
      WhenGreaterThanOrEqual(3L, 2L, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1L, 2L, true);
      WhenLessThanOrEqual(2L, 2L, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1L, 2L, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2L, 1L, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1L, 3L, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    {
      WhenLessThanOrEqual(3L, 1L, false);
    }
  }
}