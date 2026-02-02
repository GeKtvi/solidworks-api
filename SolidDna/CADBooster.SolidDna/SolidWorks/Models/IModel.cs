using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CADBooster.SolidDna;

/// <summary>
/// Represents a SolidWorks model of any type (Drawing, Part or Assembly)
/// </summary>
public interface IModel : ISolidDnaObject<ModelDoc2>
{
    /// <summary>
    /// Contains the current active configuration information
    /// </summary>
    ModelConfiguration ActiveConfiguration { get; }

    /// <summary>
    /// Accesses the current model as an assembly to expose all Assembly API calls.
    /// Check <see cref="IsAssembly"/> before calling into this.
    /// </summary>
    AssemblyDocument Assembly { get; }

    /// <summary>
    /// Get the number of configurations. Returns zero for drawings.
    /// </summary>
    int ConfigurationCount { get; }

    /// <summary>
    /// Get the configuration names. Returns an empty list for drawings.
    /// </summary>
    List<string> ConfigurationNames { get; }

    /// <summary>
    /// Accesses the current model as a drawing to expose all Drawing API calls.
    /// Check <see cref="IsDrawing"/> before calling into this.
    /// </summary>
    DrawingDocument Drawing { get; }

    /// <summary>
    /// Contains extended information about the model
    /// </summary>
    ModelExtension Extension { get; }

    /// <summary>
    /// The absolute file path of this model if it has been saved
    /// </summary>
    string FilePath { get; }

    /// <summary>
    /// Indicates if this file has been saved (so exists on disk).
    /// If not, it's a new model currently only in-memory and will not have a file path.
    /// </summary>
    bool HasBeenSaved { get; }

    /// <summary>
    /// True if this model is an assembly
    /// </summary>
    bool IsAssembly { get; }

    /// <summary>
    /// True if this model is a drawing
    /// </summary>
    bool IsDrawing { get; }

    /// <summary>
    /// True if this model is a part
    /// </summary>
    bool IsPart { get; }

    /// <summary>
    /// The mass properties of the part
    /// </summary>
    MassProperties MassProperties { get; }

    /// <summary>
    /// The source program for this model. Can be SolidWorks Desktop, 3DExperience, xCAD or PartSupply.
    /// Was introduced in SolidWorks 2021.
    /// Not set in the constructor because when you have a model open during startup, the SolidWorks version object is not set yet.
    /// </summary>
    ModelSourceProgram ModelSourceProgram { get; }

    /// <summary>
    /// The type of document such as a part, assembly or drawing
    /// </summary>
    ModelType ModelType { get; }

    /// <summary>
    /// Indicates if this file needs saving (has file changes).
    /// </summary>
    bool NeedsSaving { get; }

    /// <summary>
    /// Accesses the current model as a part to expose all Part API calls.
    /// Check <see cref="IsPart"/> before calling into this.
    /// </summary>
    PartDocument Part { get; }

    /// <summary>
    /// Get the unique 32-character alphanumeric identifier for this model.
    /// </summary>
    string PlmId { get; }

    /// <summary>
    /// The selection manager for this model
    /// </summary>
    SelectionManager SelectionManager { get; }

    /// <summary>
    /// Called when the active configuration has changed
    /// </summary>
    event Action ActiveConfigurationChanged;

    /// <summary>
    /// Called when selected objects are about to be deleted.
    /// </summary>
    event Action DeletingSelection;

    /// <summary>
    /// Called after the active drawing sheet has changed
    /// </summary>
    event Action<string> DrawingActiveSheetChanged;

    /// <summary>
    /// Called before the active drawing sheet changes
    /// </summary>
    event Action<string> DrawingActiveSheetChanging;

    /// <summary>
    /// Called after a drawing sheet was added
    /// </summary>
    event Action<string> DrawingSheetAdded;

    /// <summary>
    /// Called after a drawing sheet was deleted
    /// </summary>
    event Action<string> DrawingSheetDeleted;

    /// <summary>
    /// Called after a file is dropped into the current part/assembly.
    /// </summary>
    event Action<string> FileDropped;

    /// <summary>
    /// Called when a file is about to be dropped into the current part/assembly.
    /// </summary>
    event Action<string> FileDropping;

    /// <summary>
    /// Called after an item is added to the feature tree.
    /// </summary>
    event Action<swNotifyEntityType_e, string> ItemAdded;

    /// <summary>
    /// Called after an item is deleted from the feature tree.
    /// </summary>
    event Action<swNotifyEntityType_e, string> ItemDeleted;

    /// <summary>
    /// Called when an item is about to be deleted from the feature tree.
    /// </summary>
    event Action<swNotifyEntityType_e, string> ItemDeleting;

    /// <summary>
    /// Called as the model is about to be closed
    /// </summary>
    event Action ModelClosing;

    /// <summary>
    /// Called when any of the model properties changes
    /// </summary>
    event Action ModelInformationChanged;

    /// <summary>
    /// Called when the model is first modified since it was last saved.
    /// SOLIDWORKS marks the file as Dirty and sets <see cref="IModelDoc2.GetSaveFlag"/>
    /// </summary>
    event Action ModelModified;

    /// <summary>
    /// Called after a model was rebuilt (any model type) or if the rollback bar position changed (for parts and assemblies).
    /// NOTE: Does not always fire on normal rebuild (Ctrl+B) on assemblies.
    /// </summary>
    event Action ModelRebuilt;

    /// <summary>
    /// Called when the user cancels the save action and <see cref="ModelSaved"/> will not be fired.
    /// </summary>
    event Action ModelSaveCanceled;

    /// <summary>
    /// Called as the model has been saved
    /// </summary>
    event Action ModelSaved;

    /// <summary>
    /// Called before a saved model is saved again (with the same file name).
    /// Allows you to make changes that need to be included in the save.
    /// </summary>
    event Action<string> ModelSaving;

    /// <summary>
    /// Called before a model is saved with a new file name.
    /// Called before the Save As dialog is shown.
    /// Allows you to make changes that need to be included in the save.
    /// </summary>
    event Action<string> ModelSavingAs;

    /// <summary>
    /// Called when the selected objects in the model have changed
    /// </summary>
    event Action SelectionChanged;

    /// <summary>
    /// Make another configuration the active configuration.
    /// </summary>
    /// <param name="configurationName">The name of the configuration to activate.</param>
    /// <returns>True if successful</returns>
    bool ActivateConfiguration(string configurationName);

    /// <summary>
    /// Add a configuration to the model. Pass a parent name to create a derived configuration.
    /// </summary>
    /// <param name="configurationName">The name of the new configuration.</param>
    /// <param name="options">Options for the new configuration.</param>
    /// <param name="parentConfigurationName">The parent configuration name for a derived configuration, or null.</param>
    /// <returns>The new configuration.</returns>
    ModelConfiguration AddConfiguration(string configurationName, NewConfigurationOptions options = 0, string parentConfigurationName = null);

    /// <summary>
    /// Gets all the custom properties in this model including any configuration specific properties
    /// </summary>
    /// <returns>Custom property and the configuration name it belongs to (or null if none)</returns>
    IEnumerable<(string configuration, CustomProperty property)> AllCustomProperties();

    /// <summary>
    /// Casts the current model to an assembly
    /// NOTE: Check the <see cref="ModelType"/> to confirm this model is of the correct type before casting
    /// </summary>
    AssemblyDoc AsAssembly();

    /// <summary>
    /// Casts the current model to a drawing
    /// NOTE: Check the <see cref="ModelType"/> to confirm this model is of the correct type before casting
    /// </summary>
    DrawingDoc AsDrawing();

    /// <summary>
    /// Casts the current model to a part
    /// NOTE: Check the <see cref="ModelType"/> to confirm this model is of the correct type before casting
    /// </summary>
    PartDoc AsPart();

    /// <summary>
    /// Close this model. Releases the COM object so SolidWorks uses less memory.
    /// </summary>
    void Close();

    /// <summary>
    /// Recurses the model for all of its components and subcomponents
    /// </summary>
    IEnumerable<(Component component, int depth)> Components();

    /// <summary>
    /// Gets all the custom properties in this model.
    /// Simply set the Value of the custom property to edit it
    /// </summary>
    /// <param name="action">The custom properties list to be worked on inside the action. NOTE: Do not store references to them outside of this action</param>
    /// <param name="configuration">Specify a configuration to get configuration-specific properties</param>
    void CustomProperties(Action<List<CustomProperty>> action, string configuration = null);

    /// <summary>
    /// Delete a configuration from the model. You cannot delete the active configuration.
    /// </summary>
    /// <param name="configurationName">The name of the configuration to delete.</param>
    /// <returns>True if successful</returns>
    bool DeleteConfiguration(string configurationName);

    /// <summary>
    /// Deletes a custom property by the given name
    /// </summary>
    /// <param name="name">The name of the custom property</param>
    /// <param name="configuration">The configuration to get the properties from, otherwise get custom property</param>
    void DeleteCustomProperty(string name, string configuration = null);

    /// <summary>
    /// Returns a list of full file paths for all dependencies of this model
    /// </summary>
    /// <param name="includeSelf">True to include this file as part of the dependency list</param>
    /// <param name="includeDrawings">True to look for drawings with the same name as their models</param>
    /// <returns>Returns a list of full file paths of all dependencies of this model</returns>
    List<string> Dependencies(bool includeSelf = true, bool includeDrawings = true);

    /// <summary>
    /// Clean up all COM references for this model, its children and anything that was used by this model
    /// </summary>
    void Dispose();

    /// <summary>
    /// Recurses the model for all of its features and sub-features
    /// </summary>
    /// <param name="featureAction">The callback action that is called for each feature in the model</param>
    void Features(Action<ModelFeature, int> featureAction);

    /// <summary>
    /// Finish recording an undo step and (when set to visible) add it to the Undo list.
    /// When you finish a recording before starting one, it fails and returns false.
    /// </summary>
    /// <param name="stepName">The name of the undo step.</param>
    /// <param name="visibility">Whether the step is visible in the Undo/Redo list.</param>
    /// <returns>True when successful.</returns>
    bool FinishRecordingUndoStep(string stepName, ModelUndoStepVisibility visibility);

    /// <summary>
    /// Get a configuration by its name. Throws when it fails.
    /// </summary>
    /// <param name="configurationName">The name of the configuration.</param>
    /// <returns>The configuration.</returns>
    ModelConfiguration GetConfiguration(string configurationName);

    /// <summary>
    /// Gets a custom property by the given name
    /// </summary>
    /// <param name="name">The name of the custom property</param>
    /// <param name="configuration">The configuration to get the properties from, otherwise get custom property</param>
    /// <param name="resolved">True to get the resolved value of the property, false to get the actual text</param>
    /// <returns>The property value.</returns>
    string GetCustomProperty(string name, string configuration = null, bool resolved = false);

    /// <summary>
    /// Read the material from the model
    /// </summary>
    /// <returns>The material, or null if not set or not found.</returns>
    Material GetMaterial();

    /// <summary>
    /// Convert an entity that you got from a Component instance or a drawing view to Model context.
    /// According to the docs, this works for every type that has a persistent ID, but it does not seem to work for configurations and display dimensions.
    /// Works for entities: geometry, features and sketches.
    /// </summary>
    /// <typeparam name="TObjectType">Input and output type of the object.</typeparam>
    /// <param name="modelContextObject">The object from component or view context that must be converted to model context.</param>
    /// <returns>The object converted to the model context, or null when it fails.</returns>
    TObjectType GetObjectInModelContext<TObjectType>(TObjectType modelContextObject) where TObjectType : class;

    /// <summary>
    /// Get a preview bitmap from the saved version of the model file for the specified configuration. Does not include unsaved changes.
    /// </summary>
    /// <param name="configurationName">The configuration name to get the preview for. If null, uses the active configuration.</param>
    /// <returns>A Bitmap containing the preview image</returns>
    Bitmap GetPreviewBitmap(string configurationName = null);

    /// <summary>
    /// Packs up the current model into a flattened structure to a new location
    /// </summary>
    /// <param name="outputFolder">The output folder. If left blank will go to Local App Data folder under a unique name</param>
    /// <param name="filenamePrefix">A prefix to add to all files once packed</param>
    /// <returns>The output folder path.</returns>
    string PackAndGo(string outputFolder = null, string filenamePrefix = "");

    /// <summary>
    /// Saves the current model, with the specified options
    /// </summary>
    /// <param name="options">Any save as options</param>
    /// <returns>The save result.</returns>
    ModelSaveResult Save(SaveAsOptions options = SaveAsOptions.None);

    /// <summary>
    /// Saves a file to the specified path, with the specified options
    /// </summary>
    /// <param name="savePath">The path of the file to save as</param>
    /// <param name="version">The version</param>
    /// <param name="options">Any save as options</param>
    /// <param name="pdfExportData">The PDF Export data if the save as type is a PDF</param>
    /// <returns>The save result.</returns>
    ModelSaveResult SaveAs(string savePath, SaveAsVersion version = SaveAsVersion.CurrentVersion, SaveAsOptions options = SaveAsOptions.None, PdfExportData pdfExportData = null);

    /// <summary>
    /// Get a preview bitmap from the saved version of the model file for the specified configuration. Does not include unsaved changes.
    /// </summary>
    /// <param name="bitmapFilepath">The filepath to save the bitmap to</param>
    /// <param name="configurationName">The configuration name to get the preview for. If null, uses the active configuration.</param>
    void SavePreviewBitmap(string bitmapFilepath, string configurationName = null);

    /// <summary>
    /// Save a new file to 3DExperience or save a modified file.
    /// Can be used as Save and Save As. Is supposed to also support Save As New (Save As copy) but this doesn't seem to work.
    /// If you don't provide a filename or a revision comment for a new file, 3DExperience will assign a filename based on company settings.
    /// If you do provide a filename, it will use that filename unless that name is already in use. Every file on 3DExperience must have a unique filename.
    /// If the filename you specify already exists, 3DExperience will add a number to the end of the filename (or even increment your number suffix) to make it unique.
    /// A popup appears for new files. If the user does not confirm this popup, the file will be saved locally but not be uploaded to 3DExperience.
    /// </summary>
    /// <param name="filename">The preferred filename, not a complete path. May contain a file extension.</param>
    /// <param name="revisionComment">An optional comment about this revision</param>
    /// <returns>The save result.</returns>
    ModelSaveResult SaveTo3DExperience(string filename = null, string revisionComment = null);

    /// <summary>
    /// Sets a custom property to the given value.
    /// If a configuration is specified then the configuration-specific property is set
    /// </summary>
    /// <param name="name">The name of the property</param>
    /// <param name="value">The value of the property</param>
    /// <param name="configuration">The configuration to set the properties from, otherwise set custom property</param>
    void SetCustomProperty(string name, string value, string configuration = null);

    /// <summary>
    /// Sets the material for the model
    /// </summary>
    /// <param name="material">The material</param>
    /// <param name="configuration">The configuration to set the material on, null for the default</param>
    void SetMaterial(Material material, string configuration = null);

    /// <summary>
    /// Start a new Undo step. When you finish recording a step by calling <see cref="FinishRecordingUndoStep"/>, you choose whether to show it in the Undo/Redo list or whether to hide it from the user.
    /// Hidden steps are ignored by SolidWorks and cannot be undone.
    /// If you start recording multiple times before finishing a recording, the first start call is used.
    /// </summary>
    void StartRecordingUndoStep();

    /// <summary>
    /// Returns a user-friendly string with model properties.
    /// </summary>
    string ToString();
}
