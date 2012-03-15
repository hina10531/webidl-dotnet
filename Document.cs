using System;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using WebIDL.Grammar;

namespace WebIDL
{
	public class Document : IContainer
	{
		private Package members;
		public Package Members {get {return members; }}
		
		public Document(string sourcetext)
		{
			var stringstream = new ANTLRStringStream(sourcetext);
		
			var lexer = new WebIDLLexer(stringstream);
			
			var tokens = new CommonTokenStream(lexer);
			
			var grammar = new WebIDLParser(tokens);
		
			this.members = new Package((CommonTree)grammar.documentDef().Tree, this);
		}
	}
}

