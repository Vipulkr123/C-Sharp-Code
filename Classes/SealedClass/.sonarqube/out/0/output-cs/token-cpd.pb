�3
>C:\Users\vipul\source\repos\SealedClass\SealedClass\Program.cs
	namespace 	
SealedClass
 
{ 
public 

class 
Employee 
{ 
	protected 
int 
Eid 
, 
Eage 
;  
	protected 
string 
Ename 
, 
Eaddress  (
;( )
public 
virtual 
void 
GetEmployeeData +
(+ ,
), -
{		 	
Console

 
.

 
	WriteLine

 
(

 
$str

 7
)

7 8
;

8 9
Console 
. 
Write 
( 
$str .
). /
;/ 0
Eid 
= 
int 
. 
Parse 
( 
Console #
.# $
ReadLine$ ,
(, -
)- .
). /
;/ 0
Console
.
Write
(
$str
)
;
Ename 
= 
Console 
. 
ReadLine $
($ %
)% &
;& '
Console 
. 
Write 
( 
$str 3
)3 4
;4 5
Eaddress 
= 
Console 
. 
ReadLine '
(' (
)( )
;) *
Console 
. 
Write 
( 
$str /
)/ 0
;0 1
Eage 
= 
int 
. 
Parse 
( 
Console $
.$ %
ReadLine% -
(- .
). /
)/ 0
;0 1
} 	
public 
virtual 
void 
DisplayEmployeeData /
(/ 0
)0 1
{ 	
Console 
. 
	WriteLine 
( 
$str 7
)7 8
;8 9
Console 
. 
	WriteLine 
( 
$"  
$str  -
{- .
Eid. 1
}1 2
"2 3
)3 4
;4 5
Console 
. 
	WriteLine 
( 
$"  
$str  /
{/ 0
Ename0 5
}5 6
"6 7
)7 8
;8 9
Console 
. 
	WriteLine 
( 
$"  
$str  2
{2 3
Eaddress3 ;
}; <
"< =
)= >
;> ?
Console 
. 
	WriteLine 
( 
$"  
$str  .
{. /
Eage/ 3
}3 4
"4 5
)5 6
;6 7
} 	
} 
public 

sealed 
class 
Manager 
:  !
Employee" *
{ 
double   
Bonus   
,   
Salary   
;   
public!! 
override!! 
void!! 
GetEmployeeData!! ,
(!!, -
)!!- .
{"" 	
Console## 
.## 
	WriteLine## 
(## 
$str## 6
)##6 7
;##7 8
Console$$ 
.$$ 
Write$$ 
($$ 
$str$$ -
)$$- .
;$$. /
Eid%% 
=%% 
int%% 
.%% 
Parse%% 
(%% 
Console%% #
.%%# $
ReadLine%%$ ,
(%%, -
)%%- .
)%%. /
;%%/ 0
Console&& 
.&& 
Write&& 
(&& 
$str&& /
)&&/ 0
;&&0 1
Ename'' 
='' 
Console'' 
.'' 
ReadLine'' $
(''$ %
)''% &
;''& '
Console(( 
.(( 
Write(( 
((( 
$str(( 1
)((1 2
;((2 3
Salary)) 
=)) 
Convert)) 
.)) 
ToDouble)) %
())% &
Console))& -
.))- .
ReadLine)). 6
())6 7
)))7 8
)))8 9
;))9 :
Console** 
.** 
Write** 
(** 
$str** 0
)**0 1
;**1 2
Bonus++ 
=++ 
double++ 
.++ 
Parse++  
(++  !
Console++! (
.++( )
ReadLine++) 1
(++1 2
)++2 3
)++3 4
;++4 5
},, 	
public-- 
override-- 
void-- 
DisplayEmployeeData-- 0
(--0 1
)--1 2
{.. 	
Console// 
.// 
	WriteLine// 
(// 
$str// 6
)//6 7
;//7 8
Console00 
.00 
	WriteLine00 
(00 
$"00  
$str00  ,
{00, -
Eid00- 0
}000 1
"001 2
)002 3
;003 4
Console11 
.11 
	WriteLine11 
(11 
$"11  
$str11  .
{11. /
Ename11/ 4
}114 5
"115 6
)116 7
;117 8
Console22 
.22 
	WriteLine22 
(22 
$"22  
$str22  0
{220 1
Salary221 7
}227 8
"228 9
)229 :
;22: ;
Console33 
.33 
	WriteLine33 
(33 
$"33  
$str33  /
{33/ 0
Bonus330 5
}335 6
"336 7
)337 8
;338 9
}44 	
}55 
class<< 	
Program<<
 
{== 
static>> 
void>> 
Main>> 
(>> 
string>> 
[>>  
]>>  !
args>>" &
)>>& '
{?? 	
Manager@@ 
m1@@ 
=@@ 
new@@ 
Manager@@ $
(@@$ %
)@@% &
;@@& '
m1AA 
.AA 
GetEmployeeDataAA 
(AA 
)AA  
;AA  !
m1BB 
.BB 
DisplayEmployeeDataBB "
(BB" #
)BB# $
;BB$ %
ConsoleCC 
.CC 
ReadKeyCC 
(CC 
)CC 
;CC 
}DD 	
}EE 
}FF 