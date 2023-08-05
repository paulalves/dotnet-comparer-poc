// ReSharper disable PossibleInterfaceMemberAmbiguity
namespace Comparer.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.Dynamic;

  public interface IComparer : IEqualsComparer, System.Collections.IComparer,
    IComparer<object>,
    IComparer<IDictionary>,
    IComparer<IDictionary<string, object>>,
    IComparer<IList>, 
    IComparer<ICollection>,
    IComparer<IEnumerable>,
    IComparer<NameValueCollection>,
    IComparer<TimeSpan>,
    IComparer<DateTime>,
    IComparer<DateTimeOffset>,
    IComparer<ExpandoObject>,
    
    IComparer<string>,
    IComparer<Array>,
    IComparer<char>,
    IComparer<double>,
    IComparer<float>,
    IComparer<decimal>,
    IComparer<byte>,
    IComparer<long>,
    IComparer<int>,
    
    IEqualityComparer<object>,
    IEqualityComparer<IDictionary>,
    IEqualityComparer<IDictionary<string, object>>,
    IEqualityComparer<IList>, 
    IEqualityComparer<ICollection>,
    IEqualityComparer<IEnumerable>,
    IEqualityComparer<NameValueCollection>,
    IEqualityComparer<TimeSpan>,
    IEqualityComparer<DateTime>,
    IEqualityComparer<DateTimeOffset>,
    IEqualityComparer<ExpandoObject>
  {
    bool LessThan(object? lhs, object? rhs);
    bool LessThanOrEqualTo(object? lhs, object? rhs);
    bool GreaterThan(object? lhs, object? rhs);
    bool GreaterThanOrEqualTo(object? lhs, object? rhs);
    int CompareTo(object? lhs, object? rhs);
  }
}