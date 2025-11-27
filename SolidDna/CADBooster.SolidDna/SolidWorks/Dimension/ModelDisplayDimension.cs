using SolidWorks.Interop.sldworks;
using System;

namespace CADBooster.SolidDna
{
    public class ModelDisplayDimension : SolidDnaObject<IDisplayDimension>
    {
        #region Private Members

        private readonly Lazy<ModelDimension> _dimension;

        #endregion
        public bool IsArcExtensionLineOrOppositeSide
        {
            get => BaseObject.ArcExtensionLineOrOppositeSide;
            set => BaseObject.ArcExtensionLineOrOppositeSide = value;
        }

        public DimensionArrowSide ArrowSide
        {
            get => (DimensionArrowSide)BaseObject.ArrowSide;
            set => BaseObject.ArrowSide = (int)value;
        }

        public bool IsCenteredText
        {
            get => BaseObject.CenterText;
            set => BaseObject.CenterText = value;
        }

        public bool IsDiametric
        {
            get => BaseObject.Diametric;
            set => BaseObject.Diametric = value;
        }


        public ModelDimension Dimension => _dimension.Value;

        public bool IsDimensionedToInside
        {
            get => BaseObject.DimensionToInside;
            set => BaseObject.DimensionToInside = value;
        }

        public bool IsDisplayedAsChain
        {
            get => BaseObject.DisplayAsChain;
            set => BaseObject.DisplayAsChain = value;
        }

        public bool IsDisplayedAsLinear
        {
            get => BaseObject.DisplayAsLinear;
            set => BaseObject.DisplayAsLinear = value;
        }

        public bool IsExtensionLineExtendedFromCenterOfSet
        {
            get => BaseObject.ExtensionLineExtendsFromCenterOfSet;
            set => BaseObject.ExtensionLineExtendsFromCenterOfSet = value;
        }

        public bool IsExtensionLineSameAsLeaderStyle
        {
            get => BaseObject.ExtensionLineSameAsLeaderStyle;
            set => BaseObject.ExtensionLineSameAsLeaderStyle = value;
        }

        public bool IsExtensionLineUseDocumentDisplay
        {
            get => BaseObject.ExtensionLineUseDocumentDisplay;
            set => BaseObject.ExtensionLineUseDocumentDisplay = value;
        }

        public bool IsForeshortened
        {
            get => BaseObject.Foreshortened;
            set => BaseObject.Foreshortened = value;
        }

        public bool IsElevated
        {
            get => BaseObject.Elevation;
            set => BaseObject.Elevation = value;
        }

        public DimensionEndSymbol EndSymbol
        {
            get => (DimensionEndSymbol)BaseObject.EndSymbol;
            set => BaseObject.EndSymbol = (int)value;
        }

        public bool IsGridBubbled
        {
            get => BaseObject.GridBubble;
            set => BaseObject.GridBubble = value;
        }

        public TextJustification HorizontalJustification
        {
            get => (TextJustification)BaseObject.HorizontalJustification;
            set => BaseObject.HorizontalJustification = (int)value;
        }

        public bool IsInspection
        {
            get => BaseObject.Inspection;
            set => BaseObject.Inspection = value;
        }

        public bool IsLowerInspection
        {
            get => BaseObject.LowerInspection;
            set => BaseObject.LowerInspection = value;
        }

        public bool IsLinked => BaseObject.IsLinked;
        public bool IsJogged
        {
            get => BaseObject.Jogged;
            set => BaseObject.Jogged = value;
        }

        public LeaderLineVisibility LeaderVisibility
        {
            get => (LeaderLineVisibility)BaseObject.LeaderVisibility;
            set => BaseObject.LeaderVisibility = (int)value;
        }

        public bool IsMarkedForDrawing
        {
            get => BaseObject.MarkedForDrawing;
            set => BaseObject.MarkedForDrawing = value;
        }

        public double MaxWitnessLineLength
        {
            get => BaseObject.MaxWitnessLineLength;
            set => BaseObject.MaxWitnessLineLength = value;
        }

        public bool IsOffsetText
        {
            get => BaseObject.OffsetText;
            set => BaseObject.OffsetText = value;
        }

        public double Scale
        {
            get => BaseObject.Scale2;
            set => BaseObject.Scale2 = value;
        }

        public bool IsShortenedRadius
        {
            get => BaseObject.ShortenedRadius;
            set => BaseObject.ShortenedRadius = value;
        }

        public string Prefix
        {
            get => GetText(DimensionTextParts.Prefix);
            set => SetText(DimensionTextParts.Prefix, value);
        }

        public string Suffix
        {
            get => GetText(DimensionTextParts.Suffix);
            set => SetText(DimensionTextParts.Suffix, value);
        }

        public string Text
        {
            get
            {
                var prefix = GetText(DimensionTextParts.Prefix);
                var suffix = GetText(DimensionTextParts.Suffix);
                
                return string.IsNullOrEmpty(prefix) 
                    ? suffix ?? "" 
                    : string.IsNullOrEmpty(suffix) 
                        ? prefix 
                        : prefix + " " + suffix;
            }
            set => SetText(DimensionTextParts.All, value);
        }

        public bool IsDimensionValueShown
        {
            get => BaseObject.ShowDimensionValue;
            set => BaseObject.ShowDimensionValue = value;
        }

        public bool IsLowerParenthesisShown
        {
            get => BaseObject.ShowLowerParenthesis;
            set => BaseObject.ShowLowerParenthesis = value;
        }

        public bool IsParenthesisShown
        {
            get => BaseObject.ShowParenthesis;
            set => BaseObject.ShowParenthesis = value;
        }

        public bool IsSmartWitness
        {
            get => BaseObject.SmartWitness;
            set => BaseObject.SmartWitness = value;
        }

        public bool IsSolidLeader
        {
            get => BaseObject.SolidLeader;
            set => BaseObject.SolidLeader = value;
        }

        public bool IsSplit
        {
            get => BaseObject.Split;
            set => BaseObject.Split = value;
        }

        /// <summary>
        /// The selection name for this dimension that can be used to select it.
        /// For example D1@Sketch1
        /// </summary>
        public string SelectionName => BaseObject.GetNameForSelection();

        public bool IsAutoArcLengthLeader => BaseObject.GetAutoArcLengthLeader();
        public double BentLeaderLength => BaseObject.GetBentLeaderLength();

        public int FractionValue => BaseObject.GetFractionValue();
        public string LinkedText => BaseObject.GetLinkedText();
        public string LowerText => BaseObject.GetLowerText();
        public bool IsOverridden => BaseObject.GetOverride();
        public double OverrideValue => BaseObject.GetOverrideValue();
        public int PrimaryPrecision => BaseObject.GetPrimaryPrecision2();
        public int PrimaryTolerancePrecision => BaseObject.GetPrimaryTolPrecision2();
        public int AlternateTolerancePrecision => BaseObject.GetAlternateTolPrecision2();
        public bool IsRoundToFraction => BaseObject.GetRoundToFraction();
        public bool IsSecondArrow => BaseObject.GetSecondArrow();
        public bool IsSupportsGenericText => BaseObject.GetSupportsGenericText();
        public bool IsDocumentArrowHeadStyle => BaseObject.GetUseDocArrowHeadStyle();
        public bool IsDocumentBentLeaderLength => BaseObject.GetUseDocBentLeaderLength();
        public bool IsDocumentDual => BaseObject.GetUseDocDual();

        // This is representation of (PropertyManager => Dimension => Leaders => Custom Text Position) checkbox in UI 
        public bool IsDocumentTextPosition
        {
            get => BaseObject.GetUseDocBrokenLeader();
            set
            {
                var result = BaseObject.SetBrokenLeader2(value, (int)DisplayDimensionLeaderTextPosition.SolidLeaderAligned);
                HandleSetBrokenLeaderResult(result);
            }
        }

        public bool IsRunBidirectionally
        {
            get => BaseObject.RunBidirectionally;
            set => BaseObject.RunBidirectionally = value;
        }

        // This is representation of (PropertyManager => Dimension => Leaders => Custom Text Position) enum in UI 
        public DisplayDimensionLeaderTextPosition TextPosition
        {
            get => (DisplayDimensionLeaderTextPosition)BaseObject.GetBrokenLeader2();
            set
            {
                var useDocumentPosition = value == DisplayDimensionLeaderTextPosition.Default;

                var result = BaseObject.SetBrokenLeader2(useDocumentPosition, (int)value);
                HandleSetBrokenLeaderResult(result);
            }
        }

        public DisplayDimensionType Type => (DisplayDimensionType)BaseObject.Type2;

        public VerticalJustification VerticalJustification
        {
            get => (VerticalJustification)BaseObject.VerticalJustification;
            set => BaseObject.VerticalJustification = (int)value;
        }

        public WitnessLineVisibility WitnessVisibility
        {
            get => (WitnessLineVisibility)BaseObject.WitnessVisibility;
            set => BaseObject.WitnessVisibility = (int)value;
        }

        public ModelDisplayDimension(IDisplayDimension dimension) : base(dimension)
        {
            _dimension = new Lazy<ModelDimension>(() => new ModelDimension(BaseObject.IGetDimension()));
        }

        /// <summary>
        /// Gets chamfer-specific operations for this display dimension.
        /// </summary>
        public ModelDisplayDimensionChamfer Chamfer => Dimension.IsChamferDimension ? new ModelDisplayDimensionChamfer(this) : null;

        /// <summary>
        /// <see cref="DimensionTextParts.All"/> Not supported
        /// </summary>
        /// <param name="whichText"><see cref="DimensionTextParts.All"/> is not a valid value for the WhichText parameter for this method.</param>
        /// <returns></returns>
        public string GetText(DimensionTextParts whichText) 
            => whichText == DimensionTextParts.All
                ? throw new SolidDnaException(SolidDnaErrors.CreateError(
                    SolidDnaErrorTypeCode.SolidWorksModel,
                    SolidDnaErrorCode.SolidWorksModelError,
                    $"{nameof(DimensionTextParts.All)} is not supported for {nameof(GetText)}. Use it in {nameof(SetText)} method."))
                : BaseObject.GetText((int)whichText);

        public void SetText(DimensionTextParts whichText, string text) => BaseObject.SetText((int)whichText, text);

        public bool IsExplementaryAngle => BaseObject.ExplementaryAngle();
        public bool IsSupplementaryAngle => BaseObject.SupplementaryAngle();
        public bool IsVerticallyOppositeAngle => BaseObject.VerticallyOppositeAngle();

        public bool IsAutoJogOrdinate => BaseObject.AutoJogOrdinate();

        /// <summary>
        /// Sets the linear dimension extension line to be jogged.
        /// </summary>
        /// <param name="witnessIndex">Index of the linear dimension extension line to jog</param>
        /// <param name="jogged">True whether the linear dimension extension is jogged, false if not</param>
        /// <param name="offset1">First line segment of the linear dimension extension line</param>
        /// <param name="offset2">Second line segment of the linear dimension extension line; this is the line segment to jog</param>
        /// <param name="offset1to2">Distance by which to offset Offset1 and Offset2 for the jog</param>
        /// <returns>True if successful, false otherwise</returns>
        /// <remarks>
        /// Call IModelView::GraphicsRedraw after calling this method to redraw the graphics area.
        /// </remarks>
        public bool SetJogParameters(short witnessIndex, bool jogged, double offset1, double offset2, double offset1to2) => BaseObject.SetJogParameters(witnessIndex, jogged, offset1, offset2, offset1to2);

        public bool IsHoleCallout => BaseObject.IsHoleCallout();
        public bool IsReferenceDimension => BaseObject.IsReferenceDim();

        private void HandleSetBrokenLeaderResult(int result)
        {
            if (result == -1) // Command failed, no broken leader values were set
                throw new SolidDnaException(SolidDnaErrors.CreateError(
                    SolidDnaErrorTypeCode.SolidWorksModel,
                    SolidDnaErrorCode.SolidWorksModelError,
                    "Command failed, no broken leader values were set"));
            if (result == 1) // Specified broken value is invalid, the display dimension was set to use the document default 
                throw new SolidDnaException(SolidDnaErrors.CreateError(
                    SolidDnaErrorTypeCode.SolidWorksModel,
                    SolidDnaErrorCode.SolidWorksModelError,
                    "Specified broken value is invalid, the display dimension was set to use the document default"));
            // result == 0 means success
        }

        // TODO: Fix SetUnits and GetUnits method signatures - need to verify correct API
        // public void SetUnits(bool roundToFraction, int uType, int fractBase, int fractDenom, bool roundToFraction2) 
        //     => BaseObject.SetUnits(roundToFraction, uType, fractBase, fractDenom, roundToFraction2);

        // public void GetUnits(out bool roundToFraction, out int uType, out int fractBase, out int fractDenom)
        //     => BaseObject.GetUnits(out roundToFraction, out uType, out fractBase, out fractDenom);

        // TODO: Wrap complex SolidWorks objects
        // public Annotation GetAnnotation() => BaseObject.IGetAnnotation();
        // public ??? GetTextFormat() => BaseObject.IGetTextFormat();
        // public ??? GetTextPosition() => BaseObject.IGetTextPosition();
        // public ??? GetTextRefPosition() => BaseObject.IGetTextRefPosition();
        // public ??? GetLeaderInfo() => BaseObject.IGetLeaderInfo();
        // public ??? GetWitnessLineInfo() => BaseObject.IGetWitnessLineInfo();
        // public ??? GetArrowHeadInfo() => BaseObject.IGetArrowHeadInfo();
        // public ??? GetToleranceInfo() => BaseObject.IGetToleranceInfo();
        // public ??? GetPrecisionInfo() => BaseObject.IGetPrecisionInfo();
        // public ??? GetDisplayInfo() => BaseObject.IGetDisplayInfo();
        // public ??? GetDisplayData() => BaseObject.IGetDisplayData();
        // public ??? GetDefinitionTransform() => BaseObject.IGetDefinitionTransform();
        // public ??? GetHoleCalloutVariables() => BaseObject.IGetHoleCalloutVariables();
        // public ??? GetJogParameters() => BaseObject.IGetJogParameters();
        // public ??? GetNext5() => BaseObject.IGetNext5();
        // public ??? GetTextFormatItems() => BaseObject.IGetTextFormatItems();
        // public ??? IAddDisplayEnt() => BaseObject.IAddDisplayEnt();

        // TODO: Methods with complex return types or multiple parameters
        // public ??? ArrowHeadStyle => BaseObject.GetArrowHeadStyle2(ref style1, ref style2);
        // public ??? Fraction => (swFractionDisplay_e)BaseObject.GetFractionBase();
        // public ??? OrdinateDimensionArrowSize => BaseObject.GetOrdinateDimensionArrowSize(out useDoc, out size);

        #region Dispose

        public override void Dispose()
        {
            // Dispose lazy-loaded child objects
            if (_dimension.IsValueCreated == true)
                _dimension.Value.Dispose();

            // Dispose self
            base.Dispose();
        }

        #endregion
    }
}
