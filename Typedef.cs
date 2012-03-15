using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Typedef : Definition
	{
		internal Typedef (CommonTree tree,IContainer parent):base(tree,parent)
		{
		}
	}
}

