namespace JoltFolderCleanup.Core.Models;
/// <summary> 
/// Represents a file or folder that was processed during cleanup. 
/// </summary>
public class ProcessedItem {
    /// <summary> 
    /// Gets or sets the full path of the item. 
    /// </summary>
    public required string Path { get; set; }
    /// <summary> 
    /// Gets or sets the size in bytes. 
    /// </summary>
    public long SizeBytes { get; set; }
    /// <summary> 
    /// Gets or sets whether the operation succeeded. 
    /// </summary>
    public bool Success { get; set; }
    /// <summary> 
    /// Gets or sets any error message if the operation failed. 
    /// </summary>
    public string? ErrorMessage { get; set; }
    /// <summary> 
    /// Gets or sets the reason why the item matched the rules. 
    /// </summary>
    public string? MatchReason { get; set; }
    /// <summary> 
    /// Gets or sets the timestamp when the item was processed. 
    /// </summary>
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
}