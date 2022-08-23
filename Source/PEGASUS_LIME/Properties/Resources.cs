using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PEGASUS_LIME.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = (resourceMan = new ResourceManager("Resources", typeof(Resources).Assembly));
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap _1
		{
			get
			{
				object @object = ResourceManager.GetObject("1", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string config => ResourceManager.GetString("config", resourceCulture);

		internal static byte[] ConfuserEx
		{
			get
			{
				object @object = ResourceManager.GetObject("ConfuserEx", resourceCulture);
				return (byte[])@object;
			}
		}

		internal static byte[] donut
		{
			get
			{
				object @object = ResourceManager.GetObject("donut", resourceCulture);
				return (byte[])@object;
			}
		}

		internal static Bitmap elogo
		{
			get
			{
				object @object = ResourceManager.GetObject("elogo", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap grammes
		{
			get
			{
				object @object = ResourceManager.GetObject("grammes", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string loader => ResourceManager.GetString("loader", resourceCulture);

		internal static Bitmap matrix1
		{
			get
			{
				object @object = ResourceManager.GetObject("matrix1", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap maxi
		{
			get
			{
				object @object = ResourceManager.GetObject("maxi", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap pegamatrix
		{
			get
			{
				object @object = ResourceManager.GetObject("pegamatrix", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string powersrc => ResourceManager.GetString("powersrc", resourceCulture);

		internal static byte[] ps2exe
		{
			get
			{
				object @object = ResourceManager.GetObject("ps2exe", resourceCulture);
				return (byte[])@object;
			}
		}

		internal static string RK => ResourceManager.GetString("RK", resourceCulture);

		internal static string ShellcodeLoader => ResourceManager.GetString("ShellcodeLoader", resourceCulture);

		internal static byte[] tsimpouki
		{
			get
			{
				object @object = ResourceManager.GetObject("tsimpouki", resourceCulture);
				return (byte[])@object;
			}
		}

		internal static string vbs => ResourceManager.GetString("vbs", resourceCulture);

		internal static Bitmap WinAmp__
		{
			get
			{
				object @object = ResourceManager.GetObject("WinAmp_ ", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap x1
		{
			get
			{
				object @object = ResourceManager.GetObject("x1", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}
