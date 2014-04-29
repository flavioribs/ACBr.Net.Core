// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="IdenticacaoPaf.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

/// <summary>
/// The AAC namespace.
/// </summary>
namespace ACBr.Net.Core.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CE8FB949-42A9-4FB6-856D-41D1F662F003")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class IdenticacaoPaf. This class cannot be inherited.
    /// </summary>
	public sealed class IdenticacaoPaf
	{
		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IdenticacaoPaf"/> class.
        /// </summary>
		public IdenticacaoPaf()
		{
			Empresa = new Empresa();
			Paf = new InfoPaf();
			ECFsAutorizados = new ECFs();
			OutrosArquivos = new Arquivos();
			ArquivoListaAutenticados = new ArquivoListaAutenticados();
		}

		#endregion Constructor

		#region Properties

        /// <summary>
        /// Gets the empresa.
        /// </summary>
        /// <value>The empresa.</value>
		[Browsable(true)]
		public Empresa Empresa { get; private set; }

        /// <summary>
        /// Gets the paf.
        /// </summary>
        /// <value>The paf.</value>
		[Browsable(true)]
		public InfoPaf Paf { get; private set; }

        /// <summary>
        /// Gets the ec fs autorizados.
        /// </summary>
        /// <value>The ec fs autorizados.</value>
		[Browsable(true)]
		public ECFs ECFsAutorizados { get; private set; }

        /// <summary>
        /// Gets the outros arquivos.
        /// </summary>
        /// <value>The outros arquivos.</value>
		[Browsable(true)]
		public Arquivos OutrosArquivos { get; private set; }

        /// <summary>
        /// Gets the arquivo lista autenticados.
        /// </summary>
        /// <value>The arquivo lista autenticados.</value>
		[Browsable(true)]
		public ArquivoListaAutenticados ArquivoListaAutenticados { get; private set; }

        /// <summary>
        /// Gets or sets the numero laudo.
        /// </summary>
        /// <value>The numero laudo.</value>
        public string NumeroLaudo { get; set; }

        /// <summary>
        /// Gets or sets the versao er.
        /// </summary>
        /// <value>The versao er.</value>
        public string VersaoER { get; set; }

		#endregion Properties
	}
}