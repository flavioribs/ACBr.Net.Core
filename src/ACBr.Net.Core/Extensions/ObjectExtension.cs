using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ACBr.Net.Core
{
	public static class ObjectExtension
	{
		public static bool IsIn<T>(this T t, params T[] values)
		{
			return values.Contains(t);
		}
	}
}
