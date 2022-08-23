using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using PEGASUS_LIME.Design;

namespace PEGASUS_LIME
{
	internal static class Program
	{
		public static PEGASUS_LIME.Design.PEGASUS form1;

		private static Mutex m;

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			form1 = new PEGASUS_LIME.Design.PEGASUS();
			Application.Run(form1);
		}
	}
}
