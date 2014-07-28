using System;
using System.Linq;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
	public static class ObjectExtension
	{
		public static bool IsIn<T>(this T t, params T[] values)
		{
			return values.Contains(t);
		}

		/// <summary>
		/// Throws an ArgumentNullException if the given data item is null.
		/// </summary>
		/// <param name="data">The item to check for nullity.</param>
		/// <param name="name">The name to use when throwing an exception, if necessary</param>
		public static void ThrowIfNull<T>(this T data, string name) where T : class
		{
			if (data == null)
				throw new ArgumentNullException(name);
		}

		/// <summary>
		/// Throws an ArgumentNullException if the given data item is null.
		/// No parameter name is specified.
		/// </summary>
		/// <param name="data">The item to check for nullity.</param>
		public static void ThrowIfNull<T>(this T data) where T : class
		{
			if (data == null)
				throw new ArgumentNullException();
		}
	}
}