using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public abstract class MemberMap<T>
	{
		protected Dictionary<string,T> members = new Dictionary<string, T>();
		protected IContainer owner;
		
		internal MemberMap(CommonTree tree, IContainer owner)
		{
			this.owner = owner;
			this.append(tree);
		}
		
		public T this [string name]
		{
			get
			{
				return members[name];
			}
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return members.Values.GetEnumerator();
		}
		
		internal abstract void append(CommonTree tree);
		
	}
}

