namespace Comparer.Extensions
{
  using System.Collections.Generic;
  using System.Linq;

  public static class ConfigurableSorterEnumerableExtensions
  {
    public static IReadOnlyList<object> SortAsc(this IEnumerable<object> enumerable, AnyComparerOptions options)
    {
      var sorter = new Sorter(new AnyComparer(options));
      
      return enumerable.OrderBy(x => x, sorter).ToList();
    }

    public static IReadOnlyList<object> SortDesc(this IEnumerable<object> enumerable, AnyComparerOptions options)
    {
      var sorter = new Sorter(new AnyComparer(options));
      
      return enumerable.OrderByDescending(x => x, sorter).ToList();
    }
  }
}