using System;
using System.IO;
using System.Linq;
using System.Configuration;

namespace ACBr.Net.Core
{
	public class LoggerProvider
    {
        #region Fields

        private const string LoggerConfKey = "acbr-logger";
		private readonly ILoggerFactory loggerFactory;
		private static LoggerProvider instance;

        #endregion Fields

        #region Constructor

        static LoggerProvider()
		{
			string LoggerClass = GetLoggerClass();
			ILoggerFactory loggerFactory = string.IsNullOrEmpty(LoggerClass) ? new NoLoggingLoggerFactory() : GetLoggerFactory(LoggerClass);
			SetLoggersFactory(loggerFactory);
		}

        #endregion Constructor

        #region Methods

        private static ILoggerFactory GetLoggerFactory(string LoggerClass)
		{
			ILoggerFactory loggerFactory;
			var loggerFactoryType = Type.GetType(LoggerClass);
			try
			{
				loggerFactory = (ILoggerFactory)Activator.CreateInstance(loggerFactoryType);
			}
			catch (MissingMethodException ex)
			{
				throw new ApplicationException("Public constructor was not found for " + loggerFactoryType, ex);
			}
			catch (InvalidCastException ex)
			{
				throw new ApplicationException(String.Format("{0}Type does not implement {1}", loggerFactoryType, typeof(ILoggerFactory)), ex);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Unable to instantiate: " + loggerFactoryType, ex);
			}
			return loggerFactory;
		}

		private static string GetLoggerClass()
		{
			var Logger = ConfigurationManager.AppSettings.Keys.Cast<string>().FirstOrDefault(k => LoggerConfKey.Equals(k.ToLowerInvariant()));
			string LoggerClass = null;
			if (string.IsNullOrEmpty(Logger))
			{
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string relativeSearchPath = AppDomain.CurrentDomain.RelativeSearchPath;
				string binPath = relativeSearchPath == null ? baseDir : Path.Combine(baseDir, relativeSearchPath);
				string NLogDllPath = binPath == null ? "NLog.dll" : Path.Combine(binPath, "NLog.dll");
                string Log4NetDllPath = binPath == null ? "log4net.dll" : Path.Combine(binPath, "log4net.dll");

				if (File.Exists(NLogDllPath))
				{
					LoggerClass = typeof (NLogLoggerFactory).AssemblyQualifiedName;
				}
                else if (File.Exists(Log4NetDllPath))
                {
                    LoggerClass = typeof(Log4NetLoggerFactory).AssemblyQualifiedName;
                }
			}
			else
			{
				LoggerClass = ConfigurationManager.AppSettings[Logger];
			}
			return LoggerClass;
		}

		public static void SetLoggersFactory(ILoggerFactory loggerFactory)
		{
			instance = new LoggerProvider(loggerFactory);
		}

		private LoggerProvider(ILoggerFactory loggerFactory)
		{
			this.loggerFactory = loggerFactory;
		}

		public static IInternalLogger LoggerFor(string keyName)
		{
			return instance.loggerFactory.LoggerFor(keyName);
		}

		public static IInternalLogger LoggerFor(Type type)
		{
			return instance.loggerFactory.LoggerFor(type);
        }

        #endregion Methods
    }
}