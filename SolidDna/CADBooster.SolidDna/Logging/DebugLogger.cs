using System;
using System.Diagnostics;

namespace CADBooster.SolidDna;

/// <summary>
/// A logger that writes the logs to the debug output (e.g. Visual Studio Output window).
/// </summary>
public class DebugLogger : ILogger
{
    private readonly string mCategoryName;
    private readonly DebugLoggerConfiguration mConfiguration;

    /// <summary>
    /// Creates a new debug logger.
    /// </summary>
    /// <param name="categoryName">The category for this logger</param>
    /// <param name="configuration">The configuration to use</param>
    public DebugLogger(string categoryName, DebugLoggerConfiguration configuration = null)
    {
        mCategoryName = categoryName;
        mConfiguration = configuration ?? new DebugLoggerConfiguration();
    }

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state) => null;

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel) => logLevel >= mConfiguration.LogLevel;

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        var message = formatter(state, exception);
        var logLevelString = mConfiguration.OutputLogLevel ? $"{logLevel}: " : "";
        var output = $"{logLevelString}{message}";

        Debug.WriteLine(output);
    }
}
