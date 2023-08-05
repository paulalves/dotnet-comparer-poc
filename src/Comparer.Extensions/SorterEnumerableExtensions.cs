namespace Comparer.Extensions
{
  using System.Collections.Generic;
  using System.Linq;

  public static class SorterEnumerableExtensions
  {
    public static IReadOnlyList<object> SortAsc(this IEnumerable<object> enumerable)
    {
      return enumerable.OrderBy(x => x, new Sorter(AnyComparer.Default)).ToList();
    }

    public static IReadOnlyList<object> SortDesc(this IEnumerable<object> enumerable)
    {
      return enumerable.OrderByDescending(x => x, new Sorter(AnyComparer.Default)).ToList();
    }
  }
}