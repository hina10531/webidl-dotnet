grammar WebIDL;

options
{
	output=AST;
    language=CSharp3;
}

@parser::namespace { WebIDL.Grammar }
@lexer::namespace { WebIDL.Grammar }


public definition:
	module* EOF;

module
	:	KW_MODULE ID BLOCK_OPEN module_member* BLOCK_CLOSE;
	
module_member:
	module;

KW_MODULE
	:	'module';
	
BLOCK_OPEN
	:	'{';
BLOCK_CLOSE
	:	'};';
	
ID	:	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9')*;

WS	:	(' '|'\n'|'\t') {$channel=HIDDEN;};



