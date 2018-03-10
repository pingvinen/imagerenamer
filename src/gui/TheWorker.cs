using System;
using System.IO;
using System.Collections.Generic;

namespace ImageRenamer.Gui
{
	public class TheWorker
	{
		private static IList<string> Extensions = new List<string> { ".jpg", ".jpeg", ".cr2", ".nef" };
		
		public TheWorker()
		{
		}
		

		public void Run(string cam1Dir, string cam2Dir, string outdir)
		{
			PictureCollection pics = new PictureCollection();

			AddFilesFromDirectory(cam1Dir, pics);
			AddFilesFromDirectory(cam2Dir, pics);
			
			if (pics.Count > 0)
			{
				if (!Directory.Exists(outdir))
				{
					Directory.CreateDirectory(outdir);
				}
				
				
				List<Picture> list;
				foreach (KeyValuePair<long, List<Picture>> kvp in pics)
				{
					list = kvp.Value;
					
					if (list.Count == 1)
					{
						this.CopyFile(list[0].Filename, outdir, list[0].DateTime, -1);
					}
					
					else
					{
						for (int i=0; i!=list.Count; i++)
						{
							this.CopyFile(list[i].Filename, outdir, list[i].DateTime, i);
						}
					}
				}
			}
		}

		private void AddFilesFromDirectory(string dir, PictureCollection pics)
		{
			foreach (var f in Directory.GetFiles(dir))
			{
				if (Extensions.Contains(Path.GetExtension(f).ToLower()))
				{
					pics.AddFromFile(f);
				}
			}
		}

		private void CopyFile(string sourceFile, string destinationDir, DateTime timestamp, int increment)
		{
			string destination = Path.Combine(destinationDir, timestamp.ToString("yyyy-MM-dd HHmmss"));
			
			if (increment >= 0)
			{
				destination = String.Format("{0} {1}", destination, increment.ToString().PadLeft(2, '0'));
			}
			
			
			destination = String.Format("{0}{1}", destination, Path.GetExtension(sourceFile).ToLower());
			
			System.IO.File.Copy(sourceFile, destination);
		}
	}
}

