namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the type of the display dimension.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDimensionType_e.html">swDimensionType_e</see>.
    /// </remarks>
    public enum DisplayDimensionType
    {
        /// <summary>
        /// Unknown dimension type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Ordinate dimension.
        /// </summary>
        Ordinate = 1,

        /// <summary>
        /// Linear dimension.
        /// </summary>
        Linear = 2,

        /// <summary>
        /// Angular dimension.
        /// </summary>
        Angular = 3,

        /// <summary>
        /// Arc length dimension.
        /// </summary>
        ArcLength = 4,

        /// <summary>
        /// Radial dimension.
        /// </summary>
        Radial = 5,

        /// <summary>
        /// Diameter dimension.
        /// </summary>
        Diameter = 6,

        /// <summary>
        /// Horizontal ordinate dimension.
        /// </summary>
        HorizontalOrdinate = 7,

        /// <summary>
        /// Vertical ordinate dimension.
        /// </summary>
        VerticalOrdinate = 8,

        /// <summary>
        /// Z-axis dimension.
        /// </summary>
        ZAxis = 9,

        /// <summary>
        /// Chamfer dimension.
        /// </summary>
        Chamfer = 10,

        /// <summary>
        /// Horizontal linear dimension.
        /// </summary>
        HorizontalLinear = 11,

        /// <summary>
        /// Vertical linear dimension.
        /// </summary>
        VerticalLinear = 12,

        /// <summary>
        /// Scalar dimension.
        /// </summary>
        Scalar = 13,

        /// <summary>
        /// Radial linear dimension.
        /// </summary>
        RadialLinear = 14,

        /// <summary>
        /// Diametric linear dimension.
        /// </summary>
        DiametricLinear = 15
    }
}
