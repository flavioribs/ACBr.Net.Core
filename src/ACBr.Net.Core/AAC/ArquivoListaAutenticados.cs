// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ArquivoListaAutenticados.cs" company="ACBr.Net">
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
	[Guid("4CDBFAB2-9CC6-4D31-8B19-42183EC2E24F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class ArquivoListaAutenticados. This class cannot be inherited.
    /// </summary>
	public sealed class ArquivoListaAutenticados
	{
		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ArquivoListaAutenticados"/> class.
        /// </summary>
		internal ArquivoListaAutenticados()
		{
		}

		#endregion Constructor

		#region Properties

        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the m d5.
        /// </summary>
        /// <value>The m d5.</value>
        public string MD5 { get; set; }

		#endregion Properties
	}
}