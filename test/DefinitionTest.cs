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
		public void BasicTest()
		{
			var definition = new Definition("module a {};");
			
			Assert.AreEqual("a",definition.Modules[0].Name);
			Assert.AreSame(definition.Modules[0], definition["a"]);
			Assert.AreSame(definition.Modules[0].Container, definition);
			
		}
		
		[Test()]
		public void TwoModulesTest()
		{
			var definition = new Definition("module a{}; module b{};");
			Assert.AreEqual(definition["a"].GetType(),definition.Modules[1].GetType());			
			Assert.AreEqual(definition["b"], definition.Modules[1]);
		}
		
		[Test()]
		public void NestedModule()
		{
			var definition = new Definition("module a{ module b{};};");
			
			Assert.AreEqual("b",definition.Modules[0].Modules[0].Name); 
			
		}
		
		[Test()]
		public void RepeatModuleIsSame()
		{
			var definition = new Definition("module a{ module b{};}; module a{ module c{};};");
			
			Assert.AreEqual(1,definition.Modules.Count);
			Assert.AreEqual(definition.Modules[0].Modules.Count,2);
			Assert.AreEqual("b",definition.Modules[0].Modules[0].Name);
			Assert.AreEqual("c",definition.Modules[0].Modules[1].Name);
		}
		
		
		[Test()]
		public void SingleLineComment()
		{
			var definition = new Definition("//testtesttest\nmodule a{};");
			Assert.IsNotNull(definition["a"]);
		}
		
		[Test()]
		public void MultiLineComment()
		{
			var definition = new Definition("module a{}; /* module b{}; */");
			Assert.AreEqual(definition.Modules.Count,1);
			Assert.AreEqual("a",definition["a"].Name);
			Assert.IsNull(definition["b"]);
		}
	}
}
