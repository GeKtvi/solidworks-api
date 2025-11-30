namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the display dimension leader text position.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDisplayDimensionLeaderText_e.html">swDisplayDimensionLeaderText_e</see>.
    /// </remarks>
    public enum DisplayDimensionLeaderTextPosition
    {
        /// <summary>
        /// Use document default setting.
        /// </summary>
        Default = -1,

        /// <summary>
        /// Leader is solid (not broken) and the text is aligned with the leader.
        /// </summary>
        SolidLeaderAligned = 1,

        /// <summary>
        /// Leader is broken and the text is horizontal.
        /// </summary>
        BrokenLeaderHorizontal = 2,

        /// <summary>
        /// Leader is broken and the text is aligned with the leader.
        /// </summary>
        BrokenLeaderAligned = 3,

        /// <summary>
        /// Leader is solid and the text is horizontal. Although this value can be applied to any type of dimension where the dimension text is not between the extension lines, it is currently only implemented by SOLIDWORKS for chamfer dimensions.
        /// </summary>
        SolidLeaderHorizontal = 4
    }
}
