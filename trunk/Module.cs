using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Module:Definition,IContainer
	{
		private MemberMap<Definition> members;
		public MemberMap<Definition> Members {get {return members; }}

		internal Module(CommonTree tree, IContainer parent):base(tree,parent)
		{
			members = new Package((CommonTree)tree.GetChild(1),this);
		}
	}
}

