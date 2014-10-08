// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 08-01-2014
// ***********************************************************************
// <copyright file="XmlDocumentExtensions.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using System.Xml;
using System.Text;
using System.Linq;

namespace ACBr.Net.Core
{
    /// <summary>
    /// Class XmlDocumentExtensions.
    /// </summary>
    public static class XmlDocumentExtensions
    {
        /// <summary>
        /// Retorna a XML como string com enconde UTF8
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="identado">Se for <c>true</c> o XML sai [identado].</param>
        /// <param name="showDeclaration">if set to <c>true</c> [show declaration].</param>
        /// <returns>System.String.</returns>
        public static string AsString(this XmlDocument xmlDoc, bool identado = false, bool showDeclaration = false)
        {
            return xmlDoc.AsString(identado, showDeclaration, Encoding.UTF8);
        }
        
        /// <summary>
        /// Retorna a XML como string
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="identado">Se for <c>true</c> o XML sai [identado].</param>
        /// <param name="encode">O enconding do XML.</param>
        /// <param name="showDeclaration">if set to <c>true</c> [show declaration].</param>
        /// <returns>System.String.</returns>
        public static string AsString(this XmlDocument xmlDoc, bool identado, bool showDeclaration, Encoding encode)
        {
            using (var stringWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings()
                {
                    Indent = identado,
                    Encoding = encode,
                    OmitXmlDeclaration = !showDeclaration
                };

                using (var xmlTextWriter = XmlWriter.Create(stringWriter, settings))
                {
                    xmlDoc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
        }

        /// <summary>
        /// Adiciona uma tag ao documento ignorando os elementos nulos.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="tag">The tag.</param>
		public static void AddTag(this XmlDocument xmlDoc, XmlElement tag)
        {
            if (tag == null)
				return;

            xmlDoc.AppendChild(tag);
        }

        /// <summary>
        /// Adiciona uma tag ao documento ignorando os elementos nulos.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="tag">The tag.</param>
		public static void AddTag(this XmlElement xmlDoc, XmlElement tag)
        {
            if (tag == null)
				return;
            
            xmlDoc.AppendChild(tag);
        }

        /// <summary>
        /// Adiciona varias tag ao documento ignorando os elementos nulos.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="tags">The tags.</param>
		public static void AddTag(this XmlElement xmlDoc, XmlElement[] tags)
        {
            if (tags.Length < 1)
				return;

            foreach (var tag in tags.Where(tag => tag != null))
                xmlDoc.AppendChild(tag);
        }
    }
}
