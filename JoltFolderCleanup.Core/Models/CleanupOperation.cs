namespace JoltFolderCleanup.Core.Models;
/// <summary>
/// Specifies the type of cleanup operation to perform.
/// </summary>
public enum CleanupOperation
{
    /// <summary>
    /// Permanently delete files/folders.
    /// </summary>
    Delete,

    /// <summary>
    /// Move files/folders to system temporary directory.
    /// </summary>
    MoveToTemp,

    /// <summary>
    /// Preview mode - no changes are made.
    /// </summary>
    DryRun
}