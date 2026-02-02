using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;

namespace CADBooster.SolidDna;

/// <summary>
/// Represents a selected object of a SolidWorks object.
/// The type can be one of many different things
/// 
/// NOTE: All mappings from selected entities to specific objects are here
/// http://help.solidworks.com/2026/English/api/swconst/SolidWorks.Interop.swconst~SolidWorks.Interop.swconst.swSelectType_e.html
/// </summary>
public class SelectedObject : SolidDnaObject<object>, ISelectedObject
{
    #region Public Properties

    /// <summary>
    /// The type of the selected object
    /// </summary>
    public swSelectType_e ObjectType { get; }

    #region Type Checks

    /// <summary>
    /// True if this object is a feature.
    /// From the feature you can check the specific feature type and get the specific feature from that.
    /// </summary>
    public bool IsFeature => BaseObject as Feature is not null;

    /// <summary>
    /// True if this object is a dimension.
    /// </summary>
    public bool IsDimension => ObjectType == swSelectType_e.swSelDIMENSIONS;

    #endregion

    #endregion

    #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectedObject(object selectedObject) : base(selectedObject)
        {

        }

        public SelectedObject(object selectedObject, swSelectType_e objectType) : base(selectedObject)
        {
            ObjectType = objectType;
        }

        #endregion

    #region Type Cast

        /// <summary>
        /// Casts the object to a <see cref="ModelFeature"/>.
        /// Check with <see cref="IsFeature"/> first to assure that it is this type
        /// </summary>
        /// <param name="action">The feature is passed into this action to be used within it</param>
        [Obsolete("Use AsFeature extension")]
        public void AsFeature(Action<ModelFeature> action)
        {
            // Wrap any error
            SolidDnaErrors.Wrap(() =>
            {
                // Create feature
                using var model = new ModelFeature((Feature) BaseObject);
                // Run action
                action(model);
            },
            SolidDnaErrorTypeCode.SolidWorksModel,
            SolidDnaErrorCode.SolidWorksModelSelectedObjectCastError);
    }

        /// <summary>
        /// Casts the object to a <see cref="ModelDisplayDimension"/>.
        /// Check with <see cref="IsDimension"/> first to assure that it is this type
        /// </summary>
        /// <param name="action">The Dimension is passed into this action to be used within it</param>
        [Obsolete("Use AsDimension extension")]
        public void AsDimension(Action<ModelDisplayDimension> action)
        {
            // Wrap any error
            SolidDnaErrors.Wrap(() =>
            {
                // Create feature
                using var model = new ModelDisplayDimension((IDisplayDimension) BaseObject);
                // Run action
                action(model);
            },
            SolidDnaErrorTypeCode.SolidWorksModel,
            SolidDnaErrorCode.SolidWorksModelSelectedObjectCastError);
    }

    #endregion
}