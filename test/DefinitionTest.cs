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
			
			Assert.AreEqual("a",definition.GetModules()[0].Name);
			Assert.AreSame(definition.GetModules()[0], definition.GetMember("a"));
			Assert.AreSame(definition.GetModules()[0].Container, definition);
			
		}
		
		[Test()]
		public void TwoModulesTest()
		{
			var definition = new Definition("module a{}; module b{};");
			Assert.AreEqual(definition.GetMember("a").GetType(),definition.GetModules()[1].GetType());			
			Assert.AreEqual(definition.GetMember("b"), definition.GetModules()[1]);
		}
		
		[Test()]
		public void NestedModule()
		{
			var definition = new Definition("module a{ module b{};};");
			
			Assert.AreEqual("b",definition.GetModules()[0].GetModules()[0].Name); 
			
		}
		
		[Test()]
		public void RepeatModuleIsSame()
		{
			var definition = new Definition("module a{ module b{};}; module a{ module c{};};");
			
			Assert.AreEqual(1,definition.GetModules().Length);
			Assert.AreEqual(definition.GetModules()[0].GetModules().Length,2);
			Assert.AreEqual("b",definition.GetModules()[0].GetModules()[0].Name);
			Assert.AreEqual("c",definition.GetModules()[0].GetModules()[1].Name);
		}
		
		
		[Test()]
		public void SingleLineComment()
		{
			var definition = new Definition("//testtesttest\nmodule a{};");
			Assert.IsNotNull(definition.GetMember("a"));
		}
		
		[Test()]
		public void MultiLineComment()
		{
			var definition = new Definition("module a{}; /* module b{}; */");
			Assert.AreEqual(definition.GetModules().Length,1);
			Assert.AreEqual("a",definition.GetMember("a").Name);
			Assert.IsNull(definition.GetMember("b"));
		}
		
		[Test()]
		public void ValuetypeTest()
		{
			var definition = new Definition("module a{ valuetype b; }; valuetype c;");
			
			Assert.AreEqual("c",definition.GetValuetype("c").Name);
			Assert.IsInstanceOf(typeof(Valuetype), definition.GetModule("a").GetMember("b"));
			
		}
	}
}

