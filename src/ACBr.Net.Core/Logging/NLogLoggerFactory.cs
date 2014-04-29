using System;
using System.Linq.Expressions;

namespace ACBr.Net.Core
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        private static readonly Type LogManagerType = Type.GetType("NLog.LogManager, NLog");
        private static readonly string LoggerName = "acbr.net";

		private readonly static Func<string, object> CreateLoggerInstanceFunc;

        static NLogLoggerFactory()
        {
            CreateLoggerInstanceFunc = CreateLoggerInstance();
        }

        #region ILoggerFactory Members

        public IInternalLogger LoggerFor(Type type)
        {
            return new NLogLogger(CreateLoggerInstanceFunc(LoggerName));
        }

        public IInternalLogger LoggerFor(string keyName)
        {
            return new NLogLogger(CreateLoggerInstanceFunc(LoggerName));
        }

        #endregion ILoggerFactory Members

        private static Func<string, object> CreateLoggerInstance()
        {
            var method = LogManagerType.GetMethod("GetLogger", new[] { typeof(string) });
            ParameterExpression nameParam = Expression.Parameter(typeof(string));
            MethodCallExpression methodCall = Expression.Call(null, method, new Expression[] { nameParam });

            return Expression.Lambda<Func<string, object>>(methodCall, new[] { nameParam }).Compile();
        }
    }
}