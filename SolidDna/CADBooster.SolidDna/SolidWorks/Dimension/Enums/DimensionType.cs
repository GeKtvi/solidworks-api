namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the type of dimension parameter.
    /// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swDimensionParamType_e.html
    /// </summary>
    public enum DimensionType
    {
        DoubleLinear = 0,
        DoubleAngular = 1,
        Integer = 2,
        Unknown = -1
    }
}
