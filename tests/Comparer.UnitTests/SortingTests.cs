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
      enumerable.SortAsc().Should().BeEquivalentTo(new object[]
      {
        new [] { 1, 2 },
        2, 4, 5, 6
      });
    }

    [Fact]
    public static void SortDesc()
    {
      var enumerable = new object[] { 4, 5, 3, 2, new object[] { 6, 4 } };
      enumerable.SortAsc().Should().BeEquivalentTo(new object[]
      {
        new [] { 6, 4 },
        5, 4, 3, 2
      });
    }
  }
}