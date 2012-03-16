using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Valuetype : Definition
	{
		private readonly IType type;
		
		public IType ValuedType 
		{
			get
			{
				return this.type;
			}
		}
		
		internal Valuetype (CommonTree tree,IContainer parent):base(tree,parent)
		{
			this.type = (IType) parent.Members[tree.Children[1].Text];
		}
	}
}

