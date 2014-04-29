// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="AACECF.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

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
	[Guid("00950BA4-3763-4F86-80D9-DCF0F801E88D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class AACECF. This class cannot be inherited.
    /// </summary>
	public sealed class AACECF
	{
		#region Properties

        /// <summary>
        /// Gets or sets the valor gt.
        /// </summary>
        /// <value>The valor gt.</value>
		public decimal ValorGT
		{
			#region COM_INTEROP

#if COM_INTEROP

			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;

			#region COM_INTEROP

#if COM_INTEROP

			[param: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			set;
		}

        /// <summary>
        /// Gets or sets the numero serie.
        /// </summary>
        /// <value>The numero serie.</value>
		public string NumeroSerie { get; set; }

        /// <summary>
        /// Gets or sets the cro.
        /// </summary>
        /// <value>The cro.</value>
		public int CRO { get; set; }

        /// <summary>
        /// Gets or sets the cni.
        /// </summary>
        /// <value>The cni.</value>
		public int CNI { get; set; }

        /// <summary>
        /// Gets the dt hr atualizado.
        /// </summary>
        /// <value>The dt hr atualizado.</value>
		public DateTime DtHrAtualizado { get; internal set; }

		#endregion Properties
	}
}