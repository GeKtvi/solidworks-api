namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the arc end condition for dimensions.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swArcEndCondition_e.html">swArcEndCondition_e</see>.
    /// </remarks>
    public enum ArcEndCondition
    {
        /// <summary>
        /// No arc end condition.
        /// </summary>
        None = 0,

        /// <summary>
        /// Arc end condition is at the center.
        /// </summary>
        Center = 1,

        /// <summary>
        /// Arc end condition is at the minimum point.
        /// </summary>
        Min = 2,

        /// <summary>
        /// Arc end condition is at the maximum point.
        /// </summary>
        Max = 3
    }
}
