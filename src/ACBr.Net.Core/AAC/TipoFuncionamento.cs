// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="TipoFuncionamento.cs" company="ACBr.Net">
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
    /// Enum TipoFuncionamento
    /// </summary>
	public enum TipoFuncionamento
	{
        /// <summary>
        /// The stand alone
        /// </summary>
		StandAlone = 0,
        /// <summary>
        /// The em rede
        /// </summary>
		EmRede = 1,
        /// <summary>
        /// The parametrizavel
        /// </summary>
		Parametrizavel = 2
	}
}