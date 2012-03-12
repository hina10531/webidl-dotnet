/*

This file is part of webidl-dotnet.

webidl-dotnet is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using Antlr.Runtime.Tree;

namespace WebIDL
{
	public class Module : Definition, IDefinible
	{
		private string name;
		private IContainer container;
		
		public string Name
		{
			get
			{
				return this.name;
			}
		}
		
		public IContainer Container
		{
			get
			{
				return this.container;
			}
		}
		
		internal Module(CommonTree tree, IContainer container) :base((CommonTree)tree.Children[1])
		{
			this.name = tree.Children[0].Text;
			this.container = container;
		}
	}
}

