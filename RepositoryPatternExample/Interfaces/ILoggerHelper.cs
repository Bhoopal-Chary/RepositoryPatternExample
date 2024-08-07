namespace RepositoryPatternExample.Interfaces
{
	public interface ILoggerHelper
	{
		void LogInformation(string message);
		void LogError(string message);
		void LogWarning(string message);
	}
}
