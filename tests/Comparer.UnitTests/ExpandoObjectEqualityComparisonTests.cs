namespace Comparer.UnitTests
{
  using Xunit;

  public class ExpandoObjectEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      dynamic obj1 = new System.Dynamic.ExpandoObject();
      obj1.Id = 1;
      obj1.Name = "Paul";
      obj1.Items = new object[] { new { Id = 1 } };
      
      dynamic obj2 = new System.Dynamic.ExpandoObject();
      obj2.Id = 1;
      obj2.Name = "Paul";
      obj2.Items = new object[] { new { Id = 1 } };
      
      WhenBothAreEqualInternal(obj1, obj2); 
    }

    [Fact]
    public override void AreNotEqual()
    {
      dynamic obj1 = new System.Dynamic.ExpandoObject();
      obj1.Id = 1;
      obj1.Name = "Paul";
      obj1.Items = new object[] { new { Id = 1 } };
      
      dynamic obj2 = new System.Dynamic.ExpandoObject();
      obj2.Id = 1;
      obj2.Name = "Paul";
      obj2.Items = new object[] { new { Id = 2 } };
      
      WhenBothAreNotEqualInternal(obj1, obj2); 
    }
  }
}