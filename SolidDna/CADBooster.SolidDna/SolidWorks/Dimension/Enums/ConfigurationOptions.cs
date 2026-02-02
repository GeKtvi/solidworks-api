namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the configuration options for dimension operations.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swSetValueInConfiguration_e.html
/// </summary>
public enum ConfigurationOptions
{
    UseCurrentSetting = 0,
    ThisConfiguration = 1,
    AllConfigurations = 2,
    SpecificConfigurations = 3,
    NoConfiguration = -1
}
