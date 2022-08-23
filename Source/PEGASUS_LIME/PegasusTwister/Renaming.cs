using dnlib.DotNet;
using PEGASUS_LIME.PegasusTwister.Classes;
using PEGASUS_LIME.PegasusTwister.Interfaces;

namespace PEGASUS_LIME.PegasusTwister
{
	public class Renaming
	{
		public static ModuleDefMD DoRenaming(ModuleDefMD inPath)
		{
			return RenamingObfuscation(inPath);
		}

		private static ModuleDefMD RenamingObfuscation(ModuleDefMD inModule)
		{
			ModuleDefMD module = inModule;
			IRenaming renaming = new NamespacesRenaming();
			module = renaming.Rename(module);
			renaming = new ClassesRenaming();
			module = renaming.Rename(module);
			renaming = new MethodsRenaming();
			module = renaming.Rename(module);
			renaming = new PropertiesRenaming();
			module = renaming.Rename(module);
			renaming = new FieldsRenaming();
			return renaming.Rename(module);
		}
	}
}
