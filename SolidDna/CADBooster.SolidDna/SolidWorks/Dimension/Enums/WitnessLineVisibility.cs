namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the visibility state of witness lines in a dimension.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swWitnessLineVisibility_e.html
/// </summary>
public enum WitnessLineVisibility
{
    Both = 0,
    First = 1,
    Second = 2,
    None = 3
}
