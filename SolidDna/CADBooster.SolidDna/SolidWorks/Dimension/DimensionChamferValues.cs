namespace CADBooster.SolidDna
{
    /// <summary>
    /// Represents chamfer dimension values with length and angle.
    /// </summary>
    public readonly struct DimensionChamferValues
    {
        public double Length { get; }
        public double Angle { get; }

        public DimensionChamferValues(double length, double angle)
        {
            Length = length;
            Angle = angle;
        }
    }
}
