using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Definition
	{
		private string name;
		public string Name { get { return name; } }
		
		private IContainer parent;
		public IContainer Parent { get {return parent; } }
		
		public Definition(CommonTree tree, IContainer parent)
		{
			this.parent = parent;
			this.name = tree.GetChild(0).Text;
		}
	}
}

