using System;
using Antlr.Runtime.Tree;
using System.Collections.Generic;

namespace WebIDL
{
	public class Container
	{
		private readonly DefinitionList members;
		public Container(CommonTree parsetree)
		{
			this.members = new DefinitionList(parsetree, this);
		}
		
		public IEnumerable<IDefinition> Members
		{
			get
			{
				foreach(var member in members.members.Values)
				{
					yield return member;
				}
			}
		}
		
		public IDefinition GetMember(string name)
		{
			return members.members[name];
		}
	}
}

