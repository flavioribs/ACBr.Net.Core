// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ChaveEventArgs.cs" company="ACBr.Net">
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

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBr.Net.Core.Events
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("074D4D85-E77C-4F97-9A90-83032541707E")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
    /// <summary>
    /// Classe ChaveEventArgs.
    /// </summary>
	public class ChaveEventArgs : EventArgs
	{
        /// <summary>
        /// Gets or sets the chave.
        /// </summary>
        /// <value>The chave.</value>
		public string Chave { get; set; }
	}
}