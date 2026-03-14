namespace CADBooster.SolidDna;

/// <summary>
/// The configuration for a <see cref="DebugLogger"/>.
/// </summary>
public class DebugLoggerConfiguration
{
    /// <summary>
    /// The level of log that should be processed.
    /// </summary>
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;

    /// <summary>
    /// Indicates if the log level should be output as part of the log message.
    /// </summary>
    public bool OutputLogLevel { get; set; } = true;
}
