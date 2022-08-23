namespace PEGASUS_LIME.PegasusTwister.Loader
{
	internal class LoaderConfig
	{
		[Replacement(Name = "powershell-data")]
		public string Base64Data;

		[Replacement(Name = "Dropper")]
		public string Classname;

		[Replacement(Name = "$dec")]
		public string Decoded;

		[Replacement(Name = "$whatever")]
		public string Encoded;

		[Replacement(Name = "$instance")]
		public string Instance;

		[Replacement(Name = "Run")]
		public string MethodName;

		[Replacement(Name = "Loader.PEGASUS")]
		public string Namespace;
	}
}
