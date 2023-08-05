namespace Comparer.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.Dynamic;

  using Unknown = System.Object;
  
  public abstract class ComparerBase : IComparer
  {
    public bool LessThan(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == -1;
    }

    public abstract int CompareTo(Unknown? lhs, Unknown? rhs);

    public bool LessThanOrEqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) <= 0;
    }

    public bool GreaterThan(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == 1;
    }

    public bool GreaterThanOrEqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) >= 0;
    }

    public bool EqualTo(Unknown? lhs, Unknown? rhs)
    {
      return CompareTo(lhs, rhs) == 0;
    }

    public int Compare(object? x, object? y)
    {
      return CompareTo(x, y);
    }

    public abstract int Compare(IDictionary? x, IDictionary? y);
    
    public abstract int Compare(IList? x, IList? y);
    
    public abstract int Compare(NameValueCollection? x, NameValueCollection? y);
    
    public abstract int Compare(IDictionary<string, object>? x, IDictionary<string, object>? y);
    
    public abstract int Compare(ICollection? x, ICollection? y);
    
    public abstract int Compare(IEnumerable? x, IEnumerable? y);

    public abstract int Compare(Array? x, Array? y);

    public abstract int Compare(string? x, string? y);
    
    public virtual int Compare(double lhs, double rhs)
    {
      return Comparer.Default.Compare(lhs, rhs);
    }

    public virtual int Compare(float x, float y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(decimal x, decimal y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(byte x, byte y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(TimeSpan x, TimeSpan y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(DateTime x, DateTime y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(DateTimeOffset x, DateTimeOffset y)
    {
      return Comparer.Default.Compare(x, y);
    }
    
    public virtual int Compare(char x, char y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual int Compare(long x, long y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public virtual bool Equals(IDictionary? x, IDictionary? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(IDictionary obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(IDictionary<string, object>? x, IDictionary<string, object>? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(IDictionary<string, object> obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(IList? x, IList? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(IList obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(ICollection? x, ICollection? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(ICollection obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(IEnumerable? x, IEnumerable? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(IEnumerable obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(NameValueCollection? x, NameValueCollection? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(NameValueCollection obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(Array? x, Array? y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(Array obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(TimeSpan x, TimeSpan y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(TimeSpan obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(DateTime x, DateTime y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(DateTime obj)
    {
      return obj.GetHashCode();
    }

    public virtual bool Equals(DateTimeOffset x, DateTimeOffset y)
    {
      return Compare(x, y) == 0;
    }

    public virtual int GetHashCode(DateTimeOffset obj)
    {
      return obj.GetHashCode();
    }

    public virtual int Compare(int x, int y)
    {
      return Comparer.Default.Compare(x, y);
    }

    public new virtual bool Equals(object? x, object? y)
    {
      return Compare(x!, y!) == 0; 
    }

    public virtual int GetHashCode(object obj)
    {
      if (obj.GetType().IsChar())
      {
        return new string((char)obj, 1).GetHashCode();
      }
      
      return obj.GetHashCode();  
    }

    public int Compare(ExpandoObject? x, ExpandoObject? y)
    {
      return Compare((IDictionary<string, object>)x!, (IDictionary<string, object>)y!);
    }

    public bool Equals(ExpandoObject? x, ExpandoObject? y)
    {
      return Compare(x, y) == 0;
    }

    public int GetHashCode(ExpandoObject obj)
    {
      return obj.GetHashCode();
    }
  }
}