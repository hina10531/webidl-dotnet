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