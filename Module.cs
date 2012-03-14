using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Module:Container,IDefinition
	{
		public readonly Container Parent;
		public string Name
		{
			get
			{
				return this.name;
			}
		}
		private string name;
		
		internal Module(CommonTree tree, Container parent):base((CommonTree)tree.Children[1])
		{
			this.Parent = parent;
			this.name = tree.Children[0].Text;
		}
	}
}

