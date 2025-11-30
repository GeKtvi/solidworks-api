namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the visibility state of witness lines in a dimension.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swWitnessLineVisibility_e.html">swWitnessLineVisibility_e</see>.
    /// </remarks>
    public enum WitnessLineVisibility
    {
        /// <summary>
        /// Both witness lines are visible.
        /// </summary>
        Both = 0,

        /// <summary>
        /// Only the first witness line is visible.
        /// </summary>
        First = 1,

        /// <summary>
        /// Only the second witness line is visible.
        /// </summary>
        Second = 2,

        /// <summary>
        /// No witness lines are visible.
        /// </summary>
        None = 3
    }
}
