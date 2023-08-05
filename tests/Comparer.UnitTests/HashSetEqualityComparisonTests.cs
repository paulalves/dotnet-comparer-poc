namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Comparer.Extensions;

  using FluentAssertions;

  using Xunit;

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
    
    [Fact]
    public void WhenAddDuplicate_ItemsCountShouldBeCorrect_ExcludingDuplicates()
    {
      var hashSet = new HashSet<object>(AnyComparer.Default) { 'a', "b", "a", "asdfg" };
      hashSet.Count.Should().Be(3);
    }
    
    [Fact]
    public void WhenBothAreEqual_CountainsDuplicates_WithSameItems()
    {
      var hashSet1 = new HashSet<object>(AnyComparer.Default) { 'a', "b", "b" };
      var hashSet2 = new HashSet<object>(AnyComparer.Default) { "a", "b", "a" };

      hashSet1.Count.Should().Be(2);
      hashSet2.Count.Should().Be(2);

      WhenBothAreEqualInternal(hashSet1, hashSet2);
    }
    
    [Fact]
    public void WhenBothAreNotEqual_CountainsDuplicates_WithDifferentItems()
    {
      var hashSet1 = new HashSet<object>(AnyComparer.Default) { 'a', "b", "a" };
      var hashSet2 = new HashSet<object>(AnyComparer.Default) { 'a', "c", 'c' };

      hashSet1.Count.Should().Be(2);
      hashSet2.Count.Should().Be(2);
      
      WhenBothAreNotEqualInternal(hashSet1, hashSet2);
    }
  }
}