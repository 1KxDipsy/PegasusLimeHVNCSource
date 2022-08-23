using dnlib.DotNet;

namespace PEGASUS_LIME.PegasusTwister.Overkill.Utils.Analyzer
{
	public class EventDefAnalyzer : DefAnalyzer
	{
		public override bool Execute(object context)
		{
			EventDef eventDef = (EventDef)context;
			if (eventDef.IsRuntimeSpecialName)
			{
				return false;
			}
			return true;
		}
	}
}
