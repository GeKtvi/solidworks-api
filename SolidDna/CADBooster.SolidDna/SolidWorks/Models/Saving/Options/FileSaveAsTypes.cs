namespace CADBooster.SolidDna;

/// <summary>
/// File save-as types from <see cref="SolidWorks.Interop.swconst.swFileSaveTypes_e"/> that represent Save As variants only.
/// </summary>
public enum FileSaveAsTypes
{
    /// <summary>
    /// Save as a new file path.
    /// Document is saved, and the original document path is updated to the new file path.
    /// </summary>
    SaveAs = 2,

    /// <summary>
    /// Save as a copy.
    /// Document is saved to a copy, but the copy is not opened, and the original document remains open.
    /// </summary>
    SaveAsCopy = 3,

    /// <summary>
    /// Save as a copy and open it.
    /// Document is saved to a copy, the copy is opened, and the original document may remain open (SW asks whether to keep or close the original document).
    /// </summary>
    SaveAsCopyAndOpen = 4,
}
