// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 02-06-2014
// ***********************************************************************
// <copyright file="ACBrTEFException.cs" company="ACBr.Net">
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
using System.Runtime.Serialization;

namespace ACBr.Net.Core.Exceptions
{
    /// <summary>
    /// Classe ACBrTEFException.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class ACBrTEFException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrTEFException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ACBrTEFException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrTEFException"/> class.
        /// </summary>
        public ACBrTEFException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrTEFException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public ACBrTEFException(Exception ex):base(ex.Message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrTEFException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ACBrTEFException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ACBrTEFException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected ACBrTEFException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
