using System;
using Antlr.Runtime.Tree;
using System.Collections.Generic;

namespace WebIDL.Grammar
{
	public abstract class Package
	{
		
		//FOO 
		public class Definition
		{
			public readonly string Name;
			public Definition(CommonTree tree, Package container)
			{
				this.Name = tree.Children[0].Text;
			}
		}
		
		
		public class Interface : Definition
		{
			public Interface(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
	
		public class Constant : Definition
		{
			public Constant(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Valuetype : Definition
		{
			public Valuetype(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Enumeration : Definition
		{
			public Enumeration(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Typedef : Definition
		{
			public Typedef(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Exception : Definition
		{
			public Exception(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Callback : Definition
		{
			public Callback(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		public class Module : Definition
		{
			internal Package childs;
			
			public Module(CommonTree tree, Package container):base(tree, container)
			{
				throw new NotImplementedException();
			}
		}
		
		
		private Dictionary<string,Definition> members = new Dictionary<string,Definition>();
		
		public IEnumerable<Definition> Members
		{
			get
			{
				foreach(var member in members)
					yield return member.Value;
			}
		}
		
		private Package(CommonTree tree)
		{
			append(tree);
		}
		
		internal void append(CommonTree tree)
		{
			
			if(tree.Children == null)
				return;
			
			foreach(var child in (List<CommonTree>)tree.Children)
			{
				var name = child.GetChild(0).Text;
				
				if(child.Type == WebIDLLexer.KW_MODULE)
				{
					//IF NOT EXISTS
					if(!members.ContainsKey(name))
					{
						//CREATE IT
						members.Add(name, new Module(child, this));
					}
					else if(members[name] is Module)
					{
						//IF EXISTS EXTEND IT
						((Module) members[name]).childs.append(child);
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
				}
			}
		}
	}
}

