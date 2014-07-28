// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 06-04-2014
//
// Last Modified By : RFTD
// Last Modified On : 06-04-2014
// ***********************************************************************
// <copyright file="IListExtension.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// The Core namespace.
/// </summary>
namespace ACBr.Net.Core
{
	/// <summary>
	/// Class IListExtension.
	/// </summary>
	public static class IListExtension
	{
		/// <summary>
		/// Adiciona uma string com quebra de linha na lista como se fosse uma ou mais linhas
		/// </summary>
		/// <param name="list">A lista.</param>
		/// <param name="texto">O texto.</param>
		public static void AddText(this IList<string> list, string texto)
		{
			var textos = texto.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var text in textos)
				list.Add(text);
		}

		/// <summary>
		/// Transforma uma lista de string em uma unica string.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns>String com todos os dados da lista de strings</returns>
		public static string AsString(this List<string> array)
		{
			return String.Join(Environment.NewLine, array);
		}
	}
}
