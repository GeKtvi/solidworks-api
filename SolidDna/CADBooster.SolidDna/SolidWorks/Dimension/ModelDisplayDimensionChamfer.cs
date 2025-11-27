using SolidWorks.Interop.sldworks;
using System;

namespace CADBooster.SolidDna
{
    public class ModelDisplayDimensionChamfer
    {
        private readonly ModelDisplayDimension _parent;

        internal ModelDisplayDimensionChamfer(ModelDisplayDimension parent)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>
        /// Gets or sets the precision of the length value in a chamfer display dimension.
        /// Number of decimal places to display for the value at the specified index
        /// </summary>
        public int LengthPrecision
        {
            get => _parent.UnsafeObject.ChamferPrecision[0];
            set => _parent.UnsafeObject.ChamferPrecision[0] = value;
        }

        /// <summary>
        /// Gets or sets the precision of the angle value in a chamfer display dimension.
        /// Number of decimal places to display for the value at the specified index
        /// </summary>
        public int AnglePrecision
        {
            get => _parent.UnsafeObject.ChamferPrecision[1];
            set => _parent.UnsafeObject.ChamferPrecision[1] = value;
        }

        /// <summary>
        /// Gets or sets the chamfer text style.
        /// </summary>
        public ChamferTextStyle TextStyle
        {
            get => (ChamferTextStyle)_parent.UnsafeObject.ChamferTextStyle;
            set => _parent.UnsafeObject.ChamferTextStyle = (int)value;
        }

        // TODO: units may be wrapped to its representation class, not just int id
        // public ??? ChamferUnits => BaseObject.GetChamferUnits(out lengthUnit, out angleUnit)
    }
}
