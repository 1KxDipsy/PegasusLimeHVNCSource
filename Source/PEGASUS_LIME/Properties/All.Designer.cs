using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PEGASUS_LIME.Properties
{
	// Token: 0x02000056 RID: 86
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class All : ApplicationSettingsBase
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00026398 File Offset: 0x00026398
		public static All Default
		{
			get
			{
				return All.defaultInstance;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000263B0 File Offset: 0x000263B0
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000263D2 File Offset: 0x000263D2
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000263E4 File Offset: 0x000263E4
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00026406 File Offset: 0x00026406
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000312 RID: 786 RVA: 0x00026418 File Offset: 0x00026418
		// (set) Token: 0x06000313 RID: 787 RVA: 0x0002643A File Offset: 0x0002643A
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0002644C File Offset: 0x0002644C
		// (set) Token: 0x06000315 RID: 789 RVA: 0x0002646E File Offset: 0x0002646E
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

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00026480 File Offset: 0x00026480
		// (set) Token: 0x06000317 RID: 791 RVA: 0x000264A2 File Offset: 0x000264A2
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

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000318 RID: 792 RVA: 0x000264B8 File Offset: 0x000264B8
		// (set) Token: 0x06000319 RID: 793 RVA: 0x000264DA File Offset: 0x000264DA
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

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600031A RID: 794 RVA: 0x000264F0 File Offset: 0x000264F0
		// (set) Token: 0x0600031B RID: 795 RVA: 0x00026512 File Offset: 0x00026512
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

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00026524 File Offset: 0x00026524
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00026546 File Offset: 0x00026546
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

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0002655C File Offset: 0x0002655C
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0002657E File Offset: 0x0002657E
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

		// Token: 0x040002A7 RID: 679
		private static All defaultInstance = (All)SettingsBase.Synchronized(new All());
	}
}
