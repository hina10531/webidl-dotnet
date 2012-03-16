using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Interface : Definition, IType
	{
		internal Interface (CommonTree tree,IContainer parent):base(tree,parent)
		{
		}
	}
}

