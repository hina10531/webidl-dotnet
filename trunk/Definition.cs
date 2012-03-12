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
		private readonly List<Module> modules = new List<Module>();
		private readonly Dictionary<string,IDefinible> members = new Dictionary<string, IDefinible>();
		
		
		public ReadOnlyCollection<Module> Modules
		{
			get
			{
				return new ReadOnlyCollection<Module>( modules);
			}
		}
		
		public IDefinible this[string name]
		{
			get
			{
				
			return this.members[name];
			}
		}
		
		
		public Definition(string sourcetext)
		{
			var tree = createFromString(sourcetext);
			
			IList<ITree> children;
			if(tree.IsNil)
			{
				children = tree.Children;
			}
			else
			{
				children = new List<ITree>();
				children.Add(tree);
			}
			
			
			foreach(var child in children)
			{
				if(child.Type == Grammar.WebIDLLexer.KW_MODULE)
				{
					var newmodule = new Module(child.GetChild(0).Text, this);
					
					modules.Add(newmodule);
					members.Add(newmodule.Name, newmodule);
					
				}
			}
			
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

