using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Module:Definition,IContainer
	{
		private Package members;
		public Package Members {get {return members; }}

		internal Module(CommonTree tree, IContainer parent):base(tree,parent)
		{
			members = new Package(this);
			members.append((CommonTree)tree.GetChild(1));
		}
	}
}

