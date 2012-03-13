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

grammar WebIDL;

options {
  output=AST;
  language=CSharp3;
}
@parser::namespace { WebIDL.Grammar }
@lexer::namespace { WebIDL.Grammar }

public fileDef
	:	(moduleElement)* EOF -> ^(EOF moduleElement*);


moduleDef
	:	KW_MODULE ID moduleContent -> ^(KW_MODULE ID moduleContent);
	
moduleContent
	:	OPEN_BLOCK moduleElement* CLOSE_BLOCK ->  ^(OPEN_BLOCK moduleElement*)*;

moduleElement
	:	moduleDef | valuetypeDef;

valuetypeDef
	:	KW_VALUETYPE ID SEMICOLON -> ^(KW_VALUETYPE ID);


KW_MODULE
	:	'module';

KW_VALUETYPE
	:	'valuetype';


OPEN_BLOCK
	:	'{';
CLOSE_BLOCK
	:	'};';

SEMICOLON
	:	';';

ID	:	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;

COMMENT
    :   '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    |   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {$channel=HIDDEN;}
    ;