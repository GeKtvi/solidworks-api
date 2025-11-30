using SolidWorks.Interop.sldworks;
using System;

namespace CADBooster.SolidDna
{
    /// <summary>
    /// Represents a display dimension in a SolidWorks model.
    /// A display dimension is an instance of a dimension displayed in parts, assemblies, drawings, and sensors.
    /// </summary>
    /// <remarks>
    /// This class wraps the SolidWorks API <see href="https://help.solidworks.com/2026/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IDisplayDimension_members.html">IDisplayDimension</see> interface.
    /// </remarks>
    public class ModelDisplayDimension : SolidDnaObject<IDisplayDimension>
    {
        #region Private Members

        private readonly Lazy<ModelDimension> _dimension;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the underlying <see cref="ModelDimension"/> for this display dimension.
        /// </summary>
        public ModelDimension Dimension => _dimension.Value;

        /// <summary>
        /// Gets or sets whether the arc extension line is on the opposite side.
        /// </summary>
        public bool IsArcExtensionLineOrOppositeSide
        {
            get => BaseObject.ArcExtensionLineOrOppositeSide;
            set => BaseObject.ArcExtensionLineOrOppositeSide = value;
        }

        /// <summary>
        /// Gets or sets the arrow side for this dimension.
        /// </summary>
        public DimensionArrowSide ArrowSide
        {
            get => (DimensionArrowSide)BaseObject.ArrowSide;
            set => BaseObject.ArrowSide = (int)value;
        }

        /// <summary>
        /// Gets or sets whether the dimension text is centered.
        /// </summary>
        public bool IsCenteredText
        {
            get => BaseObject.CenterText;
            set => BaseObject.CenterText = value;
        }

        /// <summary>
        /// Gets or sets whether this is a diametric dimension.
        /// </summary>
        public bool IsDiametric
        {
            get => BaseObject.Diametric;
            set => BaseObject.Diametric = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is dimensioned to the inside.
        /// </summary>
        public bool IsDimensionedToInside
        {
            get => BaseObject.DimensionToInside;
            set => BaseObject.DimensionToInside = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is displayed as a chain.
        /// </summary>
        public bool IsDisplayedAsChain
        {
            get => BaseObject.DisplayAsChain;
            set => BaseObject.DisplayAsChain = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is displayed as linear.
        /// </summary>
        public bool IsDisplayedAsLinear
        {
            get => BaseObject.DisplayAsLinear;
            set => BaseObject.DisplayAsLinear = value;
        }

        /// <summary>
        /// Gets or sets whether the extension line extends from the center of the set.
        /// </summary>
        public bool IsExtensionLineExtendedFromCenterOfSet
        {
            get => BaseObject.ExtensionLineExtendsFromCenterOfSet;
            set => BaseObject.ExtensionLineExtendsFromCenterOfSet = value;
        }

        /// <summary>
        /// Gets or sets whether the extension line uses the same style as the leader.
        /// </summary>
        public bool IsExtensionLineSameAsLeaderStyle
        {
            get => BaseObject.ExtensionLineSameAsLeaderStyle;
            set => BaseObject.ExtensionLineSameAsLeaderStyle = value;
        }

        /// <summary>
        /// Gets or sets whether the extension line uses the document display settings.
        /// </summary>
        public bool IsExtensionLineUseDocumentDisplay
        {
            get => BaseObject.ExtensionLineUseDocumentDisplay;
            set => BaseObject.ExtensionLineUseDocumentDisplay = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is foreshortened.
        /// </summary>
        public bool IsForeshortened
        {
            get => BaseObject.Foreshortened;
            set => BaseObject.Foreshortened = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is elevated.
        /// </summary>
        public bool IsElevated
        {
            get => BaseObject.Elevation;
            set => BaseObject.Elevation = value;
        }

        /// <summary>
        /// Gets or sets the end symbol for this dimension.
        /// </summary>
        public DimensionEndSymbol EndSymbol
        {
            get => (DimensionEndSymbol)BaseObject.EndSymbol;
            set => BaseObject.EndSymbol = (int)value;
        }

        /// <summary>
        /// Gets or sets whether the dimension uses a grid bubble.
        /// </summary>
        public bool IsGridBubbled
        {
            get => BaseObject.GridBubble;
            set => BaseObject.GridBubble = value;
        }

        /// <summary>
        /// Gets or sets the horizontal justification of the dimension text.
        /// </summary>
        public TextJustification HorizontalJustification
        {
            get => (TextJustification)BaseObject.HorizontalJustification;
            set => BaseObject.HorizontalJustification = (int)value;
        }

        /// <summary>
        /// Gets or sets whether this is an inspection dimension.
        /// </summary>
        public bool IsInspection
        {
            get => BaseObject.Inspection;
            set => BaseObject.Inspection = value;
        }

        /// <summary>
        /// Gets or sets whether this is a lower inspection dimension.
        /// </summary>
        public bool IsLowerInspection
        {
            get => BaseObject.LowerInspection;
            set => BaseObject.LowerInspection = value;
        }

        /// <summary>
        /// Gets whether the dimension text is linked.
        /// </summary>
        public bool IsLinked => BaseObject.IsLinked;

        /// <summary>
        /// Gets or sets whether the dimension is jogged.
        /// </summary>
        public bool IsJogged
        {
            get => BaseObject.Jogged;
            set => BaseObject.Jogged = value;
        }

        /// <summary>
        /// Gets or sets the leader line visibility.
        /// </summary>
        public LeaderLineVisibility LeaderVisibility
        {
            get => (LeaderLineVisibility)BaseObject.LeaderVisibility;
            set => BaseObject.LeaderVisibility = (int)value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is marked for drawing.
        /// </summary>
        public bool IsMarkedForDrawing
        {
            get => BaseObject.MarkedForDrawing;
            set => BaseObject.MarkedForDrawing = value;
        }

        /// <summary>
        /// Gets or sets the maximum witness line length.
        /// </summary>
        public double MaxWitnessLineLength
        {
            get => BaseObject.MaxWitnessLineLength;
            set => BaseObject.MaxWitnessLineLength = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension text is offset.
        /// </summary>
        public bool IsOffsetText
        {
            get => BaseObject.OffsetText;
            set => BaseObject.OffsetText = value;
        }

        /// <summary>
        /// Gets or sets the scale of the dimension.
        /// </summary>
        public double Scale
        {
            get => BaseObject.Scale2;
            set => BaseObject.Scale2 = value;
        }

        /// <summary>
        /// Gets or sets whether this is a shortened radius dimension.
        /// </summary>
        public bool IsShortenedRadius
        {
            get => BaseObject.ShortenedRadius;
            set => BaseObject.ShortenedRadius = value;
        }

        /// <summary>
        /// Gets or sets the prefix text for the dimension.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="GetText"/> and <see cref="SetText"/> with <see cref="DimensionTextParts.Prefix"/>.
        /// </remarks>
        public string Prefix
        {
            get => GetText(DimensionTextParts.Prefix);
            set => SetText(DimensionTextParts.Prefix, value);
        }

        /// <summary>
        /// Gets or sets the suffix text for the dimension.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="GetText"/> and <see cref="SetText"/> with <see cref="DimensionTextParts.Suffix"/>.
        /// </remarks>
        public string Suffix
        {
            get => GetText(DimensionTextParts.Suffix);
            set => SetText(DimensionTextParts.Suffix, value);
        }

        /// <summary>
        /// Gets or sets the dimension text.
        /// </summary>
        /// <remarks>
        /// Note: Getting returns the prefix text (since <see cref="DimensionTextParts.All"/> is not supported for <see cref="GetText"/>).
        /// Setting uses <see cref="DimensionTextParts.All"/> to set all text parts.
        /// </remarks>
        public string Text
        {
            get => GetText(DimensionTextParts.Prefix); // "All" not supported, but suffix is most used text in dimension
            set => SetText(DimensionTextParts.All, value);
        }

        /// <summary>
        /// Gets or sets whether the dimension value is shown.
        /// </summary>
        public bool IsDimensionValueShown
        {
            get => BaseObject.ShowDimensionValue;
            set => BaseObject.ShowDimensionValue = value;
        }

        /// <summary>
        /// Gets or sets whether the lower parenthesis is shown.
        /// </summary>
        public bool IsLowerParenthesisShown
        {
            get => BaseObject.ShowLowerParenthesis;
            set => BaseObject.ShowLowerParenthesis = value;
        }

        /// <summary>
        /// Gets or sets whether the parenthesis is shown.
        /// </summary>
        public bool IsParenthesisShown
        {
            get => BaseObject.ShowParenthesis;
            set => BaseObject.ShowParenthesis = value;
        }

        /// <summary>
        /// Gets or sets whether smart witness lines are used.
        /// </summary>
        public bool IsSmartWitness
        {
            get => BaseObject.SmartWitness;
            set => BaseObject.SmartWitness = value;
        }

        /// <summary>
        /// Gets or sets whether a solid leader is used.
        /// </summary>
        public bool IsSolidLeader
        {
            get => BaseObject.SolidLeader;
            set => BaseObject.SolidLeader = value;
        }

        /// <summary>
        /// Gets or sets whether the dimension is split.
        /// </summary>
        public bool IsSplit
        {
            get => BaseObject.Split;
            set => BaseObject.Split = value;
        }

        /// <summary>
        /// Gets the selection name for this dimension that can be used to select it.
        /// For example: D1@Sketch1
        /// </summary>
        public string SelectionName => BaseObject.GetNameForSelection();

        /// <summary>
        /// Gets whether the arc length leader is automatically generated.
        /// </summary>
        public bool IsAutoArcLengthLeader => BaseObject.GetAutoArcLengthLeader();

        /// <summary>
        /// Gets the bent leader length.
        /// </summary>
        public double BentLeaderLength => BaseObject.GetBentLeaderLength();

        /// <summary>
        /// Gets the fraction value.
        /// </summary>
        public int FractionValue => BaseObject.GetFractionValue();

        /// <summary>
        /// Gets the linked text.
        /// </summary>
        public string LinkedText => BaseObject.GetLinkedText();

        /// <summary>
        /// Gets the lower text.
        /// </summary>
        public string LowerText => BaseObject.GetLowerText();

        /// <summary>
        /// Gets whether the dimension value is overridden.
        /// </summary>
        public bool IsOverridden => BaseObject.GetOverride();

        /// <summary>
        /// Gets the override value.
        /// </summary>
        public double OverrideValue => BaseObject.GetOverrideValue();

        /// <summary>
        /// Gets the primary precision.
        /// </summary>
        public int PrimaryPrecision => BaseObject.GetPrimaryPrecision2();

        /// <summary>
        /// Gets the primary tolerance precision.
        /// </summary>
        public int PrimaryTolerancePrecision => BaseObject.GetPrimaryTolPrecision2();

        /// <summary>
        /// Gets the alternate tolerance precision.
        /// </summary>
        public int AlternateTolerancePrecision => BaseObject.GetAlternateTolPrecision2();

        /// <summary>
        /// Gets whether the dimension rounds to fraction.
        /// </summary>
        public bool IsRoundToFraction => BaseObject.GetRoundToFraction();

        /// <summary>
        /// Gets whether a second arrow is shown.
        /// </summary>
        public bool IsSecondArrow => BaseObject.GetSecondArrow();

        /// <summary>
        /// Gets whether generic text is supported.
        /// </summary>
        public bool IsSupportsGenericText => BaseObject.GetSupportsGenericText();

        /// <summary>
        /// Gets whether the document arrow head style is used.
        /// </summary>
        public bool IsDocumentArrowHeadStyle => BaseObject.GetUseDocArrowHeadStyle();

        /// <summary>
        /// Gets whether the document bent leader length is used.
        /// </summary>
        public bool IsDocumentBentLeaderLength => BaseObject.GetUseDocBentLeaderLength();

        /// <summary>
        /// Gets whether the document dual setting is used.
        /// </summary>
        public bool IsDocumentDual => BaseObject.GetUseDocDual();

        /// <summary>
        /// Gets or sets whether the document text position is used.
        /// This represents the "Custom Text Position" checkbox in PropertyManager => Dimension => Leaders.
        /// </summary>
        public bool IsDocumentTextPosition
        {
            get => BaseObject.GetUseDocBrokenLeader();
            set
            {
                var result = BaseObject.SetBrokenLeader2(value, (int)DisplayDimensionLeaderTextPosition.SolidLeaderAligned);
                HandleSetBrokenLeaderResult(result);
            }
        }

        /// <summary>
        /// Gets or sets whether the dimension runs bidirectionally.
        /// </summary>
        public bool IsRunBidirectionally
        {
            get => BaseObject.RunBidirectionally;
            set => BaseObject.RunBidirectionally = value;
        }

        /// <summary>
        /// Gets or sets the text position for the leader.
        /// This represents the "Custom Text Position" enum in PropertyManager => Dimension => Leaders.
        /// </summary>
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

        /// <summary>
        /// Gets the type of display dimension.
        /// </summary>
        public DisplayDimensionType Type => (DisplayDimensionType)BaseObject.Type2;

        /// <summary>
        /// Gets or sets the vertical justification of the dimension text.
        /// </summary>
        public VerticalJustification VerticalJustification
        {
            get => (VerticalJustification)BaseObject.VerticalJustification;
            set => BaseObject.VerticalJustification = (int)value;
        }

        /// <summary>
        /// Gets or sets the witness line visibility.
        /// </summary>
        public WitnessLineVisibility WitnessVisibility
        {
            get => (WitnessLineVisibility)BaseObject.WitnessVisibility;
            set => BaseObject.WitnessVisibility = (int)value;
        }

        /// <summary>
        /// Gets chamfer-specific operations for this display dimension.
        /// Returns null if this is not a chamfer dimension.
        /// </summary>
        public ModelDisplayDimensionChamfer Chamfer => Dimension.IsChamferDimension ? new ModelDisplayDimensionChamfer(this) : null;

        /// <summary>
        /// Gets whether this is an explementary angle.
        /// </summary>
        public bool IsExplementaryAngle => BaseObject.ExplementaryAngle();

        /// <summary>
        /// Gets whether this is a supplementary angle.
        /// </summary>
        public bool IsSupplementaryAngle => BaseObject.SupplementaryAngle();

        /// <summary>
        /// Gets whether this is a vertically opposite angle.
        /// </summary>
        public bool IsVerticallyOppositeAngle => BaseObject.VerticallyOppositeAngle();

        /// <summary>
        /// Gets whether this is an auto jog ordinate dimension.
        /// </summary>
        public bool IsAutoJogOrdinate => BaseObject.AutoJogOrdinate();

        /// <summary>
        /// Gets whether this is a hole callout.
        /// </summary>
        public bool IsHoleCallout => BaseObject.IsHoleCallout();

        /// <summary>
        /// Gets whether this is a reference dimension.
        /// </summary>
        public bool IsReferenceDimension => BaseObject.IsReferenceDim();

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="ModelDisplayDimension"/>.
        /// </summary>
        /// <param name="dimension">The underlying SolidWorks <see cref="IDisplayDimension"/> object.</param>
        public ModelDisplayDimension(IDisplayDimension dimension) : base(dimension)
        {
            _dimension = new Lazy<ModelDimension>(() => new ModelDimension(BaseObject.IGetDimension()));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the text for the specified dimension text part.
        /// </summary>
        /// <param name="whichText">The dimension text part to get. <see cref="DimensionTextParts.All"/> is not supported for this method.</param>
        /// <returns>The text for the specified dimension text part.</returns>
        /// <exception cref="SolidDnaException">Thrown when <see cref="DimensionTextParts.All"/> is specified.</exception>
        /// <remarks>
        /// Note: <see cref="DimensionTextParts.All"/> is not supported for this method. It is useful only in <see cref="SetText"/> method.
        /// </remarks>
        public string GetText(DimensionTextParts whichText) 
            => whichText == DimensionTextParts.All
                ? throw new SolidDnaException(SolidDnaErrors.CreateError(
                    SolidDnaErrorTypeCode.SolidWorksModel,
                    SolidDnaErrorCode.SolidWorksModelError,
                    $"{nameof(DimensionTextParts.All)} is not supported for {nameof(GetText)}. Use it in {nameof(SetText)} method."))
                : BaseObject.GetText((int)whichText);

        /// <summary>
        /// Sets the text for the specified dimension text part.
        /// </summary>
        /// <param name="whichText">The dimension text part to set. Can be <see cref="DimensionTextParts.All"/> to set all text parts.</param>
        /// <param name="text">The text to set.</param>
        public void SetText(DimensionTextParts whichText, string text) => BaseObject.SetText((int)whichText, text);

        /// <summary>
        /// Sets the linear dimension extension line to be jogged.
        /// </summary>
        /// <param name="witnessIndex">Index of the linear dimension extension line to jog.</param>
        /// <param name="jogged">True if the linear dimension extension is jogged, false if not.</param>
        /// <param name="offset1">First line segment of the linear dimension extension line.</param>
        /// <param name="offset2">Second line segment of the linear dimension extension line; this is the line segment to jog.</param>
        /// <param name="offset1to2">Distance by which to offset Offset1 and Offset2 for the jog.</param>
        /// <returns>True if successful, false otherwise.</returns>
        /// <remarks>
        /// Call IModelView::GraphicsRedraw after calling this method to redraw the graphics area.
        /// </remarks>
        public bool SetJogParameters(short witnessIndex, bool jogged, double offset1, double offset2, double offset1to2) => BaseObject.SetJogParameters(witnessIndex, jogged, offset1, offset2, offset1to2);

        #endregion

        #region Private Methods

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

        #endregion

        #region ToString

        /// <summary>
        /// Returns a string representation of this display dimension.
        /// </summary>
        /// <returns>The selection name of the dimension (e.g., "D1@Sketch1").</returns>
        public override string ToString() => SelectionName;

        #endregion

        #region Not Implemented members

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
        
        #endregion

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
