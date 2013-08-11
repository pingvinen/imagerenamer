using System;
using System.Collections.Generic;

namespace ImageRenamer
{
	public class PictureCollection : System.Collections.Generic.Dictionary<long, List<Picture>>
	{
		private FileParser parser;

		public PictureCollection() : base()
		{
			this.parser = new FileParser();
		}

		public void AddFromFile(string filename)
		{
			Picture p = this.parser.GetPictureFromFile(filename);

			// in the output filename we only have a resolution of seconds, hence we need the timestamp
			// to be matched with 1-second-resolution
			var ts = (long)(p.DateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)).TotalSeconds;

			if (this.ContainsKey(ts))
			{
				this[ts].Add(p);
			}

			else
			{
				this.Add(ts, new List<Picture>() { p });
			}
		}
	}
}