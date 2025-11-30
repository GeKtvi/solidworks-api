namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the driven state of a dimension.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionDrivenState_e.html">swDimensionDrivenState_e</see>.
    /// </remarks>
    public enum DrivenState
    {
        /// <summary>
        /// Unknown driven state.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Dimension is driven (its value is calculated from other dimensions).
        /// </summary>
        Driven = 1,

        /// <summary>
        /// Dimension is driving (its value drives other dimensions).
        /// </summary>
        Driving = 2
    }
}
