using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using System.Collections.ObjectModel;

namespace WebIDL
{
	public class Enumerate : Definition
	{
		public class RepeatValueException : System.Exception
		{
			public RepeatValueException(string enumname, string enumvalue):base("Value +" + enumvalue + " already exists in enum " + enumname)
			{
			}
		}
		
		public ReadOnlyCollection<string> Values;
		internal Enumerate (CommonTree tree,IContainer parent):base(tree,parent)
		{
			var aux = new List<string>();
			foreach(var child in (tree.Children[1] as CommonTree).Children)
			{
				var item = child.Text.Substring(1,child.Text.Length - 2);
				if(aux.Contains(item))
					throw new RepeatValueException(this.Name,item);
				aux.Add(item);
			}
			Values = aux.AsReadOnly();
		}
	}
}

