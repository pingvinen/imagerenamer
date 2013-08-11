using System;
using System.Windows.Forms;

namespace ImageRenamer.Gui
{
	public partial class MainForm : Form
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			int margin = 20;
			int halfMargin = margin/2;
			int columnWidth = 400;

			this.labelCamera1 = new System.Windows.Forms.Label();
			this.textCamera1 = new TextBox();
			this.buttonCamera1 = new System.Windows.Forms.Button();
			this.labelCamera2 = new System.Windows.Forms.Label();
			this.textCamera2 = new TextBox();
			this.buttonCamera2 = new System.Windows.Forms.Button();
			this.labelOutput = new System.Windows.Forms.Label();
			this.textOutput = new TextBox();
			this.buttonOutput = new System.Windows.Forms.Button();
			this.buttonRun = new System.Windows.Forms.Button();

			
			this.SuspendLayout();


			#region Camera 1
			// 
			// labelCamera1
			// 
			this.labelCamera1.Name = "labelCamera1";
			this.labelCamera1.Location = new System.Drawing.Point(margin, margin);
			this.labelCamera1.BackColor = System.Drawing.Color.Transparent;
			this.labelCamera1.Text = "Kamera 1";
			this.labelCamera1.AutoSize = true;

			//
			// textCamera1
			//
			this.textCamera1.Name = "textCamera1";
			this.textCamera1.Location = new System.Drawing.Point(margin, this.labelCamera1.Location.Y + this.labelCamera1.Height + halfMargin);
			this.textCamera1.Text = Config.GetInstance().Camera1Folder;
			this.textCamera1.Size = new System.Drawing.Size(columnWidth, 23);

			// 
			// buttonCamera1
			// 
			this.buttonCamera1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCamera1.Location = new System.Drawing.Point(this.textCamera1.Location.X + this.textCamera1.Size.Width + halfMargin, this.textCamera1.Location.Y);
			this.buttonCamera1.Name = "buttonCamera1";
			this.buttonCamera1.TabIndex = 1;
			this.buttonCamera1.Text = "...";
			this.buttonCamera1.UseVisualStyleBackColor = true;
			this.buttonCamera1.Click += new System.EventHandler(this.buttonCamera1_Click);
			#endregion Camera 1

			#region Camera 2
			// 
			// labelCamera2
			// 
			this.labelCamera2.Name = "labelCamera2";
			this.labelCamera2.Location = new System.Drawing.Point(margin, this.buttonCamera1.Location.Y + this.buttonCamera1.Size.Height + margin);
			this.labelCamera2.BackColor = System.Drawing.Color.Transparent;
			this.labelCamera2.Text = "Kamera 2";
			this.labelCamera2.AutoSize = true;
			
			//
			// textCamera2
			//
			this.textCamera2.Name = "textCamera2";
			this.textCamera2.Location = new System.Drawing.Point(margin, this.labelCamera2.Location.Y + this.labelCamera2.Height + halfMargin);
			this.textCamera2.Text = Config.GetInstance().Camera2Folder;
			this.textCamera2.Size = new System.Drawing.Size(columnWidth, 23);
			
			// 
			// buttonCamera2
			// 
			this.buttonCamera2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCamera2.Location = new System.Drawing.Point(this.textCamera2.Location.X + this.textCamera2.Size.Width + halfMargin, this.textCamera2.Location.Y);
			this.buttonCamera2.Name = "buttonCamera2";
			this.buttonCamera2.TabIndex = 1;
			this.buttonCamera2.Text = "...";
			this.buttonCamera2.UseVisualStyleBackColor = true;
			this.buttonCamera2.Click += new System.EventHandler(this.buttonCamera2_Click);
			#endregion Camera 2

			#region Output
			// 
			// labelOutput
			// 
			this.labelOutput.Name = "labelOutput";
			this.labelOutput.Location = new System.Drawing.Point(margin, this.buttonCamera2.Location.Y + this.buttonCamera2.Size.Height + margin);
			this.labelOutput.BackColor = System.Drawing.Color.Transparent;
			this.labelOutput.Text = "Output";
			this.labelOutput.AutoSize = true;
			
			//
			// textOutput
			//
			this.textOutput.Name = "textOutput";
			this.textOutput.Location = new System.Drawing.Point(margin, this.labelOutput.Location.Y + this.labelOutput.Height + halfMargin);
			this.textOutput.Text = Config.GetInstance().OutputFolder;
			this.textOutput.Size = new System.Drawing.Size(columnWidth, 23);

			// 
			// buttonOutput
			// 
			this.buttonOutput.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOutput.Location = new System.Drawing.Point(this.textOutput.Location.X + this.textOutput.Size.Width + halfMargin, this.textOutput.Location.Y);
			this.buttonOutput.Name = "buttonOutput";
			this.buttonOutput.TabIndex = 1;
			this.buttonOutput.Text = "...";
			this.buttonOutput.UseVisualStyleBackColor = true;
			this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
			#endregion Output

			// 
			// buttonRun
			// 
			this.buttonRun.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonRun.Location = new System.Drawing.Point(margin, this.textOutput.Location.Y + this.textOutput.Height + margin);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.TabIndex = 1;
			this.buttonRun.Text = "Start";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);

			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(
				3*margin + columnWidth + this.buttonCamera1.Size.Width,
				5*margin + 3*this.labelCamera1.Height + 3*this.textCamera1.Height + 3*halfMargin + this.buttonRun.Height
				);
			this.Controls.Add(this.labelCamera1);
			this.Controls.Add(this.textCamera1);
			this.Controls.Add(this.buttonCamera1);
			this.Controls.Add(this.labelCamera2);
			this.Controls.Add(this.textCamera2);
			this.Controls.Add(this.buttonCamera2);
			this.Controls.Add(this.labelOutput);
			this.Controls.Add(this.textOutput);
			this.Controls.Add(this.buttonOutput);
			this.Controls.Add(this.buttonRun);
			this.Name = "MainForm";
			this.Text = "ImageRenamer";
			this.StartPosition = FormStartPosition.CenterScreen;

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label labelCamera1;
		private System.Windows.Forms.TextBox textCamera1;
		private System.Windows.Forms.Button buttonCamera1;

		private System.Windows.Forms.Label labelCamera2;
		private System.Windows.Forms.TextBox textCamera2;
		private System.Windows.Forms.Button buttonCamera2;

		private System.Windows.Forms.Label labelOutput;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.Button buttonOutput;

		private System.Windows.Forms.Button buttonRun;
	}
}

