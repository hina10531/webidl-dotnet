using System;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using WebIDL.Grammar;

namespace WebIDL
{
	public class Document:Container
	{
		public Document(string sourcetext):base(parse(sourcetext))
		{
			
		}
		
		private static CommonTree parse(string sourcetext)
		{
			var stringstream = new ANTLRStringStream(sourcetext);
		
			var lexer = new WebIDLLexer(stringstream);
			
			var tokens = new CommonTokenStream(lexer);
			
			var grammar = new WebIDLParser(tokens);
		
			return (CommonTree)grammar.documentDef().Tree;
		}
	}
}

