namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the end symbol type for dimensions.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swOrdDimEndSymbol_e.html">swOrdDimEndSymbol_e</see>.
    /// </remarks>
    public enum DimensionEndSymbol
    {
        /// <summary>
        /// No end symbol.
        /// </summary>
        None = 0,

        /// <summary>
        /// Dowel end symbol.
        /// </summary>
        Dowel = 1,

        /// <summary>
        /// Upward right end symbol.
        /// </summary>
        UpwardRight = 2,

        /// <summary>
        /// Downward left end symbol.
        /// </summary>
        DownwardLeft = 3
    }
}
