namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the visibility state of leader lines in a dimension.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swLeaderLineVisibility_e.html">swLeaderLineVisibility_e</see>.
    /// </remarks>
    public enum LeaderLineVisibility
    {
        /// <summary>
        /// Both leader lines are visible.
        /// </summary>
        Both = 0,

        /// <summary>
        /// Only the first leader line is visible.
        /// </summary>
        First = 1,

        /// <summary>
        /// Only the second leader line is visible.
        /// </summary>
        Second = 2,

        /// <summary>
        /// No leader lines are visible.
        /// </summary>
        None = 3
    }
}
