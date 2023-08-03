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
    public abstract void AreEqual();

    protected void WhenBothAreEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeTrue();
    }
    
    [Fact]
    public abstract void AreNotEqual();
    
    protected void WhenBothAreNotEqualInternal(object lhs, object rhs)
    {
      AnyComparer.Default.EqualTo(lhs, rhs).Should().BeFalse();
    }
  }
  
  public class StringEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal("abc", "abc");
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal("a", "b");
    }
  }
  
  public class IntEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1, 2);
    }
  }
  
  public class DoubleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1.0, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
  
  public class DecimalEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(1m, 1);
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(1m, 2);
    }
  }
  
  public class DateTimeEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 1));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
    }
  }
  
  public class GuidEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"));
    }
  }
  
  public class ArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new object[] { 'a', "b" }, new object[] { 'a', "c" });
    }
  }
  
  public class ByteArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x2 });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x3 });
    }
  }  
  
  public class CharArrayEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'b' });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new char[] { 'a', 'b' }, new char[] { 'a', 'c' });
    }
  }
  
  public class ListEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new List<object> { 'a', "b" }, new List<object> { 'a', "c" });
    }
  }
  
  public class DictionaryEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "b" } });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new Dictionary<object, object> { { 'a', "b" } }, new Dictionary<object, object> { { 'a', "c" } });
    }
  }
  
  public class HashSetEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "b" });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(new HashSet<object> { 'a', "b" }, new HashSet<object> { 'a', "c" });
    }
  }
  
  public class TupleEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "b"));
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(Tuple.Create('a', "b"), Tuple.Create('a', "c"));
    }
  }
  
  public class AnonymousEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var obj1 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      var obj2 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      
      WhenBothAreEqualInternal(obj1, obj2); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var obj1 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 1 } } };
      var obj2 = new { Id = 1, Name = "Paul", Items = new object[] { new { Id = 2 } } };
      WhenBothAreNotEqualInternal(obj1, obj2); 
    }
  }
  
  public class NameValueCollectionEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "b" } };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new NameValueCollection { { "a", "b" } };
      var rhs = new NameValueCollection { { "a", "c" } };

      WhenBothAreNotEqualInternal(lhs, rhs);
    }
  }
  
  public class StronglyTypedObjectEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      var lhs = new StronglyTypedObject { Id = 1, Name = "Paul", Items = { new StronglyTypedObject{ Id = 2, Name = "Alves" } } };
      var rhs = new StronglyTypedObject { Id = 1, Name = "Paul", Items = { new StronglyTypedObject{ Id = 2, Name = "Alves" } } };
      
      WhenBothAreEqualInternal(lhs, rhs); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      var lhs = new StronglyTypedObject { Id = 1, Name = "Paul", Items = { new StronglyTypedObject { Id = 1, Name = "Alves" } } };
      var rhs = new StronglyTypedObject { Id = 1, Name = "John", Items = { new StronglyTypedObject { Id = 2, Name = "Alves" } } };
      
      WhenBothAreNotEqualInternal(lhs, rhs); 
    }
    
    private class StronglyTypedObject
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<StronglyTypedObject> Items { get; set; } = new List<StronglyTypedObject>();
    }
  }

  public abstract class ComparisonTests
  {
    [Fact]
    public abstract void GreaterThan_ShouldBeTrue();
    
    [Fact]
    public abstract void LessThan_ShouldBeTrue();

    [Fact]
    public abstract void GreaterThanOrEqual_ShouldBeTrue();
    
    [Fact]
    public abstract void LessThanOrEqual_ShouldBeTrue();
    
    [Fact]
    public abstract void GreaterThan_ShouldBeFalse();
    
    [Fact]
    public abstract void LessThan_ShouldBeFalse();

    [Fact]
    public abstract void GreaterThanOrEqual_ShouldBeFalse();
    
    [Fact]
    public abstract void LessThanOrEqual_ShouldBeFalse();

    protected virtual void WhenLessThanOrEqual(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.LessThanOrEqualTo(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenGreaterThanOrEqual(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.GreaterThanOrEqualTo(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenLessThan(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.LessThan(lhs, rhs).Should().Be(expectedToBe);
    }
    protected virtual void WhenGreaterThan(object lhs, object rhs, bool expectedToBe)
    {
      AnyComparer.Default.GreaterThan(lhs, rhs).Should().Be(expectedToBe);
    }
  }
  
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
  
  public class IntComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2, 1, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1, 2, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2, 2, true);
      WhenGreaterThanOrEqual(3, 2, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1, 2, true);
      WhenLessThanOrEqual(2, 2, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1, 2, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2, 1, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1, 3, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3, 1, false);
    }
  }
  
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
  
  public class DoubleComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(2.0, 1.0, true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(1.0, 2.0, true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(2.0, 2.0, true);
      WhenGreaterThanOrEqual(3.0, 2.0, true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(1.0, 2.0, true);
      WhenLessThanOrEqual(2.0, 2.0, true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(1.0, 2.0, false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(2.0, 1.0, false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(1.0, 3.0, false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(3.0, 1.0, false);
    }
  }
  
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
  
  public class DateTimeComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(new DateTime(2012, 1, 1), new DateTime(2011, 1, 1), true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(new DateTime(2012, 1, 1), new DateTime(2012, 1, 1), true);
      WhenGreaterThanOrEqual(new DateTime(2013, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), true);
      WhenLessThanOrEqual(new DateTime(2012, 1, 1), new DateTime(2012, 1, 1), true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(new DateTime(2012, 1, 1), new DateTime(2011, 1, 1), false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(new DateTime(2011, 1, 1), new DateTime(2013, 1, 1), false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(new DateTime(2013, 1, 1), new DateTime(2011, 1, 1), false);
    }
  }
  
  public class TimeSpanComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 0), true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0), true);
      WhenGreaterThanOrEqual(new TimeSpan(2, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), true);
      WhenLessThanOrEqual(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0), true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 0), false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(new TimeSpan(0, 0, 0), new TimeSpan(2, 0, 0), false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(new TimeSpan(2, 0, 0), new TimeSpan(0, 0, 0), false);
    }
  }
  
  public class StringComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan("b", "a", true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan("a", "b", true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual("b", "b", true);
      WhenGreaterThanOrEqual("c", "b", true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual("a", "b", true);
      WhenLessThanOrEqual("b", "b", true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan("a", "b", false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan("b", "a", false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual("a", "c", false);
    }

    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual("c", "a", false);
    }
  }
  
  public class GuidComparisonTests : ComparisonTests
  {
    public override void GreaterThan_ShouldBeTrue()
    {
      WhenGreaterThan(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), true);
    }

    public override void LessThan_ShouldBeTrue()
    {
      WhenLessThan(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), true);
    }

    public override void GreaterThanOrEqual_ShouldBeTrue()
    {
      WhenGreaterThanOrEqual(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), true);
      WhenGreaterThanOrEqual(new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), true);
    }

    public override void LessThanOrEqual_ShouldBeTrue()
    {
      WhenLessThanOrEqual(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), true);
      WhenLessThanOrEqual(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), true);
    }

    public override void GreaterThan_ShouldBeFalse()
    {
      WhenGreaterThan(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001"), false);
    }

    public override void LessThan_ShouldBeFalse()
    {
      WhenLessThan(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), false);
    }

    public override void GreaterThanOrEqual_ShouldBeFalse()
    {
      WhenGreaterThanOrEqual(new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000002"), false);
    }
    
    public override void LessThanOrEqual_ShouldBeFalse()
    { 
      WhenLessThanOrEqual(new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000000"), false);
    }
  }
}