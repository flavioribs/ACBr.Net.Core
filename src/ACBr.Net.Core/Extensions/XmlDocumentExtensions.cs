using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace ACBr.Net.Core
{
    public static class XmlDocumentExtensions
    {
        public static string AsString(this XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    xmlDoc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
        }
    }
}
