using System;
using System.IO;
using System.Collections.Generic;

namespace ImageRenamer.Gui
{
	public class TheWorker
	{
		public TheWorker()
		{
		}

		public void Run(string cam1dir, string cam2dir, string outdir)
		{
			PictureCollection pics = new PictureCollection();
			
			foreach (string f in Directory.GetFiles(cam1dir))
			{
				pics.AddFromFile(f);
			}
			
			foreach (string f in Directory.GetFiles(cam2dir))
			{
				pics.AddFromFile(f);
			}
			
			
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

		private void CopyFile(string sourceFile, string destinationDir, DateTime timestamp, int increment)
		{
			string destination = Path.Combine(destinationDir, timestamp.ToString("yyyy_MM_dd__HHmmss"));
			
			if (increment >= 0)
			{
				destination = String.Format("{0}_{1}", destination, increment.ToString().PadLeft(2, '0'));
			}
			
			
			destination = String.Format("{0}{1}", destination, Path.GetExtension(sourceFile).ToLower());
			
			System.IO.File.Copy(sourceFile, destination);
		}
	}
}

