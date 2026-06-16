namespace WebShop.Infrastructure
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string path)
        {
            builder.AddProvider(new FileLoggerProvider(path));
            return builder;
        }
    }
}
