using JoltFolderCleanup.Core.Models;

namespace JoltFolderCleanup.Core.Rules;

/// <summary>
/// Specifies the type of size comparison.
/// </summary>
public enum SizeComparison
{
    /// <summary>
    /// Items smaller than the specified size.
    /// </summary>
    SmallerThan,

    /// <summary>
    /// Items larger than the specified size.
    /// </summary>
    LargerThan,

    /// <summary>
    /// Items exactly matching the specified size.
    /// </summary>
    ExactlyEqual
}

/// <summary>
/// Rule that matches files/folders based on their size.
/// </summary>
public class SizeBasedRule : ICleanupRule
{
    private readonly long _sizeBytes;
    private readonly SizeComparison _comparison;

    /// <summary>
    /// Initializes a new instance of the <see cref="SizeBasedRule"/> class.
    /// </summary>
    /// <param name="sizeBytes">The size in bytes for comparison.</param>
    /// <param name="comparison">The type of size comparison.</param>
    public SizeBasedRule(long sizeBytes, SizeComparison comparison = SizeComparison.LargerThan)
    {
        if (sizeBytes < 0)
            throw new ArgumentException("Size cannot be negative.", nameof(sizeBytes));

        _sizeBytes = sizeBytes;
        _comparison = comparison;

        Name = $"Size: {comparison} {FormatBytes(sizeBytes)}";
        Description = $"Matches items {comparison} {FormatBytes(sizeBytes)}";
    }

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public string Description { get; }

    /// <inheritdoc/>
    public bool Matches(FileSystemItem item)
    {
        return _comparison switch
        {
            SizeComparison.SmallerThan => item.SizeBytes < _sizeBytes,
            SizeComparison.LargerThan => item.SizeBytes > _sizeBytes,
            SizeComparison.ExactlyEqual => item.SizeBytes == _sizeBytes,
            _ => throw new InvalidOperationException($"Unknown comparison type: {_comparison}")
        };
    }

    /// <inheritdoc/>
    public string GetMatchReason(FileSystemItem item)
        => $"Item size {FormatBytes(item.SizeBytes)} is {_comparison} {FormatBytes(_sizeBytes)}";

    /// <summary>
    /// Formats bytes as a human-readable string.
    /// </summary>
    private static string FormatBytes(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = bytes;
        int order = 0;

        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }

        return $"{len:0.##} {sizes[order]}";
    }
}