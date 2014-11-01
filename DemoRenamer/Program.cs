using DemoInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRenamer
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach(var file in args)
			{

				if(File.Exists(file))
				{
					var s = File.OpenRead(file);
					DemoParser p = new DemoParser(s);
					p.ParseDemo(false);

					var header = p.Header;

					s.Close();

					var fName = Path.GetFileName(file);
					var dir = Path.GetDirectoryName(file);

					File.Move(file, Path.Combine(dir, header.MapName + "_" + header.PlaybackTicks + "_" + fName));
				}
				else
				{
					Console.WriteLine("File " + file + "not found");
				}
			}
		}
	}
}
