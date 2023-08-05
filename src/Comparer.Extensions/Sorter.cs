namespace Comparer.Extensions
{
  using System.Collections.Generic;

  internal class Sorter : IComparer<object>
  {
    private readonly IComparer comparer;

    public Sorter(IComparer comparer)
    {
      this.comparer = comparer;
    }
    
    public int Compare(object? x, object? y)
    {
      return comparer.Compare(x, y);
    }
  }
}