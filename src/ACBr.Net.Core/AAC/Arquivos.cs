// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="Arquivos.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections;
using System.Collections.Generic;

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
	[Guid("E2B492E7-B180-41AB-A922-484DE27A5281")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

    /// <summary>
    /// Class Arquivos. This class cannot be inherited.
    /// </summary>
	public sealed class Arquivos : List<Arquivo> ,IEnumerable<Arquivo>
	{
		#region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Arquivos"/> class.
        /// </summary>
		internal Arquivos()
		{
		}

		#endregion Constructor

		#region Methods

        /// <summary>
        /// News this instance.
        /// </summary>
        /// <returns>Arquivo.</returns>
		public Arquivo New()
		{
            var item = new Arquivo();
            Add(item);
            return item;
		}

		#endregion Methods

		#region IEnumerable<ACBrAACArquivo>

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
		IEnumerator<Arquivo> IEnumerable<Arquivo>.GetEnumerator()
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
			return ((IEnumerable<Arquivo>)this).GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACArquivo>
	}
}