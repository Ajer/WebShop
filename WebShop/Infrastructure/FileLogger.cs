namespace WebShop.Infrastructure
{
    using Microsoft.Extensions.Logging;

    public class FileLogger : ILogger
    {
        private readonly string _category;
        private readonly StreamWriter _writer;

        public FileLogger(string category, StreamWriter writer)
        {
            _category = category;
            _writer = writer;
        }

        public IDisposable BeginScope<TState>(TState state) => default!;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_category}: {formatter(state, exception)}";
            _writer.WriteLine(message);
            _writer.Flush();
        }
    }

}
