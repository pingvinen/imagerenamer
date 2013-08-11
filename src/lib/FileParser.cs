using System;
using TagLib;

namespace ImageRenamer
{
	public class FileParser
	{
		public FileParser()
		{
		}

		public Picture GetPictureFromFile(string path)
		{
			File f = File.Create(path);
			var res = new Picture() {
				Filename = path
			};

			var tag = (TagLib.Image.ImageTag)f.Tag;
			if (tag.DateTime.HasValue)
			{
				res.DateTime = tag.DateTime.Value;
			}

			return res;
		}
	}
}