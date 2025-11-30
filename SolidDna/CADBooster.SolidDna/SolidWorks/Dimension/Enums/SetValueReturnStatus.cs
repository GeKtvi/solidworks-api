namespace CADBooster.SolidDna
{
    /// <summary>
    /// Specifies the return status for dimension value setting operations.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://help.solidworks.com/2026/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swSetValueReturnStatus_e.html">swSetValueReturnStatus_e</see>.
    /// </remarks>
    public enum SetValueReturnStatus
    {
        /// <summary>
        /// Operation was successful.
        /// </summary>
        Successful = 0,

        /// <summary>
        /// Operation failed.
        /// </summary>
        Failure = 1,

        /// <summary>
        /// The value provided is invalid.
        /// </summary>
        InvalidValue = 2,

        /// <summary>
        /// The dimension is driven and cannot be set.
        /// </summary>
        DrivenDimension = 3,

        /// <summary>
        /// The model is not loaded.
        /// </summary>
        ModelNotLoaded = 4,

        /// <summary>
        /// The feature owner is frozen.
        /// </summary>
        FrozenFeatureOwner = 5
    }
}
