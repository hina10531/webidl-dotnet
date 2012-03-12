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
using System.IO;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.Collections.ObjectModel;

namespace WebIDL
{
	public class Definition : IContainer
	{
		
		private readonly Dictionary<string,Module> modules = new Dictionary<string,Module>();
		private readonly Dictionary<string,IDefinible> members = new Dictionary<string, IDefinible>();
		
		
		public ReadOnlyCollection<Module> Modules
		{
			get
			{
				var rv = new List<Module>();
				foreach(var val in modules.Values)
					rv.Add(val);
				return new ReadOnlyCollection<Module>(rv);
			}
		}
		
		public IDefinible this[string name]
		{
			get
			{
				return this.members.ContainsKey(name) ? this.members[name] : null;
			}
		}
		
		
		internal Definition(CommonTree tree)
		{
			append(tree);
		}
		
		protected void append(CommonTree tree)
		{
			if(tree.Children == null)
				return;
				
			foreach(var child in tree.Children)
			{
				if(child.Type == Grammar.WebIDLLexer.KW_MODULE)
				{
					var modulename = child.GetChild(0).Text;
					
					if(modules.ContainsKey(modulename))
					{
						modules[modulename].append((CommonTree)child.GetChild(1));
					}
					else
					{
						var newmodule = new Module((CommonTree)child, this);
						modules.Add(newmodule.Name, newmodule);
						members.Add(newmodule.Name, newmodule);
					}
				}
			}
		}
		
		
		public Definition(string sourcetext):this(createFromString(sourcetext))
		{
			
			
		}
		
		private static CommonTree createFromString(string sourcetext)
		{
			var stringstream = new ANTLRStringStream(sourcetext);
			
			var lexer = new Grammar.WebIDLLexer(stringstream);
			
			var tokens = new CommonTokenStream(lexer);
			
			var grammar = new Grammar.WebIDLParser(tokens);
			
			return (CommonTree) grammar.fileDef().Tree;
		}
	}
		
}
