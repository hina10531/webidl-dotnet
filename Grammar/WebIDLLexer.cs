//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 /home/juanse/Proyectos/webidl-dotnet/WebIDL.g 2012-03-12 19:23:05

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;

namespace  WebIDL.Grammar 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4")]
[System.CLSCompliant(false)]
public partial class WebIDLLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int CLOSE_BLOCK=4;
	public const int ID=5;
	public const int KW_MODULE=6;
	public const int OPEN_BLOCK=7;
	public const int WS=8;

    // delegates
    // delegators

	public WebIDLLexer()
	{
		OnCreated();
	}

	public WebIDLLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public WebIDLLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "/home/juanse/Proyectos/webidl-dotnet/WebIDL.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void EnterRule_KW_MODULE();
	partial void LeaveRule_KW_MODULE();

	// $ANTLR start "KW_MODULE"
	[GrammarRule("KW_MODULE")]
	private void mKW_MODULE()
	{
		EnterRule_KW_MODULE();
		EnterRule("KW_MODULE", 1);
		TraceIn("KW_MODULE", 1);
		try
		{
			int _type = KW_MODULE;
			int _channel = DefaultTokenChannel;
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:42:2: ( 'module' )
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:42:4: 'module'
			{
			DebugLocation(42, 4);
			Match("module"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("KW_MODULE", 1);
			LeaveRule("KW_MODULE", 1);
			LeaveRule_KW_MODULE();
		}
	}
	// $ANTLR end "KW_MODULE"

	partial void EnterRule_OPEN_BLOCK();
	partial void LeaveRule_OPEN_BLOCK();

	// $ANTLR start "OPEN_BLOCK"
	[GrammarRule("OPEN_BLOCK")]
	private void mOPEN_BLOCK()
	{
		EnterRule_OPEN_BLOCK();
		EnterRule("OPEN_BLOCK", 2);
		TraceIn("OPEN_BLOCK", 2);
		try
		{
			int _type = OPEN_BLOCK;
			int _channel = DefaultTokenChannel;
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:46:2: ( '{' )
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:46:4: '{'
			{
			DebugLocation(46, 4);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OPEN_BLOCK", 2);
			LeaveRule("OPEN_BLOCK", 2);
			LeaveRule_OPEN_BLOCK();
		}
	}
	// $ANTLR end "OPEN_BLOCK"

	partial void EnterRule_CLOSE_BLOCK();
	partial void LeaveRule_CLOSE_BLOCK();

	// $ANTLR start "CLOSE_BLOCK"
	[GrammarRule("CLOSE_BLOCK")]
	private void mCLOSE_BLOCK()
	{
		EnterRule_CLOSE_BLOCK();
		EnterRule("CLOSE_BLOCK", 3);
		TraceIn("CLOSE_BLOCK", 3);
		try
		{
			int _type = CLOSE_BLOCK;
			int _channel = DefaultTokenChannel;
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:48:2: ( '};' )
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:48:4: '};'
			{
			DebugLocation(48, 4);
			Match("};"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CLOSE_BLOCK", 3);
			LeaveRule("CLOSE_BLOCK", 3);
			LeaveRule_CLOSE_BLOCK();
		}
	}
	// $ANTLR end "CLOSE_BLOCK"

	partial void EnterRule_ID();
	partial void LeaveRule_ID();

	// $ANTLR start "ID"
	[GrammarRule("ID")]
	private void mID()
	{
		EnterRule_ID();
		EnterRule("ID", 4);
		TraceIn("ID", 4);
		try
		{
			int _type = ID;
			int _channel = DefaultTokenChannel;
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:51:4: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )* )
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:51:6: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
			{
			DebugLocation(51, 6);
			if ((input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}

			DebugLocation(51, 30);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:51:30: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_0 = input.LA(1);

				if (((LA1_0>='0' && LA1_0<='9')||(LA1_0>='A' && LA1_0<='Z')||LA1_0=='_'||(LA1_0>='a' && LA1_0<='z')))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:
					{
					DebugLocation(51, 30);
					input.Consume();


					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ID", 4);
			LeaveRule("ID", 4);
			LeaveRule_ID();
		}
	}
	// $ANTLR end "ID"

	partial void EnterRule_WS();
	partial void LeaveRule_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		EnterRule_WS();
		EnterRule("WS", 5);
		TraceIn("WS", 5);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:53:4: ( ( ' ' | '\\n' ) )
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:53:6: ( ' ' | '\\n' )
			{
			DebugLocation(53, 6);
			if (input.LA(1)=='\n'||input.LA(1)==' ')
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}

			DebugLocation(53, 17);
			_channel=HIDDEN;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 5);
			LeaveRule("WS", 5);
			LeaveRule_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:8: ( KW_MODULE | OPEN_BLOCK | CLOSE_BLOCK | ID | WS )
		int alt2=5;
		try { DebugEnterDecision(2, false);
		switch (input.LA(1))
		{
		case 'm':
			{
			int LA2_1 = input.LA(2);

			if ((LA2_1=='o'))
			{
				int LA2_6 = input.LA(3);

				if ((LA2_6=='d'))
				{
					int LA2_7 = input.LA(4);

					if ((LA2_7=='u'))
					{
						int LA2_8 = input.LA(5);

						if ((LA2_8=='l'))
						{
							int LA2_9 = input.LA(6);

							if ((LA2_9=='e'))
							{
								int LA2_10 = input.LA(7);

								if (((LA2_10>='0' && LA2_10<='9')||(LA2_10>='A' && LA2_10<='Z')||LA2_10=='_'||(LA2_10>='a' && LA2_10<='z')))
								{
									alt2 = 4;
								}
								else
								{
									alt2 = 1;
								}
							}
							else
							{
								alt2 = 4;
							}
						}
						else
						{
							alt2 = 4;
						}
					}
					else
					{
						alt2 = 4;
					}
				}
				else
				{
					alt2 = 4;
				}
			}
			else
			{
				alt2 = 4;
			}
			}
			break;
		case '{':
			{
			alt2 = 2;
			}
			break;
		case '}':
			{
			alt2 = 3;
			}
			break;
		case 'A':
		case 'B':
		case 'C':
		case 'D':
		case 'E':
		case 'F':
		case 'G':
		case 'H':
		case 'I':
		case 'J':
		case 'K':
		case 'L':
		case 'M':
		case 'N':
		case 'O':
		case 'P':
		case 'Q':
		case 'R':
		case 'S':
		case 'T':
		case 'U':
		case 'V':
		case 'W':
		case 'X':
		case 'Y':
		case 'Z':
		case '_':
		case 'a':
		case 'b':
		case 'c':
		case 'd':
		case 'e':
		case 'f':
		case 'g':
		case 'h':
		case 'i':
		case 'j':
		case 'k':
		case 'l':
		case 'n':
		case 'o':
		case 'p':
		case 'q':
		case 'r':
		case 's':
		case 't':
		case 'u':
		case 'v':
		case 'w':
		case 'x':
		case 'y':
		case 'z':
			{
			alt2 = 4;
			}
			break;
		case '\n':
		case ' ':
			{
			alt2 = 5;
			}
			break;
		default:
			{
				NoViableAltException nvae = new NoViableAltException("", 2, 0, input);
				DebugRecognitionException(nvae);
				throw nvae;
			}
		}

		} finally { DebugExitDecision(2); }
		switch (alt2)
		{
		case 1:
			DebugEnterAlt(1);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:10: KW_MODULE
			{
			DebugLocation(1, 10);
			mKW_MODULE(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:20: OPEN_BLOCK
			{
			DebugLocation(1, 20);
			mOPEN_BLOCK(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:31: CLOSE_BLOCK
			{
			DebugLocation(1, 31);
			mCLOSE_BLOCK(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:43: ID
			{
			DebugLocation(1, 43);
			mID(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// /home/juanse/Proyectos/webidl-dotnet/WebIDL.g:1:46: WS
			{
			DebugLocation(1, 46);
			mWS(); 

			}
			break;

		}

	}


	#region DFA

	protected override void InitDFAs()
	{
		base.InitDFAs();
	}

 
	#endregion

}

} // namespace  WebIDL.Grammar 
