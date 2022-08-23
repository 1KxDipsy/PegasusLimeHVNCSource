using System;
using System.Text;
using PEGASUS_LIME.PegasusTwister.Interfaces;

namespace PEGASUS_LIME.PegasusTwister.Classes
{
	public class Base64 : ICrypto
	{
		public string Encrypt(string dataPlain)
		{
			try
			{
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(dataPlain));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
