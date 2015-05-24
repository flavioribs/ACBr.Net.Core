// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 01-30-2015
// ***********************************************************************
// <copyright file="ObjectExtension.cs" company="ACBr.Net">
// Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério)
// qualquer versão posterior.
//
// Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)
//
// Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.
// Você também pode obter uma copia da licença em:
// http://www.opensource.org/licenses/lgpl-license.php
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using ACBr.Net.Core.Exceptions;

namespace ACBr.Net.Core.Extensions
{
    /// <summary>
    /// Classe ObjectExtension.
    /// </summary>
	public static class ObjectExtension
	{
        /// <summary>
        /// Determines whether the specified t is in.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified t is in; otherwise, <c>false</c>.</returns>
		public static bool IsIn<T>(this T t, params T[] values)
		{
			return values.Contains(t);
		}

        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The item to check for nullity.</param>
        /// <param name="name">The name to use when throwing an exception, if necessary</param>
        /// <exception cref="System.ArgumentNullException"></exception>
		public static void ThrowIfNull<T>(this T data, string name) where T : class
		{
            Guard.Against<ArgumentNullException>(data == null, name);
		}
        
        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// No parameter name is specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The item to check for nullity.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
		public static void ThrowIfNull<T>(this T data) where T : class
        {
            Guard.Against<ArgumentNullException>(data == null, "");
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is null; otherwise, <c>false</c>.</returns>
        public static bool IsNull<T>(this T value) where T : class
        {
            return Equals(value, null);
        }
	}
}