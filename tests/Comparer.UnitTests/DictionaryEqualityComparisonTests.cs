namespace Comparer.UnitTests
{
  using System.Collections.Generic;

  using Xunit;

  public class DictionaryEqualityComparisonTests : EqualityComparisonTests
  {
    [Fact]
    public override void AreEqual()
    {
      WhenBothAreEqualInternal(
        new Dictionary<object, object>
        {
          { 'a', "b" }, 
          { 'c', new Dictionary<object, object>
            {
              { 'd', "e" }
            } 
          }
        },
        new Dictionary<object, object>
        {
          { 'a', "b" }, 
          { 'c', new Dictionary<object, object>
            {
              { 'd', "e" }
            } 
          }
        });
    }

    [Fact]
    public override void AreNotEqual()
    {
      WhenBothAreNotEqualInternal(
        new Dictionary<object, object>
        {
          { 'a', "b" }, 
          { 'c', new Dictionary<object, object>
            {
              { 'd', "e" }
            } 
          }
        },
        new Dictionary<object, object>
        {
          { 'a', "b" }, 
          { 'c', new Dictionary<object, object>
            {
              { 'd', "f" }
            } 
          }
        });
    }
  }
}