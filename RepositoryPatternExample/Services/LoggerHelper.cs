
namespace RepositoryPatternExample.Services
{

	public class LoggerHelper : RepositoryPatternExample.Interfaces.ILoggerHelper
	{
		private readonly ILogger _logger;
		public LoggerHelper(ILogger<LoggerHelper> logger)
		{
			_logger = logger;
		}

		public void LogInformation(string message)
		{
			_logger.LogInformation(message);

		}
		public void LogError(string message)
		{
			_logger.LogError(message);

		}
		public void LogWarning(string message)
		{
			_logger.LogWarning(message);

		}

	}
}
