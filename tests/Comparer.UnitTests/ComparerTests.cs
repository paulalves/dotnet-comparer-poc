namespace Comparer.UnitTests
{
  using System;
  using System.Collections.Generic;

  using Comparer.Extensions;
  using FluentAssertions;
  using Xunit;

  public class ComparerTests
  {
    [Fact]
    public void AnonymousObjectTest()
    {
      object obj1 = new object[] { 'a', "b" };
      object obj2 = new object[] { 'a', "b" };

      AnyComparer.Default.EqualTo(obj1, obj2).Should().BeTrue();
    }
    
    [Theory]
    [MemberData(nameof(GetEqualScenarios))]
    public void EqualTo(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().Be(expect);
      lhs.EqualTo(rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetLessThanScenarios))]
    public void LessThan(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.LessThan(lhs, rhs).Should().Be(expect);
      lhs.LessThan(rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanScenarios))]
    public void GreaterThan(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.GreaterThan(lhs, rhs).Should().Be(expect);
      lhs.GreaterThan(rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanScenarios))]
    [MemberData(nameof(GetEqualScenarios))]
    public void GreaterOrEqualTo(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.GreaterThanOrEqualTo(lhs, rhs).Should().Be(expect);
      lhs.GreaterThanOrEqualTo(rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetLessThanScenarios))]
    [MemberData(nameof(GetEqualScenarios))]
    public void LessThanOrEqualTo(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.LessThanOrEqualTo(lhs, rhs).Should().Be(expect);
      lhs.LessThanOrEqualTo(rhs).Should().Be(expect);
    }

    [Theory]
    [MemberData(nameof(GetArrayEqualScenarios))]
    public void ArrayEqual(object lhs, object rhs, bool expect)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().Be(expect);
      lhs.EqualTo(rhs).Should().Be(expect);
    }
    
    public static IEnumerable<object[]> GetArrayEqualScenarios()
    {
      // test array containing guids 
      yield return new object[]
      {
        /*lhs*/ new [] { Guid.NewGuid(), Guid.NewGuid() },
        /*rhs*/ new [] { Guid.NewGuid(), Guid.NewGuid() },
        /*expected*/ false
      };
      
      yield return new object[]
      {
        /*lhs*/ new [] { new Guid("00000000-0000-0000-0000-000000000000") },
        /*rhs*/ new [] { new Guid("00000000-0000-0000-0000-000000000000") },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "a" },
        /*rhs*/ new object [] { "a", "a" },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "a" },
        /*rhs*/ new object [] { 'a', 'b' },
        /*expected*/ false
      };
      
      yield return new object[]
      {
        /*lhs*/ new object[] { TestEnum.A, new object [] { TestEnum.B } },
        /*rhs*/ new object[] { TestEnum.A, new object [] { TestEnum.C } },
        /*expected*/ false
      };
      
      yield return new object[]
      {
        /*lhs*/ new object[] { TestEnum.A, new object [] { TestEnum.B } },
        /*rhs*/ new object[] { TestEnum.A, new object [] { TestEnum.B } },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "a" },
        /*rhs*/ new object [] { 'a', "a" },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "c" },
        /*rhs*/ new object [] { 'a', "c" },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new [] { 1, 1 },
        /*rhs*/ new [] { 1m, 1 },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new [] { "a", "c" },
        /*rhs*/ new [] { "a", "b" },
        /*expected*/ false
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "b", new object[] { "c", 'd'} },
        /*rhs*/ new object [] { "a", "b", new object[] { "c", "d"} },
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "b", new object[] { "c", 'd'} },
        /*rhs*/ new object [] { "a", "b", new object[] { "c", "e"} },
        /*expected*/ false
      };
      
      yield return new object[]
      {
        /*lhs*/ new object [] { "a", "b", new object[] { "c", 'd', new object[] { '1' } } },
        /*rhs*/ new object [] { "a", "b", new object[] { "c", "d", new object[] { '2' } } },
        /*expected*/ false
      };
    }
    
    public static IEnumerable<object[]> GetGreaterThanScenarios()
    {
      yield return new object[]
      {
        /*lhs*/ 3, 
        /*rhs*/ 1, 
        /*expected*/ true
      };

      yield return new object[]
      {
        /*lhs*/ 3m, 
        /*rhs*/ 2, 
        /*expected*/ true,
      };
    }

    public static IEnumerable<object[]> GetLessThanScenarios()
    {
      yield return new object[]
      {
        /*lhs*/ 0, 
        /*rhs*/ 1, 
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ 2, 
        /*rhs*/ 3, 
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ 2.0m, 
        /*rhs*/ 3.1m, 
        /*expected*/ true
      };
    }

    public static IEnumerable<object[]> GetEqualScenarios()
    {
      yield return new object[]
      {
        /*lhs*/ TimeSpan.MaxValue,
        /*rhs*/ TimeSpan.MaxValue,
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ TestEnum.A,
        /*rhs*/ TestEnum.A,
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ "a", 
        /*rhs*/ "a", 
        /*expected*/ true
      };
      
      yield return new object[]
      {
        /*lhs*/ 'a', 
        /*rhs*/ "a", 
        /*expected*/ true
      };

      yield return new object[]
      {
        /*lhs*/ 1, 
        /*rhs*/ 1.0f, 
        /*expected*/ true
      };

      yield return new object[]
      {
        /*lhs*/ new DateTime(1989, 05, 22), 
        /*rhs*/ new DateTime(1989, 05, 22), 
        /*expected*/ true
      };
    }
  }
  
  public enum TestEnum
  {
    A,
    B,
    C
  }
}