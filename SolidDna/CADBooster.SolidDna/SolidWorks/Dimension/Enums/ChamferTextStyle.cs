namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the chamfer text style for dimensions.
    /// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDetailingChamferDimLeaderTextStyle_e.html
    /// </summary>
    public enum ChamferTextStyle
    {
        DistanceByDistance = 1,
        DistanceByAngle = 2,
        AngleByDistance = 3,
        CDistance = 4
    }
}
