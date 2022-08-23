using dnlib.DotNet;

namespace PEGASUS_LIME.PegasusTwister.Overkill.Utils.Analyzer
{
	public class ParameterAnalyzer : DefAnalyzer
	{
		public override bool Execute(object context)
		{
			Parameter parameter = (Parameter)context;
			if (parameter.Name == string.Empty)
			{
				return false;
			}
			return true;
		}
	}
}
