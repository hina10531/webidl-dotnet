using System;
using System.Text;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace WebIDL.Tools
{
	internal static class Preprocessor
	{
		public static string Preprocess(Dictionary<string,TextReader> streams)
		{
			var builder = new StringBuilder();

			foreach(var stream in streams)
			{
				builder.Append(stream.Value.ReadToEnd());
			}

			return builder.ToString();
		}
		
		
	}
	
}

