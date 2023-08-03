namespace Comparer.UnitTests
{
  public class ByteComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan((byte)2, (byte)1, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan((byte)1, (byte)2, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual((byte)2, (byte)2, true);
      WhenGreaterThanOrEqual((byte)3, (byte)2, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual((byte)1, (byte)2, true);
      WhenLessThanOrEqual((byte)2, (byte)2, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan((byte)1, (byte)2, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan((byte)2, (byte)1, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual((byte)1, (byte)3, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    {
      WhenLessThanOrEqual((byte)3, (byte)1, false);
    }
  }
}