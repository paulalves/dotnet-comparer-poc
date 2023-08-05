namespace Comparer.UnitTests
{
  using Comparer.Extensions;

  using FluentAssertions;

  using Xunit;

  public class SortingTests
  {
    [Fact]
    public static void SortAsc()
    {
      var enumerable = new object[] { 2, 5, 4, 6, new object[] { 1, 2 } };
      var result = enumerable.SortAsc();
      ((object[])result[0])[0].Should().BeEquivalentTo(1);
      ((object[])result[0])[1].Should().BeEquivalentTo(2);
      result[1].Should().Be(2);
      result[2].Should().Be(4);
      result[3].Should().Be(5);
      result[4].Should().Be(6);
    }

    [Fact]
    public static void SortDesc()
    {
      var enumerable = new object[] { 4, 5, 3, 2, new object[] { 6, 4 } };
      var result = enumerable.SortDesc();
      result[0].Should().Be(5);
      result[1].Should().Be(4);
      result[2].Should().Be(3);
      result[3].Should().Be(2);
      ((object[])result[4])[0].Should().BeEquivalentTo(6);
      ((object[])result[4])[1].Should().BeEquivalentTo(4);
    }
  }
}