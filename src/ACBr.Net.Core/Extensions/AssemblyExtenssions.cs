using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public static class AssemblyExtenssions
    {
        public static string GetPath(this Assembly ass)
        {
            UriBuilder uri = new UriBuilder(ass.CodeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
