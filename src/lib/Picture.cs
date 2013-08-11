using System;

namespace ImageRenamer
{
	public class Picture
	{
		public Picture()
		{
			this.DateTime = DateTime.MinValue;
		}

		public string Filename { get; set; }
		public DateTime DateTime { get; set; }
	}
}