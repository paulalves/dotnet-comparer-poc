namespace Comparer.UnitTests
{
  public class CharComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan('b', 'a', true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan('a', 'b', true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual('b', 'b', true);
      WhenGreaterThanOrEqual('c', 'b', true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual('a', 'b', true);
      WhenLessThanOrEqual('b', 'b', true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan('a', 'b', false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan('b', 'a', false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual('a', 'c', false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual('c', 'a', false);
    }
  }
}