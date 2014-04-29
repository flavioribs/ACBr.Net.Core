// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="Empresa.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
	[Guid("17376497-6E66-4E59-BBB8-680EC6A19697")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class Empresa. This class cannot be inherited.
    /// </summary>
	public sealed class Empresa
	{
		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Empresa"/> class.
        /// </summary>
		internal Empresa()
		{
		}

		#endregion Constructor

		#region Properties

        /// <summary>
        /// Gets or sets the CNPJ.
        /// </summary>
        /// <value>The CNPJ.</value>
        public string CNPJ { get; set; }

        /// <summary>
        /// Gets or sets the razao social.
        /// </summary>
        /// <value>The razao social.</value>
        public string RazaoSocial { get; set; }

        /// <summary>
        /// Gets or sets the endereco.
        /// </summary>
        /// <value>The endereco.</value>
        public string Endereco { get; set; }

        /// <summary>
        /// Gets or sets the cep.
        /// </summary>
        /// <value>The cep.</value>
        public string Cep { get; set; }

        /// <summary>
        /// Gets or sets the cidade.
        /// </summary>
        /// <value>The cidade.</value>
        public string Cidade { get; set; }

        /// <summary>
        /// Gets or sets the uf.
        /// </summary>
        /// <value>The uf.</value>
        public string Uf { get; set; }

        /// <summary>
        /// Gets or sets the telefone.
        /// </summary>
        /// <value>The telefone.</value>
        public string Telefone { get; set; }

        /// <summary>
        /// Gets or sets the contato.
        /// </summary>
        /// <value>The contato.</value>
        public string Contato { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ie.
        /// </summary>
        /// <value>The ie.</value>
        public string IE { get; set; }

        /// <summary>
        /// Gets or sets the im.
        /// </summary>
        /// <value>The im.</value>
        public string IM { get; set; }

		#endregion Properties
	}
}