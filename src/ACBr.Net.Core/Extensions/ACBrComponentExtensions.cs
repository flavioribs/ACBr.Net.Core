// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 01-30-2015
// ***********************************************************************
// <copyright file="ACBrComponentExtensions.cs" company="ACBr.Net">
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
using System.Reflection;

namespace ACBr.Net.Core.Extensions
{
    /// <summary>
    /// Classe ACBrComponentExtensions.
    /// </summary>
    public static class ACBrComponentExtensions
    {
        /// <summary>
        /// Determina se um evento esta setado ou n�o
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comp">Componente ACBr.Net</param>
        /// <param name="evento">Nome do evento</param>
        /// <returns><c>true</c> se o evento foi setado, <c>false</c> Sen�o.</returns>
        public static bool EventAssigned<T>(this T comp, string evento) where T : ACBrComponent
        {
            var fieldInfo = typeof (T).GetField(evento, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null)
                return false;

            var handler = fieldInfo.GetValue(comp) as Delegate;
            if (handler == null)
                return false;

            var subscribers = handler.GetInvocationList();
            return subscribers.Length != 0;
        }
    }
}
