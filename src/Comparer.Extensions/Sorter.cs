namespace Comparer.Extensions
{
  using System;

  internal class Sorter : IComparable
  {
    private readonly object? _source;

    public Sorter(object? source)
    {
      _source = source;
    }
    
    public int CompareTo(object? obj)
    {
      return AnyComparer.Default.CompareTo(obj);
    }
  }
}