namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the visibility state of leader lines in a dimension.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swLeaderLineVisibility_e.html
/// </summary>
public enum LeaderLineVisibility
{
    Both = 0,
    First = 1,
    Second = 2,
    None = 3
}
