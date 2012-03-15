using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using System.Collections.ObjectModel;

namespace WebIDL
{
	public class Enumerate : Definition
	{
		public ReadOnlyCollection<string> Values;
		internal Enumerate (CommonTree tree,IContainer parent):base(tree,parent)
		{
			var aux = new List<string>();
			foreach(var child in (tree.Children[1] as CommonTree).Children)
				aux.Add(child.Text.Substring(1,child.Text.Length - 2));
			Values = aux.AsReadOnly();
		}
	}
}

