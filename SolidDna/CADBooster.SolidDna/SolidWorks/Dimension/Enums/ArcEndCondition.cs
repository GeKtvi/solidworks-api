namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the arc end condition for dimensions.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swArcEndCondition_e.html
/// </summary>
public enum ArcEndCondition
{
    None = 0,
    Center = 1,
    Min = 2,
    Max = 3
}
