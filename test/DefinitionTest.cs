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
using System.Collections.Generic;

namespace WebIDL.Test
{
	abstract class PackageWalker
	{
		private IContainer container;
		public PackageWalker(IContainer container)
		{
			this.container = container;
		}
		
		protected void start()
		{
			foreach(var member in container.Members)
			{
				foreach(var method in this.GetType().GetMethods())
				{
					if(method.Name == "Found" && method.GetParameters()[0].ParameterType == member.GetType())
						method.Invoke(this,new object[] { member });
				}   
			}
		}
		
		public abstract void Found(Module mod);
		public abstract void Found(Enumerate mod);
	}
	
	
	
	class Assert : NUnit.Framework.Assert
	{
		public static void Throws<T>(Action action) where T : Exception
		{
			try
			{
				action();
			}
			catch(T)
			{
				return;
			}
			Assert.Fail();
		}
		
		public static void Throws<T>(Action action, string message) where T : Exception
		{
			try
			{
				action();
			}
			catch(T)
			{
				return;
			}
			Assert.Fail(message);
		}
		
		public static void Throws<T>(Action action, string message, params object[] args) where T : Exception
		{
			try
			{
				action();
			}
			catch(T)
			{
				return;
			}
			Assert.Fail(message, args);
		}
	}
	
	
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
			
			Assert.Throws<Enumerate.RepeatValueException>(() => new Document("enum {\"a\",\"a\"};"));
		}
		
		[Test()]
		public void ValuetypeOfInterface()
		{
			var doc = new Document("interface myInterface { };  valuetype myInterfaceByValue myInterface;");
			
			Assert.AreSame( (doc.Members["myInterfaceByValue"] as Valuetype).ValuedType , doc.Members["myInterface"]);
			
			Console.WriteLine(((doc.Members["myInterfaceByValue"] as Valuetype).ValuedType as Interface ).Name );
		}
		
	}

}

