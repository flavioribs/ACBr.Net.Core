// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="Arquivo.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBr.Net.Core.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("97C089E7-92E2-4C0E-8546-DC5B9CCFAAB8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class Arquivo. This class cannot be inherited.
    /// </summary>
	public sealed class Arquivo
	{
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