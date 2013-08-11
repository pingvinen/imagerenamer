using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace ImageRenamer.Gui
{
	public class Config
	{
		private static Config instance = null;

		public static Config GetInstance()
		{
			if (instance == null)
			{
				instance = new Config();
			}

			return instance;
		}

		private Config()
		{
			this.Camera1Folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			this.Camera2Folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			this.OutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			this.Load();
		}

		private string ConfigDir
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ImageRenamer");
			}
		}

		private string ConfigFile
		{
			get
			{
				return Path.Combine(this.ConfigDir, "config.xml");
			}
		}

		public string Camera1Folder { get; set; }
		public string Camera2Folder { get; set; }
		public string OutputFolder { get; set; }

		#region Save
		public void Save()
		{
			if (!Directory.Exists(this.ConfigDir))
			{
				Directory.CreateDirectory(this.ConfigDir);
			}

			var doc = new XDocument(
				new XElement("Config",
			             new XElement("Camera1Folder", this.Camera1Folder),
			             new XElement("Camera2Folder", this.Camera2Folder),
			             new XElement("OutputFolder", this.OutputFolder)
				)
			);

			doc.Save(this.ConfigFile);
		}
		#endregion Save

		#region Load
		private void Load()
		{
			if (!File.Exists(this.ConfigFile))
			{
				return;
			}

			var doc = XDocument.Load(this.ConfigFile);

			XElement tmp;
			tmp = doc.Root.Descendants("Camera1Folder").FirstOrDefault();
			if (tmp != default(XElement))
			{
				this.Camera1Folder = tmp.Value;
			}

			tmp = doc.Root.Descendants("Camera2Folder").FirstOrDefault();
			if (tmp != default(XElement))
			{
				this.Camera2Folder = tmp.Value;
			}

			tmp = doc.Root.Descendants("OutputFolder").FirstOrDefault();
			if (tmp != default(XElement))
			{
				this.OutputFolder = tmp.Value;
			}
		}
		#endregion Load
	}
}