Ù
fC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Service\UserService.cs
	namespace

 	*
TechChallenge_ControleContatos


 (
.

( )
Service

) 0
.

0 1
Service

1 8
{ 
public 

class 
UserService 
: 
IUsersService ,
{ 
public 
readonly 
IUsersRepository (
_usersRepository) 9
;9 :
public 
UserService 
( 
IUsersRepository +
usersRepository, ;
); <
{ 	
_usersRepository 
= 
usersRepository .
;. /
} 	
public 
async 
Task 

CreateUser $
($ %
string% +
userName, 4
,4 5
string6 <
password= E
,E F
stringG M
roleN R
)R S
{ 	
await 
_usersRepository "
." #

CreateUser# -
(- .
userName. 6
,6 7
password8 @
)@ A
;A B
} 	
public 
async 
Task 
< 
Users 
>  
GetUser! (
(( )
string) /
userName0 8
,8 9
string: @
passwordA I
)I J
{ 	
return 
await 
_usersRepository )
.) *
GetUser* 1
(1 2
userName2 :
,: ;
password< D
)D E
;E F
} 	
} 
} „	
iC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Service\RegionsService.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Service) 0
.0 1
Service1 8
{ 
public 

class 
RegionsService 
:  !
IRegionsService" 1
{ 
private 
readonly 
IRegionsRepository +
_regions, 4
;4 5
public 
RegionsService 
( 
IRegionsRepository 0
regions1 8
)8 9
{ 	
_regions 
= 
regions 
; 
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
{ 	
return 
await 
_regions !
.! "
GetRegionByDdd" 0
(0 1
ddd1 4
)4 5
;5 6
} 	
} 
} á%
jC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Service\ContactsService.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Service) 0
.0 1
Service1 8
{ 
public 

class 
ContactsService  
:! "
IContactsService# 3
{ 
private 
readonly 
IContactsRepository ,
_contactsRepository- @
;@ A
private 
readonly 
IRegionsRepository +
_regions, 4
;4 5
public 
ContactsService 
( 
IContactsRepository 2
contactsRepository3 E
,E F
IRegionsRepositoryG Y
regionsZ a
)a b
{ 	
_contactsRepository 
=  !
contactsRepository" 4
;4 5
_regions 
= 
regions 
; 
} 	
public 
async 
Task 
< 

ContactDto $
>$ %
CreateContacts& 4
(4 5

ContactDto5 ?
contacts@ H
)H I
{ 	
var 
regions 
= 
await 
_regions  (
.( )
GetRegionByDdd) 7
(7 8
contacts8 @
.@ A
DddA D
)D E
;E F
if 
( 
regions 
is 
null 
)  
return 
new 

ContactDto %
(% &
)& '
;' (
await!! 
_contactsRepository!! %
.!!% &
CreateContacts!!& 4
(!!4 5
contacts!!5 =
.!!= >
Fullname!!> F
,!!F G
contacts!!H P
.!!P Q
Ddi!!Q T
,!!T U
contacts!!V ^
.!!^ _
Ddd!!_ b
,!!b c
contacts!!d l
.!!l m
Phonenumber!!m x
,!!y z
contacts	!!z ‚
.
!!‚ ƒ
Email
!!ƒ ˆ
)
!!ˆ ‰
;
!!‰ Š
return## 
contacts## 
;## 
}$$ 	
public&& 
async&& 
Task&& 
DeleteContacts&& (
(&&( )
int&&) ,
Id&&- /
)&&/ 0
{'' 	
await(( 
_contactsRepository(( %
.((% &
DeleteContacts((& 4
(((4 5
Id((5 7
)((7 8
;((8 9
})) 	
public++ 
async++ 
Task++ 
<++ 
IEnumerable++ %
<++% &
Contact++& -
>++- .
>++. /
GetContacts++0 ;
(++; <
)++< =
{,, 	
IEnumerable-- 
<-- 
Contact-- 
>--  
contacts--! )
=--* +
await--, 1
_contactsRepository--2 E
.--E F
GetContacts--F Q
(--Q R
)--R S
;--S T
return.. 
contacts.. 
... 
OrderBy.. #
(..# $
x..$ %
=>..& (
x..) *
...* +
id..+ -
)..- .
.// 

DistinctBy// &
(//& '
x//' (
=>//) +
x//, -
.//- .
fullname//. 6
)//6 7
;//7 8
}00 	
public22 
async22 
Task22 
<22 
Contact22 !
>22! "
GetContactsById22# 2
(222 3
int223 6
id227 9
)229 :
{33 	
return44 
await44 
_contactsRepository44 ,
.44, -
GetContactsById44- <
(44< =
id44= ?
)44? @
;44@ A
}55 	
public77 
async77 
Task77 
<77 
Contact77 !
>77! "
UpdateContacts77# 1
(771 2

ContactDto772 <
contacts77= E
)77E F
{88 	
var99 
contactUpdated99 
=99  
await99! &
_contactsRepository99' :
.99: ;
UpdateContacts99; I
(99I J
contacts99J R
.99R S
Id99S U
,99U V
contacts99W _
.99_ `
Fullname99` h
,99h i
contacts99j r
.99r s
Ddi99s v
,99v w
contacts	99x €
.
99€ 
Ddd
99 „
,
99„ …
contacts
99† Ž
.
99Ž 
Phonenumber
99 š
,
99š ›
contacts
99œ ¤
.
99¤ ¥
Email
99¥ ª
)
99ª «
;
99« ¬
return;; 
contactUpdated;; !
;;;! "
}<< 	
}== 
}>> ô
jC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Interface\IUsersService.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Service) 0
.0 1
	Interface1 :
{		 
public

 

	interface

 
IUsersService

 "
{ 
public 
Task 
< 
Users 
> 
GetUser "
(" #
string# )
userName* 2
,2 3
string4 :
password; C
)C D
;D E
public 
Task 

CreateUser 
( 
string %
userName& .
,. /
string0 6
password7 ?
,? @
stringA G
roleH L
)L M
;M N
} 
} ¬
lC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Interface\IRegionsService.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Service) 0
.0 1
	Interface1 :
{		 
public

 

	interface

 
IRegionsService

 $
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
} Æ

mC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\Interface\IContactsService.cs
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
IContactsService %
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
Task 
< 

ContactDto 
> 
CreateContacts  .
(. /

ContactDto/ 9
contact: A
)A B
;B C
public 
Task 
< 
Contact 
> 
UpdateContacts +
(+ ,

ContactDto, 6
contact7 >
)> ?
;? @
public 
Task 
DeleteContacts "
(" #
int# &
id' )
)) *
;* +
} 
} »
^C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\DTO\UserDto.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
Service		) 0
.		0 1
DTO		1 4
{

 
public 

class 
UserDto 
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! C
)C D
]D E
[ 	
	MaxLength	 
( 
$num 
, 
ErrorMessage #
=$ %
$str& ]
)] ^
]^ _
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 9
)9 :
]: ;
[ 	
	MinLength	 
( 
$num 
, 
ErrorMessage "
=# $
$str% P
)P Q
]Q R
public 
string 
Passwordvalue #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
( 
ErrorMessage 
=  
$str! B
)B C
]C D
public 

RolesTypes 
Roletype "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} é
aC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos.Service\DTO\ContactDto.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Service) 0
.0 1
DTO1 4
{		 
public

 

class

 

ContactDto

 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
Required	 
( 
ErrorMessage 
=  
$str! A
)A B
]B C
[ 	
	MaxLength	 
( 
$num 
, 
ErrorMessage $
=% &
$str' ]
)] ^
]^ _
public 
string 
? 
Fullname 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
StringLength	 
( 
$num 
, 
MinimumLength &
=' (
$num) *
,* +
ErrorMessage, 8
=9 :
$str; c
)c d
]d e
public 
string 
? 
Ddi 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
StringLength	 
( 
$num 
, 
MinimumLength &
=' (
$num) *
,* +
ErrorMessage, 8
=9 :
$str; c
)c d
]d e
public 
string 
? 
Ddd 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! F
)F G
]G H
[ 	
	MaxLength	 
( 
$num 
, 
ErrorMessage "
=# $
$str% ^
)^ _
]_ `
public 
string 
? 
Phonenumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[   	
Required  	 
(   
ErrorMessage   
=    
$str  ! :
)  : ;
]  ; <
[!! 	
EmailAddress!!	 
(!! 
ErrorMessage!! "
=!!# $
$str!!% N
)!!N O
]!!O P
public"" 
string"" 
?"" 
Email"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
}## 
}$$ 