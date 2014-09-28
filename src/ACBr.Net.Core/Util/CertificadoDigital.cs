// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : arezende
// Created          : 07-27-2014
//
// Last Modified By : RFTD
// Last Modified On : 09-02-2014
// ***********************************************************************
// <copyright file="CertificadoDigital.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace ACBr.Net.Core.Util
{
    /// <summary>
    /// Classe CertificadoDigital.
    /// </summary>
    public static class CertificadoDigital
    {
        /// <summary>
        /// Assina a NFe usando o certificado informado.
        /// </summary>
        /// <param name="nFe">A NFe.</param>
        /// <param name="pUri">A Url.</param>
        /// <param name="pCertificado">O certificado.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Erro ao efetuar assinatura digital, detalhes:  + ex.Message</exception>
        public static string Assinar(string nFe, string pUri, X509Certificate2 pCertificado)
        {
            try
            {
                // Load the certificate from the certificate store.
                var cert = pCertificado;

                // Create a new XML document.
                var doc = new XmlDocument();
                doc.LoadXml(nFe);

                // Format the document to ignore white spaces.
                doc.PreserveWhitespace = false;
                
                // Create a SignedXml object.
                var signedXml = new SignedXml(doc) { SigningKey = cert.PrivateKey };

                // Add the key to the SignedXml document.

                // Create a reference to be signed.
                var reference = new Reference();

                // pega o uri que deve ser assinada
                var xmlNode = doc.GetElementsByTagName(pUri).Item(0);
                if (xmlNode != null)
                {
                    var uri = xmlNode.Attributes;
                    if (uri != null)
                        foreach (var atributo in uri.Cast<XmlAttribute>().Where(atributo => atributo.Name == "Id"))
                        {
                            reference.Uri = "#" + atributo.InnerText;
                        }
                }

                // Add an enveloped transformation to the reference.
                var env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);

                var c14 = new XmlDsigC14NTransform();
                reference.AddTransform(c14);

                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);

                // Create a new KeyInfo object.
                var keyInfo = new KeyInfo();

                // Load the certificate into a KeyInfoX509Data object
                // and add it to the KeyInfo object.
                keyInfo.AddClause(new KeyInfoX509Data(cert));

                // Add the KeyInfo object to the SignedXml object.
                signedXml.KeyInfo = keyInfo;

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                var xmlDigitalSignature = signedXml.GetXml();

                // Append the element to the XML document.
                doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                
                if (doc.FirstChild is XmlDeclaration)
                {
                    doc.RemoveChild(doc.FirstChild);
                }

                return doc.AsString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar assinatura digital, detalhes: " + ex.Message);
            }
        }

        /// <summary>
        /// Busca certificados instalado se informado uma serie
        /// se não abre caixa de dialogos de certificados.
        /// </summary>
        /// <param name="cerSerie">Serie do certificado.</param>
        /// <returns>X509Certificate2.</returns>
        /// <exception cref="System.Exception">
        /// Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.
        /// or
        /// Certificado digital não encontrado
        /// or
        /// </exception>
        public static X509Certificate2 SelecionarCertificado(string cerSerie)
        {
            var certificate = new X509Certificate2();
            try
            {
                X509Certificate2Collection certificatesSel = null;
                var store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.OpenExistingOnly);
                var certificates = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, true).Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);
                if ((string.IsNullOrEmpty(cerSerie)))
                {
                    certificatesSel = X509Certificate2UI.SelectFromCollection(certificates, "Certificados Digitais", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if ((certificatesSel.Count == 0))
                    {
                        certificate.Reset();
                        throw new Exception("Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.");
                    }
                    else
                    {
                        certificate = certificatesSel[0];
                    }
                }
                else
                {
                    certificatesSel = certificates.Find(X509FindType.FindBySerialNumber, cerSerie, true);
                    if ((certificatesSel.Count == 0))
                    {
                        certificate.Reset();
                        throw new Exception("Certificado digital não encontrado");
                    }
                    else
                    {
                        certificate = certificatesSel[0];
                    }
                }
                store.Close();
                return certificate;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Seleciona um certificado informando o caminho e a senha.
        /// </summary>
        /// <param name="caminho">O caminho.</param>
        /// <param name="senha">A senha.</param>
        /// <returns>X509Certificate2.</returns>
        /// <exception cref="System.Exception">Arquivo do Certificado digital não encontrado</exception>
        public static X509Certificate2 SelecionarCertificado(string caminho, string senha)
        {
            if (!File.Exists(caminho))
            {
                throw new Exception("Arquivo do Certificado digital não encontrado");
            }

            var cert = new X509Certificate2(caminho, senha, X509KeyStorageFlags.MachineKeySet);
            return cert;
        }
    }
}
