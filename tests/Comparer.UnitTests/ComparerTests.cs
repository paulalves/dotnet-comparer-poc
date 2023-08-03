namespace Comparer.UnitTests
{
  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;

  using Comparer.Extensions;
  using FluentAssertions;
  using Xunit;

  public class ComparerTests
  {
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
  
  public abstract class EqualityComparisonTests
  {
    [Fact]
    public abstract void WhenBothAreEqual();

    protected void WhenBothAreEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeTrue();
    }
    
    [Fact]
    public abstract void WhenBothAreNotEqual();
    
    protected void WhenBothAreNotEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeFalse();
    }
  }
  public class StringEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal("abc", "abc");
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal("a", "b");
    }
  }
  public class IntEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(1, 1);
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(1, 2);
    }
  }
  public class DoubleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(1.0, 1);
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
  public class DecimalEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(1m, 1);
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
  public class DateTimeEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 1));
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
    }
  }
  public class GuidEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"));
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"));
    }
  }
  public class ArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "b" });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "c" });
    }
  }
  public class ByteArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x2 });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x3 });
    }
  }  
  public class CharArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'b' });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'c' });
    }
  }
  public class ListEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "b" });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "c" });
    }
  }
  public class DictionaryEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "b" } });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "c" } });
    }
  }
  public class HashSetEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "b" });
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "c" });
    }
  }
  public class TupleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      WhenBothAreEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "b"));
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      WhenBothAreNotEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "c"));
    }
  }
  public class AnonymousEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      var obj1 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      var obj2 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      
      WhenBothAreEqualInternal(obj1, obj2); 
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      var obj1 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      var obj2 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 2 } } };
      WhenBothAreNotEqualInternal(obj1, obj2); 
    }
  }
  public class NameValueCollectionEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void WhenBothAreEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "b" } };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void WhenBothAreNotEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "c" } };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
}