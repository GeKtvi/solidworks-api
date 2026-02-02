using System;
using System.Linq;
using SolidWorks.Interop.sldworks;

namespace CADBooster.SolidDna;

public class ModelDimension : SolidDnaObject<IDimension>
{
    #region Private Members

    private readonly Lazy<ModelFeature> _featureOwner;

    #endregion
    public string Name
    {
        get => BaseObject.Name;
        set => BaseObject.Name = value;
    }

    public bool IsReadOnly
    {
        get => BaseObject.ReadOnly;
        set => BaseObject.ReadOnly = value;
    }

    public DrivenState DrivenState
    {
        get => (DrivenState)BaseObject.DrivenState;
        set => BaseObject.DrivenState = (int)value;
    }

    public string FullName => BaseObject.FullName;
    public bool IsReference => BaseObject.IsReference();
    public bool IsAppliedToAllConfigurations => BaseObject.IsAppliedToAllConfigurations();
    public bool IsDesignTableDimension => BaseObject.IsDesignTableDimension();
    public ModelFeature FeatureOwner => _featureOwner.Value;
    public DimensionType Type => (DimensionType)BaseObject.GetType();
    public string NameForSelection => BaseObject.GetNameForSelection();

    public bool IsChamferDimension
    {
        get
        {
            double _ = 0, __ = 0;
            return BaseObject.GetSystemChamferValues(ref _, ref __);
        }
    }

    public double Value
    {
        get => GetValue(ConfigurationOptions.ThisConfiguration, null);
        set => SetValue(value, ConfigurationOptions.ThisConfiguration, null);
    }

    public double SystemValue
    {
        get => GetSystemValue(ConfigurationOptions.ThisConfiguration, null);
        set => SetSystemValue(value, ConfigurationOptions.ThisConfiguration, null);
    }

    public ModelDimension(IDimension dimension) : base(dimension)
    {
        _featureOwner = new Lazy<ModelFeature>(() => new ModelFeature(BaseObject.GetFeatureOwner()));
    }

    public double GetUserValueIn(Model doc)
        => BaseObject.IGetUserValueIn2(doc.UnsafeObject);

    public SetValueReturnStatus SetUserValueIn(Model doc, double newValue, ConfigurationOptions whichConfigurations)
        => (SetValueReturnStatus)BaseObject.ISetUserValueIn3(doc.UnsafeObject, newValue, (int)whichConfigurations);

    // TODO: check is inprocess method works from CLR
    public double GetValue(ConfigurationOptions whichConfigurations, string[] configNames = null)
        => BaseObject.IGetValue3((int)whichConfigurations, configNames?.Length ?? 0, configNames?.FirstOrDefault());

    public double GetSystemValue(ConfigurationOptions whichConfigurations, string[] configNames = null)
        => BaseObject.IGetSystemValue3((int)whichConfigurations, configNames?.Length ?? 0, configNames?.FirstOrDefault());

    public SetValueReturnStatus SetValue(double newValue, ConfigurationOptions whichConfigurations, string[] configNames = null)
        => (SetValueReturnStatus)BaseObject.SetValue3(newValue, (int)whichConfigurations, configNames);

    public SetValueReturnStatus SetSystemValue(double newValue, ConfigurationOptions whichConfigurations, string[] configNames = null)
        => (SetValueReturnStatus)BaseObject.SetSystemValue3(newValue, (int)whichConfigurations, configNames);

    public ArcEndCondition GetArcEndCondition(int index)
        => (ArcEndCondition)BaseObject.GetArcEndCondition(index);

    public bool SetArcEndCondition(int index, ArcEndCondition condition)
        => BaseObject.SetArcEndCondition(index, (int)condition) != 0;

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

    // TODO: Implement deferred members using proper SolidDna wrappers
    // - Tolerance: expose as SolidDna wrapper for IDimensionTolerance
    // - DimensionLineDirection: expose as MathVector (or SolidDna math wrapper)
    // - ExtensionLineDirection: expose as MathVector (or SolidDna math wrapper)
    // - ReferencePoints: expose as array/collection of MathPoint (or wrapped points)

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
