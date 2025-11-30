using System;
using System.Linq;
using SolidWorks.Interop.sldworks;

namespace CADBooster.SolidDna
{
    /// <summary>
    /// Represents a dimension in a SolidWorks model.
    /// Allows getting and setting dimension values and tolerances.
    /// </summary>
    /// <remarks>
    /// This class wraps the SolidWorks API <see href="https://help.solidworks.com/2026/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IDimension_members.html">IDimension</see> interface.
    /// </remarks>
    public class ModelDimension : SolidDnaObject<IDimension>
    {
        #region Private Members

        private readonly Lazy<ModelFeature> _featureOwner;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the dimension.
        /// </summary>
        public string Name
        {
            get => BaseObject.Name;
            set => BaseObject.Name = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get => BaseObject.ReadOnly;
            set => BaseObject.ReadOnly = value;
        }

        /// <summary>
        /// Gets or sets the driven state of the dimension.
        /// </summary>
        public DrivenState DrivenState
        {
            get => (DrivenState)BaseObject.DrivenState;
            set => BaseObject.DrivenState = (int)value;
        }

        /// <summary>
        /// Gets the full name of the dimension, including its feature and sketch identifiers.
        /// </summary>
        public string FullName => BaseObject.FullName;

        /// <summary>
        /// Gets whether this is a reference dimension.
        /// </summary>
        public bool IsReference => BaseObject.IsReference();

        /// <summary>
        /// Gets whether this dimension is applied to all configurations.
        /// </summary>
        public bool IsAppliedToAllConfigurations => BaseObject.IsAppliedToAllConfigurations();

        /// <summary>
        /// Gets whether this is a design table dimension.
        /// </summary>
        public bool IsDesignTableDimension => BaseObject.IsDesignTableDimension();

        /// <summary>
        /// Gets the feature that owns this dimension.
        /// </summary>
        public ModelFeature FeatureOwner => _featureOwner.Value;

        /// <summary>
        /// Gets the type of dimension.
        /// </summary>
        public DimensionType Type => (DimensionType)BaseObject.GetType();

        /// <summary>
        /// Gets the name for selection of this dimension.
        /// </summary>
        public string NameForSelection => BaseObject.GetNameForSelection();

        /// <summary>
        /// Gets whether this is a chamfer dimension.
        /// </summary>
        public bool IsChamferDimension
        {
            get
            {
                double _ = 0, __ = 0;
                return BaseObject.GetSystemChamferValues(ref _, ref __);
            }
        }

        /// <summary>
        /// Gets or sets the user value of the dimension for the current configuration.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="GetValue"/> and <see cref="SetValue"/> with <see cref="ConfigurationOptions.ThisConfiguration"/>.
        /// </remarks>
        public double Value
        {
            get => GetValue(ConfigurationOptions.ThisConfiguration, null);
            set => SetValue(value, ConfigurationOptions.ThisConfiguration, null);
        }

        /// <summary>
        /// Gets or sets the system value of the dimension for the current configuration.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="GetSystemValue"/> and <see cref="SetSystemValue"/> with <see cref="ConfigurationOptions.ThisConfiguration"/>.
        /// </remarks>
        public double SystemValue
        {
            get => GetSystemValue(ConfigurationOptions.ThisConfiguration, null);
            set => SetSystemValue(value, ConfigurationOptions.ThisConfiguration, null);
        }

        /// <summary>
        /// Gets the system chamfer values (length and angle) for this dimension.
        /// </summary>
        /// <returns>The chamfer values containing length and angle.</returns>
        /// <exception cref="SolidDnaException">Thrown when this dimension is not a chamfer dimension.</exception>
        public DimensionChamferValues SystemChamferValues
        {
            get
            {
                double length = 0, angle = 0;
                var isChamfer = BaseObject.GetSystemChamferValues(ref length, ref angle);

                return !isChamfer
                    ? throw new SolidDnaException(SolidDnaErrors.CreateError(
                        SolidDnaErrorTypeCode.SolidWorksModel,
                        SolidDnaErrorCode.SolidWorksModelError,
                        "This dimension is not a chamfer dimension."))
                    : new DimensionChamferValues(length, angle);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="ModelDimension"/>.
        /// </summary>
        /// <param name="dimension">The underlying SolidWorks <see cref="IDimension"/> object.</param>
        public ModelDimension(IDimension dimension) : base(dimension)
        {
            _featureOwner = new Lazy<ModelFeature>(() => new ModelFeature(BaseObject.GetFeatureOwner()));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the user value of the dimension in the specified document.
        /// </summary>
        /// <param name="doc">The model document to get the value from.</param>
        /// <returns>The user value of the dimension.</returns>
        public double GetUserValueIn(Model doc)
            => BaseObject.IGetUserValueIn2(doc.UnsafeObject);

        /// <summary>
        /// Sets the user value of the dimension in the specified document.
        /// </summary>
        /// <param name="doc">The model document to set the value in.</param>
        /// <param name="newValue">The new user value to set.</param>
        /// <param name="whichConfigurations">The configuration options specifying which configurations to update.</param>
        /// <returns>The status of the set operation.</returns>
        public SetValueReturnStatus SetUserValueIn(Model doc, double newValue, ConfigurationOptions whichConfigurations)
            => (SetValueReturnStatus)BaseObject.ISetUserValueIn3(doc.UnsafeObject, newValue, (int)whichConfigurations);

        /// <summary>
        /// Gets the user value of the dimension for the specified configurations.
        /// </summary>
        /// <param name="whichConfigurations">The configuration options specifying which configurations to get the value from.</param>
        /// <param name="configNames">Optional array of configuration names. If null, uses the configuration options.</param>
        /// <returns>The user value of the dimension.</returns>
        /// <remarks>
        /// TODO: check if inprocess method works from CLR.
        /// </remarks>
        public double GetValue(ConfigurationOptions whichConfigurations, string[] configNames = null)
            => BaseObject.IGetValue3((int)whichConfigurations, configNames?.Length ?? 0, configNames?.FirstOrDefault());

        /// <summary>
        /// Gets the system value of the dimension for the specified configurations.
        /// </summary>
        /// <param name="whichConfigurations">The configuration options specifying which configurations to get the value from.</param>
        /// <param name="configNames">Optional array of configuration names. If null, uses the configuration options.</param>
        /// <returns>The system value of the dimension.</returns>
        public double GetSystemValue(ConfigurationOptions whichConfigurations, string[] configNames = null)
            => BaseObject.IGetSystemValue3((int)whichConfigurations, configNames?.Length ?? 0, configNames?.FirstOrDefault());

        /// <summary>
        /// Sets the user value of the dimension for the specified configurations.
        /// </summary>
        /// <param name="newValue">The new user value to set.</param>
        /// <param name="whichConfigurations">The configuration options specifying which configurations to update.</param>
        /// <param name="configNames">Optional array of configuration names. If null, uses the configuration options.</param>
        /// <returns>The status of the set operation.</returns>
        public SetValueReturnStatus SetValue(double newValue, ConfigurationOptions whichConfigurations, string[] configNames = null)
            => (SetValueReturnStatus)BaseObject.SetValue3(newValue, (int)whichConfigurations, configNames);

        /// <summary>
        /// Sets the system value of the dimension for the specified configurations.
        /// </summary>
        /// <param name="newValue">The new system value to set.</param>
        /// <param name="whichConfigurations">The configuration options specifying which configurations to update.</param>
        /// <param name="configNames">Optional array of configuration names. If null, uses the configuration options.</param>
        /// <returns>The status of the set operation.</returns>
        public SetValueReturnStatus SetSystemValue(double newValue, ConfigurationOptions whichConfigurations, string[] configNames = null)
            => (SetValueReturnStatus)BaseObject.SetSystemValue3(newValue, (int)whichConfigurations, configNames);

        /// <summary>
        /// Gets the arc end condition for the specified index.
        /// </summary>
        /// <param name="index">The index of the arc end condition to get.</param>
        /// <returns>The arc end condition.</returns>
        public ArcEndCondition GetArcEndCondition(int index)
            => (ArcEndCondition)BaseObject.GetArcEndCondition(index);

        /// <summary>
        /// Sets the arc end condition for the specified index.
        /// </summary>
        /// <param name="index">The index of the arc end condition to set.</param>
        /// <param name="condition">The arc end condition to set.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool SetArcEndCondition(int index, ArcEndCondition condition)
            => BaseObject.SetArcEndCondition(index, (int)condition) != 0;

        #endregion

        #region ToString

        /// <summary>
        /// Returns a string representation of this dimension.
        /// </summary>
        /// <returns>The full name of the dimension.</returns>
        public override string ToString() => FullName;

        #endregion

        #region Not Implemented members

        // TODO: Implement deferred members using proper SolidDna wrappers
        // - Tolerance: expose as SolidDna wrapper for IDimensionTolerance
        // - DimensionLineDirection: expose as MathVector (or SolidDna math wrapper)
        // - ExtensionLineDirection: expose as MathVector (or SolidDna math wrapper)
        // - ReferencePoints: expose as array/collection of MathPoint (or wrapped points)

        #endregion

        #region Dispose

        public override void Dispose()
        {
            // Dispose lazy-loaded child objects
            if (_featureOwner.IsValueCreated == true)
                _featureOwner.Value?.Dispose();

            // Dispose self
            base.Dispose();
        }

        #endregion
    }
}
