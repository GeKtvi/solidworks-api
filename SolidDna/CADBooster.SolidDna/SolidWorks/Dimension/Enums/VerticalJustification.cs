namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the vertical justification of dimension text.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swVerticalJustification_e.html">swVerticalJustification_e</see>.
    /// </remarks>
    public enum VerticalJustification
    {
        /// <summary>
        /// No justification specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Top justification.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Middle justification.
        /// </summary>
        Middle = 2,

        /// <summary>
        /// Bottom justification.
        /// </summary>
        Bottom = 3
    }
}
