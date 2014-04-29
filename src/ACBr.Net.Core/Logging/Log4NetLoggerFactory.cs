using System;
using System.Linq;
using System.Linq.Expressions;

namespace ACBr.Net.Core
{
	public class Log4NetLoggerFactory : ILoggerFactory
	{
		private static readonly Type LogManagerType = Type.GetType("log4net.LogManager, log4net");
		private static readonly Func<string, object> GetLoggerByNameDelegate;
		private static readonly Func<Type, object> GetLoggerByTypeDelegate;
		static Log4NetLoggerFactory()
		{
			GetLoggerByNameDelegate = GetGetLoggerMethodCall<string>();
			GetLoggerByTypeDelegate = GetGetLoggerMethodCall<Type>();
		}
		public IInternalLogger LoggerFor(string keyName)
		{
			return new Log4NetLogger(GetLoggerByNameDelegate(keyName));
		}

		public IInternalLogger LoggerFor(Type type)
		{
			return new Log4NetLogger(GetLoggerByTypeDelegate(type));
		}

		private static Func<TParameter, object> GetGetLoggerMethodCall<TParameter>()
		{
			var method = LogManagerType.GetMethod("GetLogger", new[] { typeof(TParameter) });
			ParameterExpression resultValue;
			ParameterExpression keyParam = Expression.Parameter(typeof(TParameter), "key");
			MethodCallExpression methodCall = Expression.Call(null, method, new Expression[] { resultValue = keyParam });
			return Expression.Lambda<Func<TParameter, object>>(methodCall, new[] { resultValue }).Compile();
		}
	}
}
