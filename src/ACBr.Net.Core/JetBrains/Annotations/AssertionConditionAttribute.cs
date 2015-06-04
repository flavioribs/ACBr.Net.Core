// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 02-28-2015
//
// Last Modified By : RFTD
// Last Modified On : 02-28-2015
// ***********************************************************************
// <copyright file="AssertionConditionAttribute.cs" company="">
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
using System.Diagnostics;

namespace JetBrains.Annotations
{
	/// <summary>
	/// Indicates the condition parameter of the assertion method. The method itself should be
	/// marked by <see cref="AssertionMethodAttribute" /> attribute. The mandatory argument of
	/// the attribute is the assertion type.
	/// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    public sealed class AssertionConditionAttribute : Attribute
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AssertionConditionAttribute" /> class.
		/// </summary>
		/// <param name="conditionType">Type of the condition.</param>
        public AssertionConditionAttribute(AssertionConditionType conditionType)
        {
            ConditionType = conditionType;
        }

		/// <summary>
		/// Gets the type of the condition.
		/// </summary>
		/// <value>The type of the condition.</value>
        public AssertionConditionType ConditionType { get; private set; }
    }
}