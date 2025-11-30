namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the chamfer text style for dimensions.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDetailingChamferDimLeaderTextStyle_e.html">swDetailingChamferDimLeaderTextStyle_e</see>.
    /// </remarks>
    public enum ChamferTextStyle
    {
        /// <summary>
        /// Distance by distance style (e.g., "1 x 1").
        /// </summary>
        DistanceByDistance = 1,

        /// <summary>
        /// Distance by angle style (e.g., "1 x 45°").
        /// </summary>
        DistanceByAngle = 2,

        /// <summary>
        /// Angle by distance style (e.g., "45° x 1").
        /// </summary>
        AngleByDistance = 3,

        /// <summary>
        /// C distance style (e.g., "C1").
        /// </summary>
        CDistance = 4
    }
}
