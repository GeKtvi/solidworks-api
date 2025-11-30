namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the horizontal justification of dimension text.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swTextJustification_e.html">swTextJustification_e</see>.
    /// </remarks>
    public enum TextJustification
    {
        /// <summary>
        /// No justification specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Left justification.
        /// </summary>
        Left = 1,

        /// <summary>
        /// Center justification.
        /// </summary>
        Center = 2,

        /// <summary>
        /// Right justification.
        /// </summary>
        Right = 3
    }
}
