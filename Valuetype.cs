using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Valuetype: IDefinible
	{
		private string name;
		public Valuetype(CommonTree tree, IContainer container) 
		{
			this.name = tree.Children[0].Text;
		}
		
		public string Name
		{
			get
			{
				return name;
			}
		}
	}
}

