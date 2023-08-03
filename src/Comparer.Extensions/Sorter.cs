namespace Comparer.Extensions
{
  using System;
  using System.Collections.Generic;

  internal class Sorter : System.IComparable, System.Collections.IComparer, IComparer<object>
  {
    public int CompareTo(object? obj)
    {
      return AnyComparer.Default.CompareTo(obj);
    }

    public int Compare(object? x, object? y)
    {
      return AnyComparer.Default.Compare(x, y);
    }
  }
}