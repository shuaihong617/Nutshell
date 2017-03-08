namespace Nutshell.Hikvision.MachineVision.WPFUI
{
	partial class CameraForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CameraPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// CameraPictureBox
			// 
			this.CameraPictureBox.Location = new System.Drawing.Point(88, 28);
			this.CameraPictureBox.Name = "CameraPictureBox";
			this.CameraPictureBox.Size = new System.Drawing.Size(640, 480);
			this.CameraPictureBox.TabIndex = 0;
			this.CameraPictureBox.TabStop = false;
			// 
			// CameraForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 537);
			this.Controls.Add(this.CameraPictureBox);
			this.Name = "CameraForm";
			this.Text = "CameraForm";
			this.Load += new System.EventHandler(this.CameraForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox CameraPictureBox;
	}
}