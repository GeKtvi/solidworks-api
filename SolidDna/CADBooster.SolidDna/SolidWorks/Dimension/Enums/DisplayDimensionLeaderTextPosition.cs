namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the display dimension leader type.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDisplayDimensionLeaderText_e.html
/// </summary>
public enum DisplayDimensionLeaderTextPosition
{
    Default = -1,
    SolidLeaderAligned = 1,
    BrokenLeaderHorizontal = 2,
    BrokenLeaderAligned = 3,
    SolidLeaderHorizontal = 4
}
