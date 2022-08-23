using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
namespace custom_alert_notifications
{
	public class alert : Form
	{
		public enum AlertType
		{
			success,
			info,
			warnig,
			error
		}

		private int interval;

		private IContainer components = null;

		private ImageList imageList1;

		private Guna2DragControl bunifuDragControl1;

		private Timer timeout;

		private Timer show;

		private Timer closealert;
		
		private Guna2Transition bunifuFormFadeTransition1;

		private Guna2Transition bunifuTransition1;

		private Guna2Separator bunifuSeparator1;

		private Guna2Separator bunifuSeparator2;

		private Guna2Separator bunifuSeparator3;

		private Guna2Separator bunifuSeparator4;
		
		private Guna2Panel bunifuCards2;

		private Guna2Button bunifuImageButton1;

		private Label message;

		private PictureBox icon;

		public alert(string _message, AlertType type)
		{
			InitializeComponent();
			message.Text = _message;
			switch (type)
			{
			case AlertType.success:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.info:
				BackColor = Color.Gray;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.warnig:
				BackColor = Color.Crimson;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.error:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[2];
				break;
			}
		}

		public static void Show(string message, AlertType type)
		{
			new alert(message, type).Show();
		}

		private void alert_Load(object sender, EventArgs e)
		{
			base.Top = -1 * base.Height;
			base.Left = Screen.PrimaryScreen.Bounds.Width - base.Width - 60;
			show.Start();
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			closealert.Start();
		}

		private void timeout_Tick(object sender, EventArgs e)
		{
			closealert.Start();
		}

		private void show_Tick(object sender, EventArgs e)
		{
			if (base.Top < 60)
			{
				base.Top += interval;
				interval += 2;
			}
			else
			{
				show.Stop();
			}
		}

		private void close_Tick(object sender, EventArgs e)
		{
			if (base.Opacity > 0.0)
			{
				base.Opacity -= 0.2;
			}
			else
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(custom_alert_notifications.alert));
			imageList1 = new System.Windows.Forms.ImageList(components);
			bunifuDragControl1 = new Guna2DragControl(components);
			timeout = new System.Windows.Forms.Timer(components);
			show = new System.Windows.Forms.Timer(components);
			closealert = new System.Windows.Forms.Timer(components);
			bunifuFormFadeTransition1 = new Guna2Transition();
			bunifuTransition1 = new Guna2Transition();
			bunifuSeparator1 = new Guna2Separator();
			bunifuSeparator2 = new Guna2Separator();
			bunifuSeparator3 = new Guna2Separator();
			bunifuSeparator4 = new Guna2Separator();
			bunifuCards2 = new Guna2Panel();
			bunifuImageButton1 = new Guna2Button();
			message = new System.Windows.Forms.Label();
			icon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).BeginInit();
			((System.ComponentModel.ISupportInitialize)icon).BeginInit();
			SuspendLayout();
			imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = System.Drawing.Color.Transparent;
			imageList1.Images.SetKeyName(0, "Computer.png");
			imageList1.Images.SetKeyName(1, "MSN_ .png");
			bunifuDragControl1.TargetControl = this;
			timeout.Enabled = true;
			timeout.Interval = 5000;
			timeout.Tick += new System.EventHandler(timeout_Tick);
			show.Interval = 1;
			show.Tick += new System.EventHandler(show_Tick);
			closealert.Tick += new System.EventHandler(close_Tick);
			bunifuTransition1.Cursor = null;

			bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;

			bunifuSeparator1.Location = new System.Drawing.Point(1, -4);
			bunifuSeparator1.Name = "bunifuSeparator1";
			bunifuSeparator1.Size = new System.Drawing.Size(302, 7);
			bunifuSeparator1.TabIndex = 122;

			bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator2.BackgroundImage");
			bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

			bunifuSeparator2.Location = new System.Drawing.Point(-2, 240);
			bunifuSeparator2.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator2.Name = "bunifuSeparator2";
			bunifuSeparator2.Size = new System.Drawing.Size(514, 10);
			bunifuSeparator2.TabIndex = 255;
			bunifuSeparator3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator3.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator3.BackgroundImage");
			bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

			bunifuSeparator3.Location = new System.Drawing.Point(504, 1);
			bunifuSeparator3.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator3.Name = "bunifuSeparator3";
			bunifuSeparator3.Size = new System.Drawing.Size(10, 246);
			bunifuSeparator3.TabIndex = 256;
			bunifuSeparator4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
			bunifuSeparator4.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator4.BackgroundImage");
			bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

			bunifuSeparator4.Location = new System.Drawing.Point(-5, 1);
			bunifuSeparator4.Margin = new System.Windows.Forms.Padding(2);
			bunifuSeparator4.Name = "bunifuSeparator4";
			bunifuSeparator4.Size = new System.Drawing.Size(10, 244);
			bunifuSeparator4.TabIndex = 257;
			bunifuCards2.BackColor = System.Drawing.Color.Black;
			bunifuCards2.BorderRadius = 5;
			bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards2.ForeColor = System.Drawing.Color.LightGray;
			bunifuCards2.Location = new System.Drawing.Point(0, 0);
			bunifuCards2.Name = "bunifuCards2";
			bunifuCards2.Size = new System.Drawing.Size(510, 10);
			bunifuCards2.TabIndex = 261;
			bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
			bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
			bunifuImageButton1.Location = new System.Drawing.Point(419, 12);
			bunifuImageButton1.Name = "bunifuImageButton1";
			bunifuImageButton1.Size = new System.Drawing.Size(95, 70);
			bunifuImageButton1.TabIndex = 260;
			bunifuImageButton1.TabStop = false;
			bunifuImageButton1.Visible = false;
			message.AutoSize = true;
			message.BackColor = System.Drawing.Color.Transparent;
			message.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			message.ForeColor = System.Drawing.Color.White;
			message.Location = new System.Drawing.Point(126, 64);
			message.Name = "message";
			message.Size = new System.Drawing.Size(135, 18);
			message.TabIndex = 259;
			message.Text = "Success message ";
			icon.BackColor = System.Drawing.Color.Transparent;
			icon.Image = (System.Drawing.Image)resources.GetObject("icon.Image");
			icon.Location = new System.Drawing.Point(11, 39);
			icon.Name = "icon";
			icon.Size = new System.Drawing.Size(113, 105);
			icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			icon.TabIndex = 258;
			icon.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(510, 246);
			base.Controls.Add(bunifuCards2);
			base.Controls.Add(message);
			base.Controls.Add(icon);
			base.Controls.Add(bunifuSeparator2);
			base.Controls.Add(bunifuSeparator1);
			base.Controls.Add(bunifuSeparator3);
			base.Controls.Add(bunifuSeparator4);
			base.Controls.Add(bunifuImageButton1);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "alert";
			base.Opacity = 0.95;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "alert";
			base.TopMost = true;
			base.Load += new System.EventHandler(alert_Load);
			((System.ComponentModel.ISupportInitialize)bunifuImageButton1).EndInit();
			((System.ComponentModel.ISupportInitialize)icon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
