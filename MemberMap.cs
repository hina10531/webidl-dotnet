using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public abstract class MemberMap<TMember,TContainer>
	{
		protected Dictionary<string,TMember> members = new Dictionary<string, TMember>();
		protected TContainer owner;
		
		internal MemberMap(TContainer owner)
		{
			this.owner = owner;
		}
		
		public TMember this [string name]
		{
			get
			{
				return members[name];
			}
		}
		
		public IEnumerator<TMember> GetEnumerator()
		{
			return members.Values.GetEnumerator();
		}
		
		internal abstract void append(CommonTree tree);
		
	}
}

