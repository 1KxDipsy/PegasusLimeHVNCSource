using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PEGASUS_LIME.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed class All : ApplicationSettingsBase
	{
		private static All defaultInstance = (All)SettingsBase.Synchronized(new All());

		public static All Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Ports
		{
			get
			{
				return (string)this["Ports"];
			}
			set
			{
				this["Ports"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("listBlocked")]
		public string txtBlocked
		{
			get
			{
				return (string)this["txtBlocked"];
			}
			set
			{
				this["txtBlocked"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string idChactTG
		{
			get
			{
				return (string)this["idChactTG"];
			}
			set
			{
				this["idChactTG"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string tokenTG
		{
			get
			{
				return (string)this["tokenTG"];
			}
			set
			{
				this["tokenTG"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool tgNotification
		{
			get
			{
				return (bool)this["tgNotification"];
			}
			set
			{
				this["tgNotification"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool Notification
		{
			get
			{
				return (bool)this["Notification"];
			}
			set
			{
				this["Notification"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string keyPanel
		{
			get
			{
				return (string)this["keyPanel"];
			}
			set
			{
				this["keyPanel"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool domainScaner
		{
			get
			{
				return (bool)this["domainScaner"];
			}
			set
			{
				this["domainScaner"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string domainScanURL
		{
			get
			{
				return (string)this["domainScanURL"];
			}
			set
			{
				this["domainScanURL"] = value;
			}
		}
	}
}
