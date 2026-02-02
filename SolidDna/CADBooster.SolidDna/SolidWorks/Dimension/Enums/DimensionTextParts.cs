namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the parts of the dimension text.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDimensionTextParts_e.html
/// </summary>
public enum DimensionTextParts
{
    All = 0,
    Prefix = 1,
    Suffix = 2,
    CalloutAbove = 3,
    CalloutBelow = 4,
    PrefixDefinition = 5,
    SuffixDefinition = 6,
    CalloutAboveDefinition = 7,
    CalloutBelowDefinition = 8
}
