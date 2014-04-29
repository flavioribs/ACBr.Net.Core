// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="TipoIntegracao.cs" company="ACBr.Net">
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
	#endif
	#endregion COM_INTEROP

    /// <summary>
    /// Enum TipoIntegracao
    /// </summary>
	public enum TipoIntegracao
	{
        /// <summary>
        /// The retaguarda
        /// </summary>
		Retaguarda = 0,
        /// <summary>
        /// The ped
        /// </summary>
		PED = 1,
        /// <summary>
        /// The ambos
        /// </summary>
		Ambos = 2,
        /// <summary>
        /// The nao integra
        /// </summary>
		NaoIntegra = 3
	}
}