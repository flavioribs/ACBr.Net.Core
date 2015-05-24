// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 01-30-2015
// ***********************************************************************
// <copyright file="ObjectExtension.cs" company="ACBr.Net">
// Esta biblioteca � software livre; voc� pode redistribu�-la e/ou modific�-la
// sob os termos da Licen�a P�blica Geral Menor do GNU conforme publicada pela
// Free Software Foundation; tanto a vers�o 2.1 da Licen�a, ou (a seu crit�rio)
// qualquer vers�o posterior.
//
// Esta biblioteca � distribu�da na expectativa de que seja �til, por�m, SEM
// NENHUMA GARANTIA; nem mesmo a garantia impl�cita de COMERCIABILIDADE OU
// ADEQUA��O A UMA FINALIDADE ESPEC�FICA. Consulte a Licen�a P�blica Geral Menor
// do GNU para mais detalhes. (Arquivo LICEN�A.TXT ou LICENSE.TXT)
//
// Voc� deve ter recebido uma c�pia da Licen�a P�blica Geral Menor do GNU junto
// com esta biblioteca; se n�o, escreva para a Free Software Foundation, Inc.,
// no endere�o 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.
// Voc� tamb�m pode obter uma copia da licen�a em:
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