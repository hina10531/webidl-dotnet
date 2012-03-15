using System;

namespace WebIDL
{
	public interface IContainer
	{
		MemberMap<Definition> Members { get; }
	}
}

