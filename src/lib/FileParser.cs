using System;

namespace ImageRenamer
{
	public class FileParser
	{
		private readonly MetaExtractor metaExtractor;
		
		public FileParser()
		{
			metaExtractor = new MetaExtractor();
		}

		public Picture GetPictureFromFile(string path)
		{
			var res = new Picture {
				Filename = path
			};

			var meta = metaExtractor.GetMetaDataFromFile(res.Filename);

			if (meta.OriginalDateTime.HasValue)
			{
				res.DateTime = meta.OriginalDateTime.Value;
			}

			return res;
		}
	}
}