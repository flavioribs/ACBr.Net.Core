// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ComprovanteNaoFiscal.cs" company="">
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

namespace ACBr.Net.Core.ECF
{
	/// <summary>
	/// Classe ComprovanteNaoFiscal. Está classe não pode ser herdada.
	/// </summary>
	public sealed class ComprovanteNaoFiscal
	{
		#region Properties

		/// <summary>
		/// Gets the indice.
		/// </summary>
		/// <value>The indice.</value>
		public string Indice { get; internal set; }
		/// <summary>
		/// Gets the descricao.
		/// </summary>
		/// <value>The descricao.</value>
		public string Descricao { get; internal set; }
		/// <summary>
		/// Gets a value indicating whether [permite vinculado].
		/// </summary>
		/// <value><c>true</c> if [permite vinculado]; otherwise, <c>false</c>.</value>
		public bool PermiteVinculado { get; internal set; }
		/// <summary>
		/// Gets the forma pagamento.
		/// </summary>
		/// <value>The forma pagamento.</value>
		public string FormaPagamento { get; internal set; }
		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>The total.</value>
		public decimal Total { get; internal set; }
		/// <summary>
		/// Gets the contador.
		/// </summary>
		/// <value>The contador.</value>
		public int Contador { get; internal set; }
		
		#endregion Properties
	}
}