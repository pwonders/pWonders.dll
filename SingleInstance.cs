using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace pWonders
{
	public class SingleInstance
	{
		public static string GetUniqueName()
		{
			AssemblyName an = Assembly.GetExecutingAssembly().GetName();
			string name = an.Name + "-";
			object[] attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
			if (attribs.Length > 0)
			{
				name += (attribs[0] as GuidAttribute).Value.Replace("-", "");
			}
			else
			{
				StringBuilder sb = new StringBuilder(32);
				Array.ForEach
				(
					MD5.Create().ComputeHash(Encoding.UTF32.GetBytes(an.FullName)), b =>
					{
						sb.Append(b.ToString("x2"));
					}
				);
				name += sb.ToString();
			}
			return name;
		}

		// See also:
		// https://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c/229567
		public SingleInstance(Action func)
		{
			bool createdNew;
			using (var mutex = new Mutex(false, GetUniqueName(), out createdNew))
			{
				if (createdNew)
				{
					func();
				}
			}
		}
	}
}
