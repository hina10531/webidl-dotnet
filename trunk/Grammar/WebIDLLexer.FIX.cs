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

using Antlr.Runtime;


namespace  WebIDL.Grammar 
{
	public partial class WebIDLLexer : Antlr.Runtime.Lexer
	{
		//The generator in a expected to use a constant part 
		//which was never declared. This fixed it.
		private static int HIDDEN = TokenChannels.Hidden;
		
	}
}
