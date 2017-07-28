using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace pWonders
{
	public class SingleInstance
	{
		// See also:
		// https://stackoverflow.com/questions/229565/what-is-a-good-pattern-for-using-a-global-mutex-in-c/229567
		public SingleInstance(Action func)
		{
			string name = this.GetType().Name + "-";
			object[] attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
			if (attribs.Length > 0)
			{
				name += (attribs[0] as GuidAttribute).Value;
			}
			else
			{
				name += Assembly.GetExecutingAssembly().GetName().Name;
			}
			bool createdNew;

			using (var mutex = new Mutex(false, name, out createdNew))
			{
				if (createdNew)
				{
					func();
				}
			}
		}
	}
}
