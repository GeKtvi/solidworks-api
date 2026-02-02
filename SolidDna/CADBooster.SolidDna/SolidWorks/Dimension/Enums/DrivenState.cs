namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the driven state of a dimension.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionDrivenState_e.html
/// </summary>
public enum DrivenState
{
    Unknown = 0,
    Driven = 1,
    Driving = 2
}
