using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using WebIDL.Grammar;

namespace WebIDL
{
	public class DefinitionList
	{
		internal Dictionary<string,IDefinition> members = new Dictionary<string, IDefinition>();
		public DefinitionList(CommonTree tree, Container parent)
		{
			if(tree.Children == null)
				return;
		
		
			foreach(var childitree in tree.Children)
			{
				var child = (CommonTree) childitree;
				var name = child.Children[0].Text;
				
				if(child.Type == WebIDLLexer.KW_MODULE)
				{
					//IF NOT EXISTS
					if(!members.ContainsKey(name))
					{
						//CREATE IT
						members.Add(name, new Module(child,parent));
					}
					else if(members[name] is Module)
					{
						//IF EXISTS EXTEND IT
						//((Module) members[name]).childs.append(child);
					}
					else
					{
						//IF NOT NAME DUPLICATE
						throw new InvalidOperationException("Nombre ya definifo");
					}
				}
				/*else if(child.Type == WebIDLLexer.KW_VALUETYPE)
				{
					if(!members.ContainsKey(name))
					{
						members.Add(name,new Valuetype(child, this));
					}
					else
					{
						throw new InvalidOperationException("Nombre ya definifo");
					}
				}*/
				else
				{
					throw new NotImplementedException();
				}
			}
		}
	}
}

