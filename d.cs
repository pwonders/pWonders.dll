using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace pWonders
{
	public static class d
	{
		public static void Win32Error(string func)
		{
			Win32Error(func, Marshal.GetLastWin32Error());
		}

		public static void Win32Error(string func, int err)
		{
			Debug.WriteLine("Error " + func + " 0x" + err.ToString("x") + " " + new Win32Exception(err).Message);
		}
	}
}
