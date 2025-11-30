namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the parts of the dimension text.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDimensionTextParts_e.html">swDimensionTextParts_e</see>.
    /// </remarks>
    public enum DimensionTextParts
    {
        /// <summary>
        /// All text parts (prefix, suffix, and callouts).
        /// </summary>
        All = 0,

        /// <summary>
        /// Prefix text.
        /// </summary>
        Prefix = 1,

        /// <summary>
        /// Suffix text.
        /// </summary>
        Suffix = 2,

        /// <summary>
        /// Callout text above the dimension value.
        /// </summary>
        CalloutAbove = 3,

        /// <summary>
        /// Callout text below the dimension value.
        /// </summary>
        CalloutBelow = 4,

        /// <summary>
        /// Prefix definition text.
        /// </summary>
        PrefixDefinition = 5,

        /// <summary>
        /// Suffix definition text.
        /// </summary>
        SuffixDefinition = 6,

        /// <summary>
        /// Callout above definition text.
        /// </summary>
        CalloutAboveDefinition = 7,

        /// <summary>
        /// Callout below definition text.
        /// </summary>
        CalloutBelowDefinition = 8
    }
}
