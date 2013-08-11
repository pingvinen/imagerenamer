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

		#region Button run
		private void buttonRun_Click(object sender, EventArgs e)
		{
			var worker = new TheWorker();

			// just making sure manual changes to folders are saved
			this.conf.Camera1Folder = this.textCamera1.Text;
			this.conf.Camera2Folder = this.textCamera2.Text;
			this.conf.OutputFolder = this.textOutput.Text;
			this.conf.Save();

			if (System.IO.Directory.Exists(this.conf.OutputFolder) && System.IO.Directory.GetFiles(this.conf.OutputFolder).Length > 0)
			{
				DialogResult dialogResult = MessageBox.Show("Output-mappen er ikke tom. Hvis en af de nye filer ender med at have det samme navn som en af filerne i output-mappen, vil der opstå en fejl, men du vil ikke miste filer. Vil du fortsætte alligevel?", "Some Title", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}

			try
			{
				this.buttonRun.Enabled = false;
				worker.Run(this.conf.Camera1Folder, this.conf.Camera2Folder, this.conf.OutputFolder);
				MessageBox.Show("Færdig");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Fejl");
			}

			this.buttonRun.Enabled = true;
		}
		#endregion Button run
	}
}