using System;

namespace ImageRenamer
{
	public class Picture
	{
		public string Filename { get; set; }
		public DateTime DateTime { get; set; } = DateTime.MinValue;
	}
}