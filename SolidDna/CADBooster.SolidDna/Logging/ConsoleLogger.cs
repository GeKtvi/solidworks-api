using System;

namespace CADBooster.SolidDna;

/// <summary>
/// A logger that writes the logs to the console.
/// </summary>
public class ConsoleLogger : ILogger
{
    private readonly string mCategoryName;
    private readonly ConsoleLoggerConfiguration mConfiguration;

    /// <summary>
    /// Creates a new console logger.
    /// </summary>
    /// <param name="categoryName">The category for this logger</param>
    /// <param name="configuration">The configuration to use</param>
    public ConsoleLogger(string categoryName, ConsoleLoggerConfiguration configuration = null)
    {
        mCategoryName = categoryName;
        mConfiguration = configuration ?? new ConsoleLoggerConfiguration();
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

        Console.WriteLine(output);
    }
}
