namespace CADBooster.SolidDna;

/// <summary>
/// Specifies the return status for dimension value setting operations.
/// Reference: https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swSetValueReturnStatus_e.html
/// </summary>
public enum SetValueReturnStatus
{
    Successful = 0,
    Failure = 1,
    InvalidValue = 2,
    DrivenDimension = 3,
    ModelNotLoaded = 4,
    FrozenFeatureOwner = 5
}
