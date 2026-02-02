namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the position of arrows relative to the witness lines in a dimension.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionArrowsSide_e.html
/// </summary>
public enum DimensionArrowSide
{
    Inside = 0,
    Outside = 1,
    Smart = 2,
    FollowDocument = 3
}
