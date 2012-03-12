using System;

namespace WebIDL
{
	public interface IContainer
	{
		IDefinible this[string name] { get;}
	}
}

