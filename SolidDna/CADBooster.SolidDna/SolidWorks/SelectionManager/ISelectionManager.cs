using System;
using System.Collections.Generic;

namespace CADBooster.SolidDna;

/// <summary>
/// Interface for a SolidWorks selection manager, used for selecting, deselecting and getting selected objects.
/// Enables mocking for unit testing code that consumes selection operations.
/// </summary>
public interface ISelectionManager
{
    /// <summary>
    /// Get the number of selected objects in the current model.
    /// </summary>
    int SelectedObjectsCount { get; }

    /// <summary>
    /// Deselect all selected objects.
    /// </summary>
    void DeselectAll();

    /// <summary>
    /// Deselect the object at a given index with an optional selection mark.
    /// </summary>
    /// <param name="index">The index of the selected object. Is 1-based.</param>
    /// <param name="mark">The mark that the item was originally selected with.</param>
    void DeselectAt(int index, int mark = -1);

    /// <summary>
    /// Releases resources used by the selection manager.
    /// </summary>
    void Dispose();

    /// <summary>
    /// Enumerate through all selected objects in the current model.
    /// Allows you to stop enumerating early if needed.
    /// </summary>
    /// <returns>An enumerable of selected objects</returns>
    IEnumerable<SelectedObject> GetSelectedObjects();

    /// <summary>
    /// Enumerate through all selected objects in the current model with a certain selection mark.
    /// Allows you to stop enumerating early if needed.
    /// </summary>
    /// <param name="mark">Only include objects with this selection mark</param>
    /// <returns>An enumerable of selected objects</returns>
    IEnumerable<SelectedObject> GetSelectedObjects(int mark);

    /// <summary>
    /// Select all objects in the model. Does not include graphic bodies.
    /// </summary>
    void SelectAll();

    /// <summary>
    /// Perform an action on all selected objects in the current model.
    /// </summary>
    /// <param name="action">The selected objects list to be worked on inside the action.
    /// NOTE: Do not store references to these objects outside of this action</param>
    void SelectedObjects(Action<List<SelectedObject>> action);

    /// <summary>
    /// Select a single object in the current model.
    /// </summary>
    /// <param name="selectedObject">The object to select.</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI.</param>
    void SelectObject(SelectedObject selectedObject, bool updateUserInterface = true);

    /// <summary>
    /// Select a single object in the current model with optional selection data.
    /// </summary>
    /// <param name="selectedObject">The object to select.</param>
    /// <param name="selectionData">Optional selection data (e.g. mark, callout).</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI.</param>
    void SelectObject(SelectedObject selectedObject, SelectionData selectionData, bool updateUserInterface = true);

    /// <summary>
    /// Select an object by name and selection type string.
    /// </summary>
    /// <param name="name">The name of the object.</param>
    /// <param name="selectionType">The SolidWorks selection type string.</param>
    void SelectObject(string name, string selectionType);

    /// <summary>
    /// Select an object by name and selection type string with optional selection data.
    /// </summary>
    /// <param name="name">The name of the object.</param>
    /// <param name="selectionType">The SolidWorks selection type string.</param>
    /// <param name="selectionData">Optional selection data (e.g. mark, callout).</param>
    void SelectObject(string name, string selectionType, SelectionData selectionData);

    /// <summary>
    /// Select multiple objects in the current model.
    /// </summary>
    /// <param name="selectedObjects">The objects to select.</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI.</param>
    void SelectObjects(IEnumerable<SelectedObject> selectedObjects, bool updateUserInterface = true);

    /// <summary>
    /// Select multiple objects in the current model with optional selection data.
    /// </summary>
    /// <param name="selectedObjects">The objects to select.</param>
    /// <param name="selectionData">Optional selection data (e.g. mark, callout).</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI.</param>
    void SelectObjects(IEnumerable<SelectedObject> selectedObjects, SelectionData selectionData, bool updateUserInterface = true);

    /// <summary>
    /// Temporarily select the given objects. Selection is reverted when the returned disposable is disposed.
    /// </summary>
    /// <param name="selectedObjects">The objects to temporarily select.</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI.</param>
    /// <returns>A disposable that restores the previous selection when disposed.</returns>
    IDisposable TemporarySelectObjects(IEnumerable<SelectedObject> selectedObjects, bool updateUserInterface = true);

    /// <summary>
    /// Temporarily select the given objects with optional selection data. Selection is reverted when the returned disposable is disposed.
    /// </summary>
    /// <param name="selectedObjects">The objects to temporarily select.</param>
    /// <param name="selectionData">Optional selection data (e.g. mark, callout).</param>
    /// <param name="updateUserInterface">Whether to refresh the SolidWorks selection UI while the temporary selection is active.</param>
    /// <param name="updateUserInterfaceAfterDisposing">Whether to refresh the SolidWorks selection UI when the temporary selection is cleared.</param>
    /// <returns>A disposable that restores the previous selection when disposed.</returns>
    IDisposable TemporarySelectObjects(IEnumerable<SelectedObject> selectedObjects, SelectionData selectionData, bool updateUserInterface = false, bool updateUserInterfaceAfterDisposing = true);
}