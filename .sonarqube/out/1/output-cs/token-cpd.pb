Í
kC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\UsersRepository.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Infra) .
.. /

Repository/ 9
{ 
public 

class 
UsersRepository  
:! "
IUsersRepository# 3
{ 
private 
readonly 
IDbConnection &

_dbContext' 1
;1 2
public 
UsersRepository 
( 
IDbConnection ,
	dbContext- 6
)6 7
{ 	

_dbContext 
= 
	dbContext "
;" #
} 	
public 
async 
Task 

CreateUser $
($ %
string% +
userName, 4
,4 5
string6 <
password= E
)E F
{ 	
var 
user 
= 
new 
Users  
{ 
username 
= 
userName #
,# $
passwordvalue 
= 
password  (
} 
; 
await 

_dbContext 
. 
InsertAsync (
(( )
user) -
)- .
;. /
}   	
public"" 
async"" 
Task"" 
<"" 
Users"" 
>""  
GetUser""! (
(""( )
string"") /
userName""0 8
,""8 9
string"": @
password""A I
)""I J
{## 	
return$$ 
await$$ 

_dbContext$$ #
.$$# $$
QueryFirstOrDefaultAsync$$$ <
<$$< =
Users$$= B
>$$B C
($$C D
$str%% ^
,%%^ _
new&& 
{&& 
UserName&& 
=&&  
userName&&! )
,&&) *
Password&&+ 3
=&&4 5
password&&6 >
}&&? @
)&&@ A
;&&A B
}'' 	
}(( 
})) ”
mC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\RegionsRepository.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Infra) .
.. /

Repository/ 9
{ 
public 

class 
RegionsRepository "
:# $
IRegionsRepository% 7
{ 
private 
readonly 
IDbConnection &

_dbContext' 1
;1 2
public 
RegionsRepository  
(  !
IDbConnection! .
	dbContext/ 8
)8 9
{ 	

_dbContext 
= 
	dbContext "
;" #
} 	
public 
async 
Task 
< 
Regions !
>! "
GetRegionByDdd# 1
(1 2
string2 8
ddd9 <
)< =
{ 	
var 
query 
= 
$str @
;@ A
var 

parameters 
= 
new  
{! "
ddd# &
=' (
ddd) ,
}- .
;. /
var 
result 
= 
await 

_dbContext )
.) *

QueryAsync* 4
<4 5
Regions5 <
>< =
(= >
query> C
,C D

parametersE O
)O P
;P Q
return 
result 
? 
. 
FirstOrDefault )
() *
)* +
;+ ,
} 	
} 
}   Ã
lC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\IUsersRepository.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Infra		) .
.		. /

Repository		/ 9
{

 
public 

	interface 
IUsersRepository %
{ 
public 
Task 
< 
Users 
> 
GetUser "
(" #
string# )
userName* 2
,2 3
string4 :
password; C
)C D
;D E
public 
Task 

CreateUser 
( 
string %
userName& .
,. /
string0 6
password7 ?
)? @
;@ A
} 
} °
nC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\IRegionsRepository.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Infra) .
.. /

Repository/ 9
{		 
public

 

	interface

 
IRegionsRepository

 '
{ 
Task 
< 
Regions 
> 
GetRegionByDdd $
($ %
string% +
ddd, /
)/ 0
;0 1
} 
} ª
oC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\IContactsRepository.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Service		) 0
.		0 1
	Interface		1 :
{

 
public 

	interface 
IContactsRepository (
{ 
public 
Task 
< 
IEnumerable 
<  
Contact  '
>' (
>( )
GetContacts* 5
(5 6
)6 7
;7 8
public 
Task 
< 
Contact 
> 
GetContactsById ,
(, -
int- 0
id1 3
)3 4
;4 5
public 
Task 
CreateContacts "
(" #
string# )
name* .
,. /
string0 6
ddi7 :
,: ;
string< B
dddC F
,F G
stringH N
phoneO T
,T U
stringV \
email] b
)b c
;c d
public 
Task 
< 
Contact 
> 
UpdateContacts +
(+ ,
int, /
id0 2
,2 3
string4 :
?: ;
name< @
,@ A
stringB H
?H I
ddiJ M
,M N
stringO U
?U V
dddW Z
,Z [
string\ b
?b c
phoned i
,i j
stringk q
?q r
emails x
)x y
;y z
public 
Task 
DeleteContacts "
(" #
int# &
id' )
)) *
;* +
} 
} 1
nC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Repository\ContactsRepository.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Infra) .
.. /

Repository/ 9
{ 
public 

class 
ContactsRepository #
:$ %
IContactsRepository& 9
{ 
private 
readonly 
IDbConnection &

_dbContext' 1
;1 2
private 
readonly 
IUsersRepository )
_userRepository* 9
;9 :
public 
ContactsRepository !
(! "
IDbConnection" /
	dbContext0 9
,9 :
IUsersRepository; K
userRepositoryL Z
)Z [
{ 	

_dbContext 
= 
	dbContext "
;" #
_userRepository 
= 
userRepository ,
;, -
} 	
public 
async 
Task 
CreateContacts (
(( )
string) /
name0 4
,4 5
string6 <
ddi= @
,@ A
stringB H
dddI L
,L M
stringN T
phoneU Z
,Z [
string\ b
emailc h
)h i
{ 	
var 
contact 
= 
new 
Contact %
{ 
fullname   
=   
name   
,    
ddi!! 
=!! 
ddi!! 
,!! 
ddd"" 
="" 
ddd"" 
,"" 
phonenumber## 
=## 
phone## #
,### $
email$$ 
=$$ 
email$$ 
}%% 
;%% 
await'' 

_dbContext'' 
.'' 
InsertAsync'' (
(''( )
contact'') 0
)''0 1
;''1 2
}(( 	
public** 
async** 
Task** 
DeleteContacts** (
(**( )
int**) ,
id**- /
)**/ 0
{++ 	
var,, 
contact,, 
=,, 
await,, 

_dbContext,,  *
.,,* +
GetAsync,,+ 3
<,,3 4
Contact,,4 ;
>,,; <
(,,< =
id,,= ?
),,? @
;,,@ A
if-- 
(-- 
contact-- 
!=-- 
null-- 
)--  
await.. 

_dbContext..  
...  !
DeleteAsync..! ,
(.., -
contact..- 4
)..4 5
;..5 6
}// 	
public11 
async11 
Task11 
<11 
IEnumerable11 %
<11% &
Contact11& -
>11- .
>11. /
GetContacts110 ;
(11; <
)11< =
{22 	
var33 
query33 
=33 
$str33 D
;33D E
return55 
await55 

_dbContext55 #
.55# $

QueryAsync55$ .
<55. /
Contact55/ 6
>556 7
(557 8
query558 =
)55= >
;55> ?
}66 	
public88 
async88 
Task88 
<88 
Contact88 !
?88! "
>88" #
GetContactsById88$ 3
(883 4
int884 7
id888 :
)88: ;
{99 	
var:: 
query:: 
=:: 
$str:: S
;::S T
var<< 

parameters<< 
=<< 
new<<  
{<<! "
Id<<# %
=<<& '
id<<( *
}<<+ ,
;<<, -
var>> 
result>> 
=>> 
await>> 

_dbContext>> )
.>>) *

QueryAsync>>* 4
<>>4 5
Contact>>5 <
>>>< =
(>>= >
query>>> C
,>>C D

parameters>>E O
)>>O P
;>>P Q
return@@ 
result@@ 
?@@ 
.@@ 
FirstOrDefault@@ )
(@@) *
)@@* +
;@@+ ,
}AA 	
publicCC 
asyncCC 
TaskCC 
<CC 
ContactCC !
>CC! "
UpdateContactsCC# 1
(CC1 2
intCC2 5
idCC6 8
,CC8 9
stringCC: @
?CC@ A
nameCCB F
,CCF G
stringCCH N
?CCN O
ddiCCP S
,CCS T
stringCCU [
?CC[ \
dddCC] `
,CC` a
stringCCb h
?CCh i
phoneCCj o
,CCo p
stringCCq w
?CCw x
emailCCy ~
)CC~ 
{DD 	
varEE 
contactEE 
=EE 
awaitEE 

_dbContextEE  *
.EE* +
GetAsyncEE+ 3
<EE3 4
ContactEE4 ;
>EE; <
(EE< =
idEE= ?
)EE? @
;EE@ A
ifFF 
(FF 
contactFF 
!=FF 
nullFF 
)FF  
{GG 
contactHH 
.HH 
fullnameHH  
=HH! "
nameHH# '
??HH( *
contactHH+ 2
.HH2 3
fullnameHH3 ;
;HH; <
contactII 
.II 
ddiII 
=II 
ddiII !
??II" $
contactII% ,
.II, -
ddiII- 0
;II0 1
contactJJ 
.JJ 
dddJJ 
=JJ 
dddJJ !
??JJ" $
contactJJ% ,
.JJ, -
dddJJ- 0
;JJ0 1
contactKK 
.KK 
phonenumberKK #
=KK$ %
phoneKK& +
??KK, .
contactKK/ 6
.KK6 7
phonenumberKK7 B
;KKB C
contactLL 
.LL 
emailLL 
=LL 
emailLL  %
??LL& (
contactLL) 0
.LL0 1
emailLL1 6
;LL6 7
awaitNN 

_dbContextNN  
.NN  !
UpdateAsyncNN! ,
(NN, -
contactNN- 4
)NN4 5
;NN5 6
returnPP 
contactPP 
;PP 
}QQ 
returnSS 
contactSS 
;SS 
}UU 	
}VV 
}WW Æ
]C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Entity\Users.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Infra		) .
.		. /
Entity		/ 5
{

 
public 

class 
Users 
{ 
public 
int 
id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
passwordvalue #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

RolesTypes 
roletype "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
public 

enum 

RolesTypes 
{ 
Admin 
, 
Employee 
} 
public 

static 
class 
Roles 
{ 
public 
const 
string 
Admin !
=" #
$str$ 3
;3 4
public 
const 
string 
NotAdmin $
=% &
$str' 1
;1 2
} 
} Ÿ
_C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Entity\Regions.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Infra		) .
.		. /
Entity		/ 5
{

 
public 

class 
Regions 
{ 
public 
int 
id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
ddd 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
region 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ‹
_C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Infra\Entity\Contact.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Infra		) .
.		. /
Mapping		/ 6
{

 
public 

class 
Contact 
{ 
public 
int 
id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
fullname 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
ddi 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
ddd 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
phonenumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
region 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} 