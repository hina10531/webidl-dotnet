grammar WebIDL;

options {
  output=AST;
  language=CSharp3;
}
@parser::namespace { WebIDL.Grammar }
@lexer::namespace { WebIDL.Grammar }

//GRAMMAR

public documentDef 
	:	(declaration)*
		EOF
	-> ^(EOF declaration*);

declaration
	:	  moduleDef
		| interfaceDef
		| interfacePredef
		| constantDef 
		| exceptionDef
		| typedefDef
		| valuetypeDef
		| enumDef
		| callbackDef
		| dictionaryDef;

interfaceMember
	:	  constantDef
		| attributeDef;

exceptionMember
	:	constantDef;

moduleDef
	:	KW_MODULE
		ID
		BLOCK
		declaration*
		CLOSE_BLOCK
	-> ^(KW_MODULE ID ^(BLOCK declaration*));

interfaceDef
	:	KW_CALLBACK?
		KW_PARTIAL?
		KW_INTERFACE
		ID
		BLOCK
		interfaceMember*
		CLOSE_BLOCK
	->	^(KW_INTERFACE ID ^(BLOCK interfaceMember*) KW_PARTIAL? KW_CALLBACK?);

interfacePredef
	:	KW_INTERFACE
		ID
		END_STMT
	->	^(KW_INTERFACE ID);

enumDef
	:	KW_ENUM
		ID
		BLOCK
		enumMembers
		CLOSE_BLOCK
	->	^(KW_ENUM ID ^(BLOCK enumMembers));

dictionaryDef
	:	KW_DICTIONARY
		ID
		BLOCK
		CLOSE_BLOCK
	->	^(KW_DICTIONARY ID);

enumMembers
	:	STRING (',' STRING)* -> STRING*;


constantDef
	:	KW_CONSTANT
		ID
		END_STMT
	-> ^(KW_CONSTANT ID);

typedefDef
	:	KW_TYPEDEF
		ID
		END_STMT
	-> ^(KW_TYPEDEF ID);

attributeDef
	:	KW_READONLY?
		KW_ATTRIBUTE
		ID
		END_STMT
	-> ^(KW_ATTRIBUTE ID KW_READONLY?);

valuetypeDef
	:	KW_VALUETYPE
		ID
		typeReference
		END_STMT
	-> ^(KW_VALUETYPE ID typeReference);

callbackDef
	:	KW_CALLBACK
		ID
		END_STMT
	-> ^(KW_CALLBACK ID);

exceptionDef
	:	KW_EXCEPTION
		ID
		BLOCK
		exceptionMember*
		CLOSE_BLOCK
	-> ^(KW_EXCEPTION ID ^(BLOCK exceptionMember*));

typeReference
	:	ID;


//CONTROL KEYWORDS
KW_MODULE		:	'module';
KW_INTERFACE	:	'interface';
KW_CONSTANT		:	'const';
KW_EXCEPTION	:	'exception';
KW_TYPEDEF		:	'typedef';
KW_VALUETYPE	:	'valuetype';
KW_ENUM			:	'enum';
KW_CALLBACK		:	'callback';
KW_ATTRIBUTE	:	'attribute';
KW_DICTIONARY	:	'dictionary';

//MODIFIERS
KW_PARTIAL		:	'partial';
KW_READONLY		:	'readonly';

//FLUSH CONTROL
BLOCK		:	'{';
CLOSE_BLOCK	:	'};';
END_STMT	:	';';	

//COMMON
ID			:	'_'?('a'..'z'|'A'..'Z')('a'..'z'|'A'..'Z'|'_'|'0'..'9')*;

WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {$channel=HIDDEN;}
    ;

// IST TRUE!!! 
STRING
    :  '"' ~('"')* '"'
    ;

//COMMENTS
COMMENT
    :   '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    |   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;
