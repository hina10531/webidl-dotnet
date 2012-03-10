using System;
using NUnit.Framework;
using WebIDL.Tools;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace WebIDL.Test.ToolsTest
{
	[TestFixture()]
	public class PreprocessorTest
	{
		private static TextReader getResourceStream(string resourcename)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resource = assembly.GetManifestResourceStream(resourcename);
			return new StreamReader(resource);
		}

		[Test()]
		public void BasicTest()
		{
			var resourcename = "WebIDL.Test.TestResources.Preprocessor.BasicTest.FileOne.idl";
			
			var input = getResourceStream(resourcename);
			
			var specs = getResourceStream(resourcename);

			var errormessage = "When a single file without preprocessing directives must return " +
				"the original content.";
			

			try
			{
				var files = new Dictionary<string,TextReader>();
				files.Add("FileOne", input);
				
				var output = Preprocessor.Preprocess(files);
			
				Assert.AreEqual(output,specs.ReadToEnd(), errormessage);
			}
			catch(Exception ex)
			{
				Assert.Fail("Unexpected exception.",ex);
			}

			input.Close();
			specs.Close();
		}
		[Test()]
		public void DoubleBasicTest()
		{
			var resourcename1 = "WebIDL.Test.TestResources.Preprocessor.BasicTest.FileOne.idl";
			var resourcename2 = "WebIDL.Test.TestResources.Preprocessor.BasicTest.FileTwo.idl";
			
			
			var input1 = getResourceStream(resourcename1);
			var input2 = getResourceStream(resourcename2);
			
			var specs1 = getResourceStream(resourcename1);
			var specs2 = getResourceStream(resourcename2);
			
			var specs = specs1.ReadToEnd() + specs2.ReadToEnd();
			specs1.Close();
			specs2.Close();

			var errormessage = "When receives two files without preprocessing directives should " +
				"return the concatenation of both.";

			try
			{
				var files = new Dictionary<string,TextReader>();
				files.Add("FileOne", input1);
				files.Add("FileTwo", input2);
				
				var output = Preprocessor.Preprocess(files);
			
				Assert.AreEqual(output,specs, errormessage);
			}
			catch(Exception ex)
			{
				Assert.Fail("Unexpected exception.",ex);
			}

			input1.Close();
			input2.Close();
		}
	}
}

