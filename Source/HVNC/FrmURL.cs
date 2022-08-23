using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using PEGASUS_LIME.Design;
using PEGASUS_LIME.Properties;

namespace HVNC
{
	public class FrmURL : Form
	{
		public int count;

		private IContainer components;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Label label18;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2DragControl guna2DragControl1;

		private Guna2Button StartHiddenURLbtn;

		private Guna2BorderlessForm guna2BorderlessForm2;

		private Guna2ShadowForm guna2ShadowForm1;

		public Guna2TextBox Urlbox;

		public FrmURL()
		{
			InitializeComponent();
		}

		private void StartHiddenURLbtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(Urlbox.Text))
				{
					int num = (int)MessageBox.Show("URL is not valid!");
					return;
				}
				PEGASUS_LIME.Design.PEGASUS.saveurl = Urlbox.Text;
				PEGASUS_LIME.Design.PEGASUS.ispressed = true;
				Close();
			}
			catch (Exception)
			{
				int num2 = (int)MessageBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmURL));
			panel1 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label18 = new System.Windows.Forms.Label();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			StartHiddenURLbtn = new Guna.UI2.WinForms.Guna2Button();
			Urlbox = new Guna.UI2.WinForms.Guna2TextBox();
			guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.Black;
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(579, 43);
			panel1.TabIndex = 14;
			pictureBox1.Image = PEGASUS_LIME.Properties.Resources.pegamatrix;
			pictureBox1.Location = new System.Drawing.Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(68, 40);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label18.ForeColor = System.Drawing.Color.Gainsboro;
			label18.Location = new System.Drawing.Point(210, 10);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(138, 19);
			label18.TabIndex = 2;
			label18.Text = "Visit URL (Hidden)";
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(480, 4);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 36);
			guna2ControlBox2.TabIndex = 0;
			guna2ControlBox2.UseTransparentBackground = true;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox1.BackgroundImage");
			guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(531, 4);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.ShowIcon = false;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 36);
			guna2ControlBox1.TabIndex = 0;
			guna2ControlBox1.UseTransparentBackground = true;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = panel1;
			guna2DragControl1.UseTransparentDrag = true;
			StartHiddenURLbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			StartHiddenURLbtn.Animated = true;
			StartHiddenURLbtn.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			StartHiddenURLbtn.BorderThickness = 1;
			StartHiddenURLbtn.CheckedState.BorderColor = System.Drawing.Color.White;
			StartHiddenURLbtn.CheckedState.FillColor = System.Drawing.Color.Black;
			StartHiddenURLbtn.CheckedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			StartHiddenURLbtn.CheckedState.Parent = StartHiddenURLbtn;
			StartHiddenURLbtn.CustomImages.Parent = StartHiddenURLbtn;
			StartHiddenURLbtn.DisabledState.BorderColor = System.Drawing.Color.White;
			StartHiddenURLbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			StartHiddenURLbtn.DisabledState.FillColor = System.Drawing.Color.Black;
			StartHiddenURLbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			StartHiddenURLbtn.DisabledState.Parent = StartHiddenURLbtn;
			StartHiddenURLbtn.FillColor = System.Drawing.Color.Black;
			StartHiddenURLbtn.Font = new System.Drawing.Font("Electrolize", 9f);
			StartHiddenURLbtn.ForeColor = System.Drawing.Color.White;
			StartHiddenURLbtn.HoverState.BorderColor = System.Drawing.Color.White;
			StartHiddenURLbtn.HoverState.CustomBorderColor = System.Drawing.Color.Black;
			StartHiddenURLbtn.HoverState.FillColor = System.Drawing.Color.FromArgb(9, 248, 121);
			StartHiddenURLbtn.HoverState.Parent = StartHiddenURLbtn;
			StartHiddenURLbtn.Image = PEGASUS_LIME.Properties.Resources.WinAmp__;
			StartHiddenURLbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
			StartHiddenURLbtn.ImageSize = new System.Drawing.Size(30, 30);
			StartHiddenURLbtn.Location = new System.Drawing.Point(71, 162);
			StartHiddenURLbtn.Name = "StartHiddenURLbtn";
			StartHiddenURLbtn.ShadowDecoration.Parent = StartHiddenURLbtn;
			StartHiddenURLbtn.Size = new System.Drawing.Size(444, 42);
			StartHiddenURLbtn.TabIndex = 50;
			StartHiddenURLbtn.Text = "Start";
			StartHiddenURLbtn.Click += new System.EventHandler(StartHiddenURLbtn_Click);
			Urlbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			Urlbox.BorderColor = System.Drawing.Color.FromArgb(9, 248, 121);
			Urlbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			Urlbox.DefaultText = "Your URL";
			Urlbox.DisabledState.BorderColor = System.Drawing.Color.White;
			Urlbox.DisabledState.FillColor = System.Drawing.Color.Black;
			Urlbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			Urlbox.DisabledState.Parent = Urlbox;
			Urlbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			Urlbox.FillColor = System.Drawing.Color.Black;
			Urlbox.FocusedState.BorderColor = System.Drawing.Color.White;
			Urlbox.FocusedState.FillColor = System.Drawing.Color.Black;
			Urlbox.FocusedState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			Urlbox.FocusedState.Parent = Urlbox;
			Urlbox.Font = new System.Drawing.Font("Electrolize", 9f);
			Urlbox.ForeColor = System.Drawing.Color.Gainsboro;
			Urlbox.HoverState.BorderColor = System.Drawing.Color.White;
			Urlbox.HoverState.FillColor = System.Drawing.Color.Black;
			Urlbox.HoverState.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			Urlbox.HoverState.Parent = Urlbox;
			Urlbox.Location = new System.Drawing.Point(71, 104);
			Urlbox.Name = "Urlbox";
			Urlbox.PasswordChar = '\0';
			Urlbox.PlaceholderText = "";
			Urlbox.SelectedText = "";
			Urlbox.SelectionStart = 8;
			Urlbox.ShadowDecoration.Parent = Urlbox;
			Urlbox.Size = new System.Drawing.Size(444, 41);
			Urlbox.TabIndex = 49;
			guna2BorderlessForm2.ContainerControl = this;
			guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm2.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm2.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(579, 269);
			base.Controls.Add(StartHiddenURLbtn);
			base.Controls.Add(Urlbox);
			base.Controls.Add(panel1);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmURL";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FrmURL";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
