using System;
using System.IO;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace WebIDL
{
	public class Definition
	{
		public Definition(string sourcetext)
		{
			var tree = createFromString(sourcetext);
		}
		
		private static CommonTree createFromString(string sourcetext)
		{
			var stringstream = new ANTLRStringStream(sourcetext);
			
			var lexer = new Grammar.WebIDLLexer(stringstream);
			
			var tokens = new CommonTokenStream(lexer);
			
			var grammar = new Grammar.WebIDLParser(tokens);
			
			var lolo = (CommonTree) grammar.fileDef().Tree;
			

			return lolo;
			
			
			
		}
	}
		
}

