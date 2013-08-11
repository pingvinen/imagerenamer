using System;
using System.Windows.Forms;

namespace ImageRenamer.Gui
{
	public partial class MainForm : Form
	{
		private Config conf;

		public MainForm()
		{
			this.conf = Config.GetInstance();
			this.InitializeComponent();
		}

		#region Button camera 1
		private void buttonCamera1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dia = new FolderBrowserDialog();
			dia.SelectedPath = this.textCamera1.Text;

			DialogResult res = dia.ShowDialog();
			
			if (res == DialogResult.OK)
			{
				this.conf.Camera1Folder = dia.SelectedPath;
				this.conf.Save();
				this.textCamera1.Text = dia.SelectedPath;
			}
		}
		#endregion Button camera 1

		#region Button camera 2
		private void buttonCamera2_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dia = new FolderBrowserDialog();
			dia.SelectedPath = this.textCamera2.Text;
			
			DialogResult res = dia.ShowDialog();
			
			if (res == DialogResult.OK)
			{
				this.conf.Camera2Folder = dia.SelectedPath;
				this.conf.Save();
				this.textCamera2.Text = dia.SelectedPath;
			}
		}
		#endregion Button camera 2

		#region Button output
		private void buttonOutput_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dia = new FolderBrowserDialog();
			dia.SelectedPath = this.textOutput.Text;
			
			DialogResult res = dia.ShowDialog();
			
			if (res == DialogResult.OK)
			{
				this.conf.OutputFolder = dia.SelectedPath;
				this.conf.Save();
				this.textOutput.Text = dia.SelectedPath;
			}
		}
		#endregion Button output
	}
}