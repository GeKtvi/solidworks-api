namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the type of dimension parameter.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionParamType_e.html">swDimensionParamType_e</see>.
    /// </remarks>
    public enum DimensionType
    {
        /// <summary>
        /// Double linear dimension parameter.
        /// </summary>
        DoubleLinear = 0,

        /// <summary>
        /// Double angular dimension parameter.
        /// </summary>
        DoubleAngular = 1,

        /// <summary>
        /// Integer dimension parameter.
        /// </summary>
        Integer = 2,

        /// <summary>
        /// Unknown dimension parameter type.
        /// </summary>
        Unknown = -1
    }
}
