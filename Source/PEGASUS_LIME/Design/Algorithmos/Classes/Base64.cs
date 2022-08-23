using System;
using System.Text;
using PEGASUS_LIME.Design.Algorithmos.Interfaces;

namespace PEGASUS_LIME.Design.Algorithmos.Classes
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
