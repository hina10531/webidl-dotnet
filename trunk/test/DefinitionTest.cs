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
			var def = new Definition("/home/juanse/lala");
			
			Assert.IsNotNull(def);
		}
	}
}

