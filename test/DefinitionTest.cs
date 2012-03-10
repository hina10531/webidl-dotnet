using System;
using NUnit.Framework;

namespace WebIDL.Test
{
	[TestFixture()]
	public class DefinitionTest
	{
		[Test()]
		public void BasicTest()
		{
			var definition = new Definition("module {};");
		}
	}
}

