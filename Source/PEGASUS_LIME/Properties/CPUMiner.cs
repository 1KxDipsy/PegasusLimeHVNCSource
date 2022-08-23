using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PEGASUS_LIME.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed class CPUMiner : ApplicationSettingsBase
	{
		private static CPUMiner defaultInstance = (CPUMiner)SettingsBase.Synchronized(new CPUMiner());

		public static CPUMiner Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpuFile
		{
			get
			{
				return (string)this["cpuFile"];
			}
			set
			{
				this["cpuFile"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_Proc
		{
			get
			{
				return (string)this["cpu_Proc"];
			}
			set
			{
				this["cpu_Proc"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_zipPassword
		{
			get
			{
				return (string)this["cpu_zipPassword"];
			}
			set
			{
				this["cpu_zipPassword"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_workDir
		{
			get
			{
				return (string)this["cpu_workDir"];
			}
			set
			{
				this["cpu_workDir"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_Parametrs
		{
			get
			{
				return (string)this["cpu_Parametrs"];
			}
			set
			{
				this["cpu_Parametrs"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_sysDir
		{
			get
			{
				return (string)this["cpu_sysDir"];
			}
			set
			{
				this["cpu_sysDir"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int cpu_delay
		{
			get
			{
				return (int)this["cpu_delay"];
			}
			set
			{
				this["cpu_delay"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool notInstallCPUgpu6
		{
			get
			{
				return (bool)this["notInstallCPUgpu6"];
			}
			set
			{
				this["notInstallCPUgpu6"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool autoStart_cpu
		{
			get
			{
				return (bool)this["autoStart_cpu"];
			}
			set
			{
				this["autoStart_cpu"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpu_idParameters
		{
			get
			{
				return (string)this["cpu_idParameters"];
			}
			set
			{
				this["cpu_idParameters"] = value;
			}
		}
	}
}
