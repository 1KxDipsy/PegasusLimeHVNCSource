using dnlib.DotNet;

namespace PEGASUS_LIME.Design.Algorithmos.Interfaces
{
	public interface IRenaming
	{
		ModuleDefMD Rename(ModuleDefMD module);
	}
}
