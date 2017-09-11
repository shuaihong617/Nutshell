namespace Nutshell.Automation.DaHeng.WinFormUI
{
        partial class MainForm
        {
                /// <summary>
                /// 必需的设计器变量。
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// 清理所有正在使用的资源。
                /// </summary>
                /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Windows 窗体设计器生成的代码

                /// <summary>
                /// 设计器支持所需的方法 - 不要修改
                /// 使用代码编辑器修改此方法的内容。
                /// </summary>
                private void InitializeComponent()
                {
                        this.MainPictureBox = new System.Windows.Forms.PictureBox();
                        this.StartButton = new System.Windows.Forms.Button();
                        this.groupBox1 = new System.Windows.Forms.GroupBox();
                        this.Card4RadioButton = new System.Windows.Forms.RadioButton();
                        this.Card3RadioButton = new System.Windows.Forms.RadioButton();
                        this.Card2RadioButton = new System.Windows.Forms.RadioButton();
                        this.Card1RadioButton = new System.Windows.Forms.RadioButton();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.Camera4RadioButton = new System.Windows.Forms.RadioButton();
                        this.Camera3RadioButton = new System.Windows.Forms.RadioButton();
                        this.Camera2RadioButton = new System.Windows.Forms.RadioButton();
                        this.Camera1RadioButton = new System.Windows.Forms.RadioButton();
                        this.BrightnessTrackBar = new System.Windows.Forms.TrackBar();
                        this.ContrastTrackBar = new System.Windows.Forms.TrackBar();
                        this.label1 = new System.Windows.Forms.Label();
                        this.BrightnessLabel = new System.Windows.Forms.Label();
                        this.label3 = new System.Windows.Forms.Label();
                        this.ContrastLabel = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
                        this.groupBox1.SuspendLayout();
                        this.groupBox2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // MainPictureBox
                        // 
                        this.MainPictureBox.Location = new System.Drawing.Point(16, 16);
                        this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4);
                        this.MainPictureBox.Name = "MainPictureBox";
                        this.MainPictureBox.Size = new System.Drawing.Size(768, 576);
                        this.MainPictureBox.TabIndex = 0;
                        this.MainPictureBox.TabStop = false;
                        // 
                        // StartButton
                        // 
                        this.StartButton.Location = new System.Drawing.Point(805, 16);
                        this.StartButton.Name = "StartButton";
                        this.StartButton.Size = new System.Drawing.Size(164, 29);
                        this.StartButton.TabIndex = 2;
                        this.StartButton.Text = "开始";
                        this.StartButton.UseVisualStyleBackColor = true;
                        this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.Card4RadioButton);
                        this.groupBox1.Controls.Add(this.Card3RadioButton);
                        this.groupBox1.Controls.Add(this.Card2RadioButton);
                        this.groupBox1.Controls.Add(this.Card1RadioButton);
                        this.groupBox1.Location = new System.Drawing.Point(805, 60);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(164, 140);
                        this.groupBox1.TabIndex = 3;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "采集卡";
                        // 
                        // Card4RadioButton
                        // 
                        this.Card4RadioButton.AutoSize = true;
                        this.Card4RadioButton.Location = new System.Drawing.Point(31, 111);
                        this.Card4RadioButton.Name = "Card4RadioButton";
                        this.Card4RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Card4RadioButton.TabIndex = 3;
                        this.Card4RadioButton.TabStop = true;
                        this.Card4RadioButton.Text = "4号采集卡";
                        this.Card4RadioButton.UseVisualStyleBackColor = true;
                        this.Card4RadioButton.CheckedChanged += new System.EventHandler(this.CardsRadioButton_CheckedChanged);
                        // 
                        // Card3RadioButton
                        // 
                        this.Card3RadioButton.AutoSize = true;
                        this.Card3RadioButton.Location = new System.Drawing.Point(31, 82);
                        this.Card3RadioButton.Name = "Card3RadioButton";
                        this.Card3RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Card3RadioButton.TabIndex = 2;
                        this.Card3RadioButton.TabStop = true;
                        this.Card3RadioButton.Text = "3号采集卡";
                        this.Card3RadioButton.UseVisualStyleBackColor = true;
                        this.Card3RadioButton.CheckedChanged += new System.EventHandler(this.CardsRadioButton_CheckedChanged);
                        // 
                        // Card2RadioButton
                        // 
                        this.Card2RadioButton.AutoSize = true;
                        this.Card2RadioButton.Location = new System.Drawing.Point(31, 53);
                        this.Card2RadioButton.Name = "Card2RadioButton";
                        this.Card2RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Card2RadioButton.TabIndex = 1;
                        this.Card2RadioButton.TabStop = true;
                        this.Card2RadioButton.Text = "2号采集卡";
                        this.Card2RadioButton.UseVisualStyleBackColor = true;
                        this.Card2RadioButton.CheckedChanged += new System.EventHandler(this.CardsRadioButton_CheckedChanged);
                        // 
                        // Card1RadioButton
                        // 
                        this.Card1RadioButton.AutoSize = true;
                        this.Card1RadioButton.Location = new System.Drawing.Point(31, 24);
                        this.Card1RadioButton.Name = "Card1RadioButton";
                        this.Card1RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Card1RadioButton.TabIndex = 0;
                        this.Card1RadioButton.TabStop = true;
                        this.Card1RadioButton.Text = "1号采集卡";
                        this.Card1RadioButton.UseVisualStyleBackColor = true;
                        this.Card1RadioButton.CheckedChanged += new System.EventHandler(this.CardsRadioButton_CheckedChanged);
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.Camera4RadioButton);
                        this.groupBox2.Controls.Add(this.Camera3RadioButton);
                        this.groupBox2.Controls.Add(this.Camera2RadioButton);
                        this.groupBox2.Controls.Add(this.Camera1RadioButton);
                        this.groupBox2.Location = new System.Drawing.Point(805, 211);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(164, 140);
                        this.groupBox2.TabIndex = 4;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "摄像机";
                        // 
                        // Camera4RadioButton
                        // 
                        this.Camera4RadioButton.AutoSize = true;
                        this.Camera4RadioButton.Location = new System.Drawing.Point(31, 111);
                        this.Camera4RadioButton.Name = "Camera4RadioButton";
                        this.Camera4RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Camera4RadioButton.TabIndex = 3;
                        this.Camera4RadioButton.TabStop = true;
                        this.Camera4RadioButton.Text = "4号摄像机";
                        this.Camera4RadioButton.UseVisualStyleBackColor = true;
                        this.Camera4RadioButton.CheckedChanged += new System.EventHandler(this.CamerasRadioButton_CheckedChanged);
                        // 
                        // Camera3RadioButton
                        // 
                        this.Camera3RadioButton.AutoSize = true;
                        this.Camera3RadioButton.Location = new System.Drawing.Point(31, 82);
                        this.Camera3RadioButton.Name = "Camera3RadioButton";
                        this.Camera3RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Camera3RadioButton.TabIndex = 2;
                        this.Camera3RadioButton.TabStop = true;
                        this.Camera3RadioButton.Text = "3号摄像机";
                        this.Camera3RadioButton.UseVisualStyleBackColor = true;
                        this.Camera3RadioButton.CheckedChanged += new System.EventHandler(this.CamerasRadioButton_CheckedChanged);
                        // 
                        // Camera2RadioButton
                        // 
                        this.Camera2RadioButton.AutoSize = true;
                        this.Camera2RadioButton.Location = new System.Drawing.Point(31, 53);
                        this.Camera2RadioButton.Name = "Camera2RadioButton";
                        this.Camera2RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Camera2RadioButton.TabIndex = 1;
                        this.Camera2RadioButton.TabStop = true;
                        this.Camera2RadioButton.Text = "2号摄像机";
                        this.Camera2RadioButton.UseVisualStyleBackColor = true;
                        this.Camera2RadioButton.CheckedChanged += new System.EventHandler(this.CamerasRadioButton_CheckedChanged);
                        // 
                        // Camera1RadioButton
                        // 
                        this.Camera1RadioButton.AutoSize = true;
                        this.Camera1RadioButton.Location = new System.Drawing.Point(31, 24);
                        this.Camera1RadioButton.Name = "Camera1RadioButton";
                        this.Camera1RadioButton.Size = new System.Drawing.Size(98, 20);
                        this.Camera1RadioButton.TabIndex = 0;
                        this.Camera1RadioButton.TabStop = true;
                        this.Camera1RadioButton.Text = "1号摄像机";
                        this.Camera1RadioButton.UseVisualStyleBackColor = true;
                        this.Camera1RadioButton.CheckedChanged += new System.EventHandler(this.CamerasRadioButton_CheckedChanged);
                        // 
                        // BrightnessTrackBar
                        // 
                        this.BrightnessTrackBar.Location = new System.Drawing.Point(812, 410);
                        this.BrightnessTrackBar.Maximum = 255;
                        this.BrightnessTrackBar.Name = "BrightnessTrackBar";
                        this.BrightnessTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
                        this.BrightnessTrackBar.Size = new System.Drawing.Size(45, 182);
                        this.BrightnessTrackBar.TabIndex = 5;
                        this.BrightnessTrackBar.Value = 128;
                        this.BrightnessTrackBar.ValueChanged += new System.EventHandler(this.BrightnessTrackBar_ValueChanged);
                        // 
                        // ContrastTrackBar
                        // 
                        this.ContrastTrackBar.Location = new System.Drawing.Point(918, 410);
                        this.ContrastTrackBar.Maximum = 255;
                        this.ContrastTrackBar.Name = "ContrastTrackBar";
                        this.ContrastTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
                        this.ContrastTrackBar.Size = new System.Drawing.Size(45, 182);
                        this.ContrastTrackBar.TabIndex = 6;
                        this.ContrastTrackBar.Value = 128;
                        this.ContrastTrackBar.ValueChanged += new System.EventHandler(this.ContrastTrackBar_ValueChanged);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(812, 358);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(40, 16);
                        this.label1.TabIndex = 7;
                        this.label1.Text = "亮度";
                        // 
                        // BrightnessLabel
                        // 
                        this.BrightnessLabel.AutoSize = true;
                        this.BrightnessLabel.Location = new System.Drawing.Point(812, 389);
                        this.BrightnessLabel.Name = "BrightnessLabel";
                        this.BrightnessLabel.Size = new System.Drawing.Size(32, 16);
                        this.BrightnessLabel.TabIndex = 8;
                        this.BrightnessLabel.Text = "128";
                        this.BrightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(904, 358);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(56, 16);
                        this.label3.TabIndex = 9;
                        this.label3.Text = "对比度";
                        // 
                        // ContrastLabel
                        // 
                        this.ContrastLabel.AutoSize = true;
                        this.ContrastLabel.Location = new System.Drawing.Point(921, 389);
                        this.ContrastLabel.Name = "ContrastLabel";
                        this.ContrastLabel.Size = new System.Drawing.Size(32, 16);
                        this.ContrastLabel.TabIndex = 10;
                        this.ContrastLabel.Text = "128";
                        this.ContrastLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // MainForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(993, 609);
                        this.Controls.Add(this.ContrastLabel);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.BrightnessLabel);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.ContrastTrackBar);
                        this.Controls.Add(this.BrightnessTrackBar);
                        this.Controls.Add(this.groupBox2);
                        this.Controls.Add(this.groupBox1);
                        this.Controls.Add(this.StartButton);
                        this.Controls.Add(this.MainPictureBox);
                        this.Font = new System.Drawing.Font("宋体", 12F);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Margin = new System.Windows.Forms.Padding(4);
                        this.MaximizeBox = false;
                        this.MinimizeBox = false;
                        this.Name = "MainForm";
                        this.Text = "红外摄像定尺切割系统--采集卡测试程序1.0  武汉九鼎科达科技有限公司 2003-2017";
                        this.Load += new System.EventHandler(this.MainForm_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
                        this.groupBox1.ResumeLayout(false);
                        this.groupBox1.PerformLayout();
                        this.groupBox2.ResumeLayout(false);
                        this.groupBox2.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.PictureBox MainPictureBox;
                private System.Windows.Forms.Button StartButton;
                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.RadioButton Card4RadioButton;
                private System.Windows.Forms.RadioButton Card3RadioButton;
                private System.Windows.Forms.RadioButton Card2RadioButton;
                private System.Windows.Forms.RadioButton Card1RadioButton;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.RadioButton Camera4RadioButton;
                private System.Windows.Forms.RadioButton Camera3RadioButton;
                private System.Windows.Forms.RadioButton Camera2RadioButton;
                private System.Windows.Forms.RadioButton Camera1RadioButton;
                private System.Windows.Forms.TrackBar BrightnessTrackBar;
                private System.Windows.Forms.TrackBar ContrastTrackBar;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label BrightnessLabel;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label ContrastLabel;
        }
}

