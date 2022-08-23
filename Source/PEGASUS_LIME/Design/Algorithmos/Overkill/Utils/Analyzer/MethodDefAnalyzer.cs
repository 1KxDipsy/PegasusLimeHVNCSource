using dnlib.DotNet;

namespace PEGASUS_LIME.Design.Algorithmos.Overkill.Utils.Analyzer
{
	public class MethodDefAnalyzer : DefAnalyzer
	{
		public override bool Execute(object context)
		{
			MethodDef methodDef = (MethodDef)context;
			if (methodDef.IsRuntimeSpecialName)
			{
				return false;
			}
			if (methodDef.DeclaringType.IsForwarder)
			{
				return false;
			}
			if (methodDef.IsConstructor || methodDef.IsStaticConstructor)
			{
				return false;
			}
			return true;
		}
	}
}
