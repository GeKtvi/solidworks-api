namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the configuration options for dimension operations.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swSetValueInConfiguration_e.html">swSetValueInConfiguration_e</see>.
    /// </remarks>
    public enum ConfigurationOptions
    {
        /// <summary>
        /// Use the current setting.
        /// </summary>
        UseCurrentSetting = 0,

        /// <summary>
        /// Apply to this configuration only.
        /// </summary>
        ThisConfiguration = 1,

        /// <summary>
        /// Apply to all configurations.
        /// </summary>
        AllConfigurations = 2,

        /// <summary>
        /// Apply to specific configurations (requires configuration names to be provided).
        /// </summary>
        SpecificConfigurations = 3,

        /// <summary>
        /// No configuration specified.
        /// </summary>
        NoConfiguration = -1
    }
}
