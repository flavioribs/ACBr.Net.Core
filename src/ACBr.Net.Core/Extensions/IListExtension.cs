// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 06-04-2014
//
// Last Modified By : RFTD
// Last Modified On : 01-30-2015
// ***********************************************************************
// <copyright file="IListExtension.cs" company="ACBr.Net">
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
using System.Collections.Generic;

namespace ACBr.Net.Core.Extensions
{
	/// <summary>
	/// Class IListExtension.
	/// </summary>
	public static class ListExtension
	{
		/// <summary>
		/// Adiciona uma string com quebra de linha na lista como se fosse uma ou mais linhas
		/// </summary>
		/// <param name="list">A lista.</param>
		/// <param name="texto">O texto.</param>
		public static void AddText(this IList<string> list, string texto)
		{
			var textos = texto.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var text in textos)
				list.Add(text);
		}

		/// <summary>
		/// Transforma uma lista de string em uma unica string.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns>String com todos os dados da lista de strings</returns>
		public static string AsString(this IEnumerable<string> array)
		{
			return string.Join(Environment.NewLine, array);
		}

        /// <summary>
        /// Tries the get.
        /// </summary>
        /// <typeparam name="TKey">The type of the tk.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns>V.</returns>
        public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGet(key, default(TValue));
        }
        /// <summary>
        /// Tries the get.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>V.</returns>
        public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary != null && dictionary.ContainsKey(key))
                return dictionary[key];

            return defaultValue;
        }
	}
}
