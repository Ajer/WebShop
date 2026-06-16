using Microsoft.Build.Logging;

namespace WebShop.Infrastructure
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly StreamWriter _writer;

        public FileLoggerProvider(string path)
        {
            _writer = new StreamWriter(path, append: true);
        }

        public ILogger CreateLogger(string categoryName)
            => new FileLogger(categoryName, _writer);

        public void Dispose() => _writer.Dispose();
    }

}
