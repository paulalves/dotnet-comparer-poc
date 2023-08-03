namespace Comparer.UnitTests
{
  using Xunit;

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
}