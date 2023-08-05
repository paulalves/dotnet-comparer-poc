namespace Comparer.Extensions
{
  using System;

  public class AnyComparerOptions
  {
    public StringComparison StringComparison { get; set; } = StringComparison.InvariantCultureIgnoreCase;
    public bool TreatNullAsEqual { get; set; } = true;
    public bool TreatEmptyStringAsEqual { get; set; } = true;
    public bool TreatEmptyStringAsNull { get; set; } = true;
    public bool TreatEmptyCollectionAsEqual { get; set; } = true;
  }
}