namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the type of the display dimension.
    /// Reference: https://help.solidworks.com/2023/english/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swDimensionType_e.html
    /// </summary>
    public enum DisplayDimensionType
    {
        Unknown = 0,
        Ordinate = 1,
        Linear = 2,
        Angular = 3,
        ArcLength = 4,
        Radial = 5,
        Diameter = 6,
        HorizontalOrdinate = 7,
        VerticalOrdinate = 8,
        ZAxis = 9,
        Chamfer = 10,
        HorizontalLinear = 11,
        VerticalLinear = 12,
        Scalar = 13,
        RadialLinear = 14,
        DiametricLinear = 15
    }
}
