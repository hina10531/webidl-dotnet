using System;
using Antlr.Runtime.Tree;
using WebIDL.Grammar;

namespace WebIDL
{
	public class Package : MemberMap<Definition>
	{
		internal Package (CommonTree tree, IContainer owner):base(tree,owner)
		{
		}
		internal override void append(CommonTree tree)
		{
			if(tree.Children == null)
				return;
			
			foreach(var itreeChild in tree.Children)
			{
				var child = (CommonTree) itreeChild;
				
				var name = child.Children[0].Text;
				
				if(child.Type == WebIDLLexer.KW_MODULE)
				{
					//IF NOT EXISTS
					if(!members.ContainsKey(name))
					{
						//CREATE IT
						members.Add(name, new Module(child,owner));
					}
					else if(members[name] is Module)
					{
						//IF EXISTS EXTEND IT
						//((Module) members[name]).childs.append(child);
					}
					else
					{
						//IF NOT NAME DUPLICATE
						
					}
				}
				else if(child.Type == WebIDLParser.KW_VALUETYPE)
				{
					if(members.ContainsKey(name))
						throw new InvalidOperationException("already defined");
					else
						members.Add(name,new Valuetype(child,owner));
				}
				else if(child.Type == WebIDLParser.KW_CONSTANT)
				{
					if(members.ContainsKey(name))
						throw new InvalidOperationException("already defined");
					else
						members.Add(name,new Constant(child,owner));
				}
				else if(child.Type == WebIDLParser.KW_TYPEDEF)
				{
					if(members.ContainsKey(name))
						throw new InvalidOperationException("already defined");
					else
						members.Add(name,new Typedef(child,owner));
				}
				else
				{
					throw new NotImplementedException();
				}
				
			}
			
			/*if(child.Type == WebIDLLexer.KW_MODULE)
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
				else if(child.Type == WebIDLLexer.KW_VALUETYPE)
				{
					if(!members.ContainsKey(name))
					{
						members.Add(name,new Valuetype(child, this));
					}
					else
					{
						throw new InvalidOperationException("Nombre ya definifo");
					}
				}
				else
				{
					throw new NotImplementedException();
				}*/
		}
	}
}

