/*

This file is part of webidl-dotnet.

webidl-dotnet is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using NUnit.Framework;

namespace WebIDL.Test
{
	[TestFixture()]
	public class DefinitionTest
	{			
		[Test()]
		public void Module()
		{
			var doc = new Document("module a{};");
			Assert.AreEqual("a",doc.Members["a"].Name);
		}
		
		
		[Test()]
		public void InnerModule()
		{
			var doc = new Document("module a{module b{};};module a{module c{};};");
			
			var innerMod = doc.Members["a"] as Module;
			
			Assert.IsInstanceOf<Module>(innerMod.Members["b"]);
			Assert.AreSame(innerMod, innerMod.Members["c"].Parent );
			
		}
		
		[Test()]
		public void Enumerate()
		{
			var doc = new Document("enum test { \"a\",\"b\" };");
			
			var enumerate = doc.Members["test"] as Enumerate;
			
			Assert.AreEqual("a", enumerate.Values[0]);
			Assert.AreEqual("b",enumerate.Values[1]);
		}

	}
}

