using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS_LIME.Properties;

namespace PEGASUS_LIME.Design
{
	public class FormAbout : Form
	{
		public static string IV = "qo1lc3sjd8zpt9cx";

		public static string Key = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";

		public string mauro = bytestopng("b~~zy0%%|odegellcickf$do~%_znk~82|%zxe`oi~$rgf");

		private IContainer components = null;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2GradientButton btnUpdate;

		private Guna2GradientButton guna2GradientButton1;

		private Label txtLastlogin;

		private Label txtUserRank;

		private Label txtHwid;

		private Label txtEmail;

		private Label expiry;

		private Label registerdate;

		private Label username;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label txtVersion;

		private Label label9;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2ShadowForm guna2ShadowForm1;

		public FormAbout()
		{
			InitializeComponent();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Close();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void FormAbout_Load(object sender, EventArgs e)
		{
			txtVersion.Text = base.ProductName + base.ProductVersion;
			username.Text = "Username: " + Log.Darkness.user_data.username;
			expiry.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(Log.Darkness.user_data.subscriptions[0].expiry)).ToString();
			registerdate.Text = "Subscription: " + Log.Darkness.user_data.subscriptions[0].subscription;
		}

		public DateTime UnixTimeToDateTime(long unixtime)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(unixtime).ToLocalTime();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
		}

		public static string bytestopng(string str)
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

		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/shop/");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS_LIME.Design.FormAbout));
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			username = new System.Windows.Forms.Label();
			registerdate = new System.Windows.Forms.Label();
			expiry = new System.Windows.Forms.Label();
			txtEmail = new System.Windows.Forms.Label();
			txtHwid = new System.Windows.Forms.Label();
			txtUserRank = new System.Windows.Forms.Label();
			txtLastlogin = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtVersion = new System.Windows.Forms.Label();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			SuspendLayout();
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = PEGASUS_LIME.Properties.Resources._1;
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(596, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 6;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(637, 67);
			guna2Panel1.TabIndex = 14;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.Black;
			guna2Separator1.Location = new System.Drawing.Point(-250, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1137, 10);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(281, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 19);
			label1.TabIndex = 11;
			label1.Text = "ABOUT";
			guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton1.BorderThickness = 1;
			guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
			guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
			guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
			guna2GradientButton1.FillColor = System.Drawing.Color.Black;
			guna2GradientButton1.FillColor2 = System.Drawing.Color.Black;
			guna2GradientButton1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton1.ForeColor = System.Drawing.Color.White;
			guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.LightGray;
			guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
			guna2GradientButton1.Location = new System.Drawing.Point(12, 275);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(200, 32);
			guna2GradientButton1.TabIndex = 15;
			guna2GradientButton1.Text = "Donate";
			guna2GradientButton1.Click += new System.EventHandler(guna2GradientButton1_Click);
			btnUpdate.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnUpdate.BorderThickness = 1;
			btnUpdate.CheckedState.Parent = btnUpdate;
			btnUpdate.CustomBorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			btnUpdate.CustomImages.Parent = btnUpdate;
			btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnUpdate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnUpdate.DisabledState.Parent = btnUpdate;
			btnUpdate.FillColor = System.Drawing.Color.Black;
			btnUpdate.FillColor2 = System.Drawing.Color.Black;
			btnUpdate.Font = new System.Drawing.Font("Electrolize", 9f);
			btnUpdate.ForeColor = System.Drawing.Color.White;
			btnUpdate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnUpdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnUpdate.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnUpdate.HoverState.Parent = btnUpdate;
			btnUpdate.Location = new System.Drawing.Point(425, 275);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.ShadowDecoration.Parent = btnUpdate;
			btnUpdate.Size = new System.Drawing.Size(200, 32);
			btnUpdate.TabIndex = 16;
			btnUpdate.Text = "Update";
			btnUpdate.Visible = false;
			btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(25, 62);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 15);
			label2.TabIndex = 17;
			label2.Text = "Key:";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.ForeColor = System.Drawing.Color.LightGray;
			label3.Location = new System.Drawing.Point(280, 137);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 15);
			label3.TabIndex = 18;
			label3.Text = "Registration:";
			label3.Visible = false;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.ForeColor = System.Drawing.Color.LightGray;
			label4.Location = new System.Drawing.Point(25, 80);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(99, 15);
			label4.TabIndex = 19;
			label4.Text = "Experation date:";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.ForeColor = System.Drawing.Color.LightGray;
			label5.Location = new System.Drawing.Point(280, 65);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(39, 15);
			label5.TabIndex = 20;
			label5.Text = "Email:";
			label5.Visible = false;
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.ForeColor = System.Drawing.Color.LightGray;
			label6.Location = new System.Drawing.Point(280, 84);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(37, 15);
			label6.TabIndex = 21;
			label6.Text = "Hwid:";
			label6.Visible = false;
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.ForeColor = System.Drawing.Color.LightGray;
			label7.Location = new System.Drawing.Point(280, 103);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(67, 15);
			label7.TabIndex = 22;
			label7.Text = "User Rank:";
			label7.Visible = false;
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.ForeColor = System.Drawing.Color.LightGray;
			label8.Location = new System.Drawing.Point(280, 122);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(66, 15);
			label8.TabIndex = 23;
			label8.Text = "Last Login:";
			label8.Visible = false;
			username.AutoSize = true;
			username.BackColor = System.Drawing.Color.Transparent;
			username.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			username.Location = new System.Drawing.Point(122, 63);
			username.Name = "username";
			username.Size = new System.Drawing.Size(42, 15);
			username.TabIndex = 24;
			username.Text = "label9";
			registerdate.AutoSize = true;
			registerdate.BackColor = System.Drawing.Color.Transparent;
			registerdate.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			registerdate.Location = new System.Drawing.Point(377, 138);
			registerdate.Name = "registerdate";
			registerdate.Size = new System.Drawing.Size(48, 15);
			registerdate.TabIndex = 25;
			registerdate.Text = "label10";
			registerdate.Visible = false;
			expiry.AutoSize = true;
			expiry.BackColor = System.Drawing.Color.Transparent;
			expiry.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			expiry.Location = new System.Drawing.Point(122, 81);
			expiry.Name = "expiry";
			expiry.Size = new System.Drawing.Size(44, 15);
			expiry.TabIndex = 26;
			expiry.Text = "label11";
			txtEmail.AutoSize = true;
			txtEmail.BackColor = System.Drawing.Color.Transparent;
			txtEmail.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtEmail.Location = new System.Drawing.Point(377, 66);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new System.Drawing.Size(46, 15);
			txtEmail.TabIndex = 27;
			txtEmail.Text = "label12";
			txtEmail.Visible = false;
			txtHwid.AutoSize = true;
			txtHwid.BackColor = System.Drawing.Color.Transparent;
			txtHwid.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtHwid.Location = new System.Drawing.Point(377, 85);
			txtHwid.Name = "txtHwid";
			txtHwid.Size = new System.Drawing.Size(46, 15);
			txtHwid.TabIndex = 28;
			txtHwid.Text = "label13";
			txtHwid.Visible = false;
			txtUserRank.AutoSize = true;
			txtUserRank.BackColor = System.Drawing.Color.Transparent;
			txtUserRank.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtUserRank.Location = new System.Drawing.Point(377, 104);
			txtUserRank.Name = "txtUserRank";
			txtUserRank.Size = new System.Drawing.Size(47, 15);
			txtUserRank.TabIndex = 29;
			txtUserRank.Text = "label14";
			txtUserRank.Visible = false;
			txtLastlogin.AutoSize = true;
			txtLastlogin.BackColor = System.Drawing.Color.Transparent;
			txtLastlogin.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtLastlogin.Location = new System.Drawing.Point(377, 123);
			txtLastlogin.Name = "txtLastlogin";
			txtLastlogin.Size = new System.Drawing.Size(47, 15);
			txtLastlogin.TabIndex = 30;
			txtLastlogin.Text = "label15";
			txtLastlogin.Visible = false;
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.ForeColor = System.Drawing.Color.LightGray;
			label9.Location = new System.Drawing.Point(25, 98);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(102, 15);
			label9.TabIndex = 31;
			label9.Text = "Pegasus Version:";
			txtVersion.AutoSize = true;
			txtVersion.BackColor = System.Drawing.Color.Transparent;
			txtVersion.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			txtVersion.Location = new System.Drawing.Point(122, 99);
			txtVersion.Name = "txtVersion";
			txtVersion.Size = new System.Drawing.Size(47, 15);
			txtVersion.TabIndex = 32;
			txtVersion.Text = "label15";
			guna2GroupBox1.BorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.Controls.Add(guna2PictureBox2);
			guna2GroupBox1.Controls.Add(txtVersion);
			guna2GroupBox1.Controls.Add(label2);
			guna2GroupBox1.Controls.Add(label9);
			guna2GroupBox1.Controls.Add(label3);
			guna2GroupBox1.Controls.Add(txtLastlogin);
			guna2GroupBox1.Controls.Add(label4);
			guna2GroupBox1.Controls.Add(txtUserRank);
			guna2GroupBox1.Controls.Add(label5);
			guna2GroupBox1.Controls.Add(txtHwid);
			guna2GroupBox1.Controls.Add(label6);
			guna2GroupBox1.Controls.Add(txtEmail);
			guna2GroupBox1.Controls.Add(label7);
			guna2GroupBox1.Controls.Add(expiry);
			guna2GroupBox1.Controls.Add(label8);
			guna2GroupBox1.Controls.Add(registerdate);
			guna2GroupBox1.Controls.Add(username);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
			guna2GroupBox1.FillColor = System.Drawing.Color.Black;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2GroupBox1.Location = new System.Drawing.Point(12, 77);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(613, 183);
			guna2GroupBox1.TabIndex = 33;
			guna2GroupBox1.Text = "License Information";
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(463, 49);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(127, 115);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 34;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(637, 322);
			base.Controls.Add(btnUpdate);
			base.Controls.Add(guna2GradientButton1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(guna2GroupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormAbout";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "About";
			base.Load += new System.EventHandler(FormAbout_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
