namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

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
      var rhs = new StronglyTypedObject { Id = 1, Name = "John", Items = { new StronglyTypedObject { Id = 1, Name = "Alves" }, new StronglyTypedObject() } };
      
      WhenBothAreNotEqualInternal(lhs, rhs); 
    }
    
    private class StronglyTypedObject
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<StronglyTypedObject> Items { get; set; } = new List<StronglyTypedObject>();
    }
  }
}