// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ECFs.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
	[Guid("1C8B6F72-29F3-447C-9AA3-223CC8CB2858")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class ECFs. This class cannot be inherited.
    /// </summary>
	public sealed class ECFs : List<AACECF>, IEnumerable<AACECF>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ECFs"/> class.
        /// </summary>
        internal ECFs()
		{
		}

		#endregion Constructor

		#region IEnumerable<ACBrAACECF>

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
		IEnumerator<AACECF> IEnumerable<AACECF>.GetEnumerator()
        {
            int count = Count;
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<AACECF>)this).GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACECF>
	}
}