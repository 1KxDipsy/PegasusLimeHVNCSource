using dnlib.DotNet;

namespace PEGASUS_LIME.PegasusTwister.Interfaces
{
	public interface IRenaming
	{
		ModuleDefMD Rename(ModuleDefMD module);
	}
}
