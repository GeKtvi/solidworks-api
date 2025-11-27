namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the end symbol type for dimensions.
    /// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swOrdDimEndSymbol_e.html
    /// </summary>
    public enum DimensionEndSymbol
    {
        None = 0,
        Dowel = 1,
        UpwardRight = 2,
        DownwardLeft = 3
    }
}
