namespace Comparer.UnitTests
{
  using Comparer.Extensions;
  using FluentAssertions;
  using Xunit;

  public class BoxedComparerTests
  {
    [Theory]
    [MemberData(nameof(GetEqualScenarios))]
    public void EqualTo(object lhs, object rhs, bool expect)
    {
      BoxedComparer.EqualTo(lhs, rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetLessThanScenarios))]
    public void LessThan(object lhs, object rhs, bool expect)
    {
      BoxedComparer.LessThan(lhs, rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanScenarios))]
    public void GreaterThan(object lhs, object rhs, bool expect)
    {
      BoxedComparer.GreaterThan(lhs, rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanScenarios))]
    [MemberData(nameof(GetEqualScenarios))]
    public void GreaterOrEqualTo(object lhs, object rhs, bool expect)
    {
      BoxedComparer.GreaterThanOrEqualTo(lhs, rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetLessThanScenarios))]
    [MemberData(nameof(GetEqualScenarios))]
    public void LessThanOrEqualTo(object lhs, object rhs, bool expect)
    {
      BoxedComparer.LessThanOrEqualTo(lhs, rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetArrayEqualScenarios))]
    public void ArrayEqual(object lhs, object rhs, bool expect)
    {
      BoxedComparer.EqualTo(lhs, rhs).Should().Be(expect); 
    }
    
    public static IEnumerable<object[]> GetArrayEqualScenarios()
    {
      yield return new object[]
      {
        new [] { "a", "a" },
        new [] { "a", "a" },
        true
      };
      
      yield return new object[]
      {
        new object [] { "a", "c" },
        new object [] { 'a', "c" },
        true
      };
      
      yield return new object[]
      {
        new [] { 1, 1 },
        new [] { 1m, 1 },
        true
      };
      
      yield return new object[]
      {
        new [] { "a", "c" },
        new [] { "a", "b" },
        false
      };
    }
    
    public static IEnumerable<object[]> GetGreaterThanScenarios()
    {
      yield return new object[]
      {
        3, 1, true
      };

      yield return new object[]
      {
        3m, 2, true,
      };
    }

    public static IEnumerable<object[]> GetLessThanScenarios()
    {
      yield return new object[]
      {
        0, 1, true
      };
      
      yield return new object[]
      {
        2, 3, true
      };
      
      yield return new object[]
      {
        2.0m, 3.1m, true
      };
    }

    public static IEnumerable<object[]> GetEqualScenarios()
    {
      yield return new object[]
      {
        "a", "a", true
      };
      
      yield return new object[]
      {
        'a', "a", true
      };

      yield return new object[]
      {
        1, 1.0f, true
      };

      yield return new object[]
      {
        new DateTime(1989, 05, 22), new DateTime(1989, 05, 22), true
      };
    }
  }
}