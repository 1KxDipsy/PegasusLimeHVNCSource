namespace PEGASUS_LIME.PegasusTwister.Loader
{
	internal class Config
	{
		[Replacement(Name = "ApplicationData")]
		public string ApplicationData;

		[Replacement(Name = "Dropper")]
		public string Classname;

		[Replacement(Name = "DirectURL")]
		public string DirectURL;

		[Replacement(Name = "MainMethod")]
		public string MethodName;

		[Replacement(Name = "LoadApp")]
		public string MethodName2;

		[Replacement(Name = "DownloadData")]
		public string MethodName3;

		[Replacement(Name = "Loader.PEGASUS")]
		public string Namespace;

		[Replacement(Name = "URL2")]
		public string URL2;
	}
}
