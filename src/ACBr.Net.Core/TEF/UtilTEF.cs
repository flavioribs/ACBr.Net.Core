// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 07-26-2014
// ***********************************************************************
// <copyright file="UtilTEF.cs" company="ACBr.Net">
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
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBr.Net.Core.TEF
{
    /// <summary>
    /// Classe UtilTEF.
    /// </summary>
	public static class UtilTEF
	{
        /// <summary>
        /// Brings the window to focus.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		[DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BringWindowToFocus(IntPtr hWnd);

        /// <summary>
        /// Bloquears the teclado mouse.
        /// </summary>
        /// <param name="fBlockIt">if set to <c>true</c> [f block it].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		[DllImport("user32.dll", EntryPoint = "BlockInput")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BloquearTecladoMouse([MarshalAs(UnmanagedType.Bool)]bool fBlockIt);

        /// <summary>
        /// Struct MSG
        /// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct Msg
		{
            /// <summary>
            /// The HWND
            /// </summary>
			public IntPtr hwnd;
            /// <summary>
            /// The message
            /// </summary>
			[MarshalAs(UnmanagedType.U4)]
			public int message;
            /// <summary>
            /// The w parameter
            /// </summary>
			public IntPtr wParam;
            /// <summary>
            /// The l parameter
            /// </summary>
			public IntPtr lParam;
            /// <summary>
            /// The time
            /// </summary>
			[MarshalAs(UnmanagedType.U4)]
			public int time;
            /// <summary>
            /// The pt
            /// </summary>
			public Point pt;
		}

        /// <summary>
        /// Peeks the message.
        /// </summary>
        /// <param name="lpMsg">The lp MSG.</param>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="wMsgFilterMin">The w MSG filter minimum.</param>
        /// <param name="wMsgFilterMax">The w MSG filter maximum.</param>
        /// <param name="wRemoveMsg">The w remove MSG.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool PeekMessage(ref Msg lpMsg, IntPtr hWnd,
			[MarshalAs(UnmanagedType.U4)]int wMsgFilterMin,
			[MarshalAs(UnmanagedType.U4)]int wMsgFilterMax,
			[MarshalAs(UnmanagedType.U4)]int wRemoveMsg);

        /// <summary>
        /// Limpars the teclado.
        /// </summary>
		public static void LimparTeclado()
		{
			var tpMsg = new Msg();
			while (PeekMessage(ref tpMsg, IntPtr.Zero, 256, 264, 1 | 2)) { }
		}
	}
}
