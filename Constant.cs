using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Constant : Definition
	{
		internal Constant (CommonTree tree,IContainer parent):base(tree,parent)
		{
		}
	}
}

