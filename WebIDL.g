grammar WebIDL;

options {
  output=AST;
  language=CSharp3;
}
@parser::namespace { WebIDL.Grammar }
@lexer::namespace { WebIDL.Grammar }

public fileDef
	:	moduleDef* EOF -> moduleDef*;


moduleDef
	:	KW_MODULE ID moduleContent -> ^(KW_MODULE ID moduleContent);
	
moduleContent
	:	OPEN_BLOCK  CLOSE_BLOCK -> ^(OPEN_BLOCK)*;


KW_MODULE
	:	'module';


OPEN_BLOCK
	:	'{';
CLOSE_BLOCK
	:	'};';


ID	:	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;

WS	:	(' '|'\n') {$channel=HIDDEN;};
