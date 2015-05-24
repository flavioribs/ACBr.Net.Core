// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-24-2013
// ***********************************************************************
// <copyright file="ACBrException.cs" company="ACBr.Net">
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
using System.Runtime.Serialization;

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBr.Net.Core.Exceptions
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("EEAC1AB6-0C7C-4756-942C-38570D663BF2")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
    /// <summary>
    /// Classe ACBrException.
    /// </summary>
	public class ACBrException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
		public ACBrException(string message)
			: base(message)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrException"/> class.
        /// </summary>
        public ACBrException()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ACBrException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected ACBrException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }
         
	}
}