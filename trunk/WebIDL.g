grammar WebIDL;

options
{
	output=AST;
    language=CSharp3;
}

@parser::namespace { WebIDL.Grammar }
@lexer::namespace { WebIDL.Grammar }


public definition: EOF;

WS	:	' ' {$channel=HIDDEN;};