using System;
using System.Linq;

namespace ACBr.Net.Core
{
	public class NoLoggingLoggerFactory : ILoggerFactory
	{
		private static readonly IInternalLogger Nologging = new NoLoggingInternalLogger();
		public IInternalLogger LoggerFor(string keyName)
		{
			return Nologging;
		}

		public IInternalLogger LoggerFor(Type type)
		{
			return Nologging;
		}
	}
}
