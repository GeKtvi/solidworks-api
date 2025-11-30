namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the position of arrows relative to the witness lines in a dimension.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionArrowsSide_e.html">swDimensionArrowsSide_e</see>.
    /// </remarks>
    public enum DimensionArrowSide
    {
        /// <summary>
        /// Arrows are inside the witness lines.
        /// </summary>
        Inside = 0,

        /// <summary>
        /// Arrows are outside the witness lines.
        /// </summary>
        Outside = 1,

        /// <summary>
        /// Arrows are positioned smartly based on available space.
        /// </summary>
        Smart = 2,

        /// <summary>
        /// Arrows follow the document default setting.
        /// </summary>
        FollowDocument = 3
    }
}
