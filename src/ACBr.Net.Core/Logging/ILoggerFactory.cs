using System;
using System.Linq;

namespace ACBr.Net.Core
{
	public interface ILoggerFactory
	{
		IInternalLogger LoggerFor(string keyName);

		IInternalLogger LoggerFor(Type type);
	}
}
