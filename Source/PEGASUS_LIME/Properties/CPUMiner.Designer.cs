using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PEGASUS_LIME.Properties
{
	// Token: 0x02000057 RID: 87
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class CPUMiner : ApplicationSettingsBase
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000322 RID: 802 RVA: 0x000265B0 File Offset: 0x000265B0
		public static CPUMiner Default
		{
			get
			{
				return CPUMiner.defaultInstance;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000323 RID: 803 RVA: 0x000265C8 File Offset: 0x000265C8
		// (set) Token: 0x06000324 RID: 804 RVA: 0x000265EA File Offset: 0x000265EA
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000265FC File Offset: 0x000265FC
		// (set) Token: 0x06000326 RID: 806 RVA: 0x0002661E File Offset: 0x0002661E
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

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00026630 File Offset: 0x00026630
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00026652 File Offset: 0x00026652
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

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00026664 File Offset: 0x00026664
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00026686 File Offset: 0x00026686
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

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00026698 File Offset: 0x00026698
		// (set) Token: 0x0600032C RID: 812 RVA: 0x000266BA File Offset: 0x000266BA
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

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600032D RID: 813 RVA: 0x000266CC File Offset: 0x000266CC
		// (set) Token: 0x0600032E RID: 814 RVA: 0x000266EE File Offset: 0x000266EE
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

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00026700 File Offset: 0x00026700
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00026722 File Offset: 0x00026722
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

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00026738 File Offset: 0x00026738
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0002675A File Offset: 0x0002675A
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

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00026770 File Offset: 0x00026770
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00026792 File Offset: 0x00026792
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

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000267A8 File Offset: 0x000267A8
		// (set) Token: 0x06000336 RID: 822 RVA: 0x000267CA File Offset: 0x000267CA
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

		// Token: 0x040002A8 RID: 680
		private static CPUMiner defaultInstance = (CPUMiner)SettingsBase.Synchronized(new CPUMiner());
	}
}
