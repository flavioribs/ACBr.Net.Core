using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACBr.Net.Core
{
	public static class UtilTEF
	{
		[DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
		[return: MarshalAsAttribute(UnmanagedType.Bool)]
		public static extern bool BringWindowToFocus(IntPtr hWnd);

		[DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
		[return: MarshalAsAttribute(UnmanagedType.Bool)]
		public static extern bool BloquearTecladoMouse([MarshalAsAttribute(UnmanagedType.Bool)] bool fBlockIt);

		[StructLayout(LayoutKind.Sequential)]
		private struct MSG
		{
			public IntPtr hwnd;
			[MarshalAs(UnmanagedType.U4)]
			public int message;
			public IntPtr wParam;
			public IntPtr lParam;
			[MarshalAs(UnmanagedType.U4)]
			public int time;
			public Point pt;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool PeekMessage(ref MSG lpMsg, IntPtr hWnd,
			[MarshalAs(UnmanagedType.U4)]int wMsgFilterMin,
			[MarshalAs(UnmanagedType.U4)]int wMsgFilterMax,
			[MarshalAs(UnmanagedType.U4)]int wRemoveMsg);

		public static void LimparTeclado()
		{
			var tpMSG = new MSG();
			while (PeekMessage(ref tpMSG, IntPtr.Zero, 256, 264, 1 | 2)) { }
		}
	}
}
