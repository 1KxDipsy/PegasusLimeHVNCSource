using System.Reflection;
using System.Windows.Forms;

namespace PEGASUS_LIME.Boh8oi
{
	public static class ListviewDoubleBuffer
	{
		public static void Enable(ListView listView)
		{
			PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(listView, true, null);
		}
	}
}
