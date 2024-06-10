„H
RC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos\Program.cs
	namespace 	*
TechChallenge_ControleContatos
 (
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
var 
builder 
= 
WebApplication (
.( )
CreateBuilder) 6
(6 7
args7 ;
); <
;< =
var 
configuration 
= 
new  # 
ConfigurationBuilder$ 8
(8 9
)9 :
. 
AddJsonFile 
( 
$str /
)/ 0
. 
Build 
( 
) 
; 
var 
key 
= 
Encoding 
. 
ASCII $
.$ %
GetBytes% -
(- .
configuration. ;
.; <
GetValue< D
<D E
stringE K
>K L
(L M
$strM X
)X Y
)Y Z
;Z [
builder 
. 
Services 
. 
AddAuthentication .
(. /
x/ 0
=>1 3
{ 
x 
. %
DefaultAuthenticateScheme +
=, -
JwtBearerDefaults. ?
.? @ 
AuthenticationScheme@ T
;T U
x 
. "
DefaultChallengeScheme (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
;Q R
}   
)   
.!! 
AddJwtBearer!! 
(!! 
x!! 
=>!! 
{"" 
x## 
.##  
RequireHttpsMetadata## &
=##' (
false##) .
;##. /
x$$ 
.$$ 
	SaveToken$$ 
=$$ 
true$$ "
;$$" #
x%% 
.%% %
TokenValidationParameters%% +
=%%, -
new%%. 1%
TokenValidationParameters%%2 K
(%%K L
)%%L M
{&& $
ValidateIssuerSigningKey'' ,
=''- .
true''/ 3
,''3 4
IssuerSigningKey(( $
=((% &
new((' * 
SymmetricSecurityKey((+ ?
(((? @
key((@ C
)((C D
,((D E
ValidateIssuer)) "
=))# $
false))% *
,))* +
ValidateAudience** $
=**% &
false**' ,
}++ 
;++ 
},, 
),, 
;,, 
builder.. 
... 
Services.. 
... 
AddControllers.. +
(..+ ,
).., -
;..- .
builder11 
.11 
Services11 
.11 #
AddEndpointsApiExplorer11 4
(114 5
)115 6
;116 7
builder22 
.22 
Services22 
.22 
AddSwaggerGen22 *
(22* +
c22+ ,
=>22- /
{33 
c44 
.44 

SwaggerDoc44 
(44 
$str44 !
,44! "
new44# &
OpenApiInfo44' 2
{443 4
Title445 :
=44; <
$str44= S
,44S T
Version44U \
=44] ^
$str44_ c
}44d e
)44e f
;44f g
var66 
xmlFile66 
=66 
$"66  
{66  !
Assembly66! )
.66) * 
GetExecutingAssembly66* >
(66> ?
)66? @
.66@ A
GetName66A H
(66H I
)66I J
.66J K
Name66K O
}66O P
$str66P T
"66T U
;66U V
var77 
xmlPath77 
=77 
Path77 "
.77" #
Combine77# *
(77* +

AppContext77+ 5
.775 6
BaseDirectory776 C
,77C D
xmlFile77E L
)77L M
;77M N
c99 
.99 
IncludeXmlComments99 $
(99$ %
xmlPath99% ,
)99, -
;99- .
c;; 
.;; !
AddSecurityDefinition;; '
(;;' (
$str;;( 0
,;;0 1
new;;2 5!
OpenApiSecurityScheme;;6 K
{<< 
Description== 
===  !
$str>> ]
+>>^ _
$str?? `
+??a b
$str@@ H
,@@H I
NameBB 
=BB 
$strBB *
,BB* +
InCC 
=CC 
ParameterLocationCC *
.CC* +
HeaderCC+ 1
,CC1 2
TypeDD 
=DD 
SecuritySchemeTypeDD -
.DD- .
ApiKeyDD. 4
,DD4 5
SchemeEE 
=EE 
$strEE %
,EE% &
BearerFormatFF  
=FF! "
$strFF# (
,FF( )
}GG 
)GG 
;GG 
cHH 
.HH "
AddSecurityRequirementHH (
(HH( )
newHH) ,&
OpenApiSecurityRequirementHH- G
{II 
{JJ 
newKK !
OpenApiSecuritySchemeKK 1
{LL 
	ReferenceMM %
=MM& '
newMM( +
OpenApiReferenceMM, <
{NN 
TypeOO  $
=OO% &
ReferenceTypeOO' 4
.OO4 5
SecuritySchemeOO5 C
,OOC D
IdPP  "
=PP# $
$strPP% -
}QQ 
}RR 
,RR 
ArraySS 
.SS 
EmptySS #
<SS# $
stringSS$ *
>SS* +
(SS+ ,
)SS, -
}TT 
}UU 
)UU 
;UU 
}VV 
)VV 
;VV 
varYY 
connectionstringYY  
=YY! "
configurationYY# 0
.YY0 1
GetValueYY1 9
<YY9 :
stringYY: @
>YY@ A
(YYA B
$strYYB \
)YY\ ]
;YY] ^
builderZZ 
.ZZ 
ServicesZZ 
.ZZ 
	AddScopedZZ &
<ZZ& '
IDbConnectionZZ' 4
>ZZ4 5
(ZZ5 6
(ZZ6 7

connectionZZ7 A
)ZZA B
=>ZZC E
newZZF I
NpgsqlConnectionZZJ Z
(ZZZ [
connectionstringZZ[ k
)ZZk l
)ZZl m
;ZZm n
builder\\ 
.\\ 
Services\\ 
.\\ 
	AddScoped\\ &
<\\& '
IContactsService\\' 7
,\\7 8
ContactsService\\9 H
>\\H I
(\\I J
)\\J K
;\\K L
builder]] 
.]] 
Services]] 
.]] 
	AddScoped]] &
<]]& '
IContactsRepository]]' :
,]]: ;
ContactsRepository]]< N
>]]N O
(]]O P
)]]P Q
;]]Q R
builder^^ 
.^^ 
Services^^ 
.^^ 
	AddScoped^^ &
<^^& '
IUsersService^^' 4
,^^4 5
UserService^^6 A
>^^A B
(^^B C
)^^C D
;^^D E
builder__ 
.__ 
Services__ 
.__ 
	AddScoped__ &
<__& '
IUsersRepository__' 7
,__7 8
UsersRepository__9 H
>__H I
(__I J
)__J K
;__K L
builder`` 
.`` 
Services`` 
.`` 
	AddScoped`` &
<``& '
IRegionsRepository``' 9
,``9 :
RegionsRepository``; L
>``L M
(``M N
)``N O
;``O P
builderaa 
.aa 
Servicesaa 
.aa 
	AddScopedaa &
<aa& '
IRegionsServiceaa' 6
,aa6 7
RegionsServiceaa8 F
>aaF G
(aaG H
)aaH I
;aaI J
builderbb 
.bb 
Servicesbb 
.bb 
	AddScopedbb &
<bb& '
ITokenServicebb' 4
,bb4 5
TokenServicebb6 B
>bbB C
(bbC D
)bbD E
;bbE F
vardd 
appdd 
=dd 
builderdd 
.dd 
Builddd #
(dd# $
)dd$ %
;dd% &
ifgg 
(gg 
appgg 
.gg 
Environmentgg 
.gg  
IsDevelopmentgg  -
(gg- .
)gg. /
)gg/ 0
{hh 
appii 
.ii 

UseSwaggerii 
(ii 
)ii  
;ii  !
appjj 
.jj 
UseSwaggerUIjj  
(jj  !
)jj! "
;jj" #
}kk 
appmm 
.mm 
UseHttpsRedirectionmm #
(mm# $
)mm$ %
;mm% &
appoo 
.oo 
UseAuthorizationoo  
(oo  !
)oo! "
;oo" #
apprr 
.rr 
MapControllersrr 
(rr 
)rr  
;rr  !
apptt 
.tt 
Runtt 
(tt 
)tt 
;tt 
}uu 	
}vv 
}ww Ÿ 
[C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos\JWT\TokenService.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
JWT) ,
{ 
public 

class 
TokenService 
: 
ITokenService  -
{ 
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
IUsersService &
_userService' 3
;3 4
public 
TokenService 
( 
IConfiguration *
configuration+ 8
,8 9
IUsersService: G
userServiceH S
)S T
{ 	
_configuration 
= 
configuration *
;* +
_userService 
= 
userService &
;& '
} 	
public 
async 
Task 
< 
string  
>  !
GetToken" *
(* +
UserDto+ 2
user3 7
)7 8
{ 	
var 
userDB 
= 
await 
_userService +
.+ ,
GetUser, 3
(3 4
user4 8
.8 9
Username9 A
,A B
userC G
.G H
PasswordvalueH U
)U V
;V W
if!! 
(!! 
userDB!! 
is!! 
null!! 
||!! !
userDB!!" (
.!!( )
username!!) 1
is!!2 4
null!!5 9
)!!9 :
return"" 
string"" 
."" 
Empty"" #
;""# $
var## 
tokenHandler## 
=## 
new## "#
JwtSecurityTokenHandler### :
(##: ;
)##; <
;##< =
var%% 
key%% 
=%% 
Encoding%% 
.%% 
ASCII%% $
.%%$ %
GetBytes%%% -
(%%- .
_configuration%%. <
.%%< =
GetValue%%= E
<%%E F
string%%F L
>%%L M
(%%M N
$str%%N Y
)%%Y Z
)%%Z [
;%%[ \
var'' 
tokenPropriedades'' !
=''" #
new''$ '#
SecurityTokenDescriptor''( ?
(''? @
)''@ A
{(( 
Subject)) 
=)) 
new)) 
ClaimsIdentity)) ,
()), -
new))- 0
Claim))1 6
[))6 7
]))7 8
{** 
new++ 
Claim++ 
(++ 

ClaimTypes++ (
.++( )
Name++) -
,++- .
user++/ 3
.++3 4
Username++4 <
)++< =
,++= >
new,, 
Claim,, 
(,, 

ClaimTypes,, (
.,,( )
Role,,) -
,,,- .
(,,/ 0
user,,0 4
.,,4 5
Roletype,,5 =
-,,> ?
$num,,@ A
),,A B
.,,B C
ToString,,C K
(,,K L
),,L M
),,M N
,,,N O
}-- 
)-- 
,-- 
Expires// 
=// 
DateTime// "
.//" #
UtcNow//# )
.//) *

AddMinutes//* 4
(//4 5
$num//5 6
)//6 7
,//7 8
SigningCredentials11 "
=11# $
new11% (
SigningCredentials11) ;
(11; <
new22  
SymmetricSecurityKey22 ,
(22, -
key22- 0
)220 1
,221 2
SecurityAlgorithms33 &
.33& '
HmacSha256Signature33' :
)33: ;
}44 
;44 
var66 
token66 
=66 
tokenHandler66 $
.66$ %
CreateToken66% 0
(660 1
tokenPropriedades661 B
)66B C
;66C D
return77 
tokenHandler77 
.77  

WriteToken77  *
(77* +
token77+ 0
)770 1
;771 2
}99 	
}:: 
};; €
\C:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos\JWT\ITokenService.cs
	namespace		 	*
TechChallenge_ControleContatos		
 (
.		( )
JWT		) ,
{

 
public 

	interface 
ITokenService "
{ 
public 
Task 
< 
string 
> 
GetToken  (
(( )
UserDto) 0
users1 6
)6 7
;7 8
} 
} ™
fC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos\Controllers\TokenController.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Controllers) 4
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
TokenController		  
:		! "
ControllerBase		# 1
{

 
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
public 
TokenController 
( 
ITokenService ,
tokenService- 9
)9 :
{ 	
_tokenService 
= 
tokenService (
;( )
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Post) -
(- .
[. /
FromBody/ 7
]7 8
UserDto9 @
userA E
)E F
{ 	
var 
token 
= 
await 
_tokenService +
.+ ,
GetToken, 4
(4 5
user5 9
)9 :
;: ;
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
token+ 0
)0 1
)1 2
{ 
return 
Ok 
( 
token 
)  
;  !
} 
return   
Unauthorized   
(    
)    !
;  ! "
}!! 	
}"" 
}$$ ¥4
mC:\Users\CodeZombie\source\TechChallenge\TechChallenge_ControleContatos\Controllers\ContactsInfoController.cs
	namespace 	*
TechChallenge_ControleContatos
 (
.( )
Controllers) 4
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class "
ContactsInfoController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IContactsService )
	_contacts* 3
;3 4
private 
readonly 
ILogger  
<  !"
ContactsInfoController! 7
>7 8
_logger9 @
;@ A
public "
ContactsInfoController %
(% &
IContactsService& 6
contacts7 ?
,? @
ILoggerA H
<H I"
ContactsInfoControllerI _
>_ `
loggera g
)g h
{ 	
	_contacts 
= 
contacts  
;  !
_logger 
= 
logger 
; 
} 	
[ 	
HttpGet	 
( 
$str !
)! "
]" #
[ 	
	Authorize	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetAllContacts) 7
(7 8
)8 9
{ 	
_logger 
. 
LogInformation "
(" #
$str# I
)I J
;J K
var 
allContacts 
= 
await #
	_contacts$ -
.- .
GetContacts. 9
(9 :
): ;
;; <
_logger   
.   
LogInformation   "
(  " #
$str  # U
)  U V
;  V W
return!! 
Ok!! 
(!! 
allContacts!! !
)!!! "
;!!" #
}## 	
[** 	
HttpGet**	 
(** 
$str** 
)** 
]** 
[++ 	
	Authorize++	 
]++ 
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (

GetContact,,) 3
(,,3 4
int,,4 7
id,,8 :
),,: ;
{-- 	
_logger.. 
... 
LogInformation.. "
(.." #
$str..# I
)..I J
;..J K
var// 
contact// 
=// 
await// 
	_contacts//  )
.//) *
GetContactsById//* 9
(//9 :
id//: <
)//< =
;//= >
_logger00 
.00 
LogInformation00 "
(00" #
$str00# U
)00U V
;00V W
return11 
Ok11 
(11 
contact11 
)11 
;11 
}22 	
[99 	
HttpPost99	 
(99 
$str99 !
)99! "
]99" #
[:: 	
	Authorize::	 
]:: 
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
CreateContacts;;) 7
(;;7 8

ContactDto;;8 B
contact;;C J
);;J K
{<< 	
_logger== 
.== 
LogInformation== "
(==" #
$str==# D
)==D E
;==E F
var>> 
contactCreated>> 
=>>  
await>>! &
	_contacts>>' 0
.>>0 1
CreateContacts>>1 ?
(>>? @
contact>>@ G
)>>G H
;>>H I
if@@ 
(@@ 
contactCreated@@ 
.@@ 
Fullname@@ &
is@@' )
null@@* .
)@@. /
{AA 
_loggerBB 
.BB 
LogErrorBB  
(BB  !
$strBB! C
)BBC D
;BBD E
returnCC 

BadRequestCC !
(CC! "
$strCC" D
)CCD E
;CCE F
}DD 
_loggerFF 
.FF 
LogInformationFF "
(FF" #
$strFF# ?
)FF? @
;FF@ A
returnHH 
OkHH 
(HH 
)HH 
;HH 
}II 	
[PP 	
HttpPutPP	 
(PP 
$strPP  
)PP  !
]PP! "
[QQ 	
	AuthorizeQQ	 
]QQ 
publicRR 
asyncRR 
TaskRR 
<RR 
IActionResultRR '
>RR' (
UpdateContactsRR) 7
(RR7 8
[RR8 9
FromBodyRR9 A
]RRA B

ContactDtoRRC M
contactRRN U
)RRU V
{SS 	
_loggerTT 
.TT 
LogInformationTT "
(TT" #
$strTT# C
)TTC D
;TTD E
varUU 
contactUpdateUU 
=UU 
awaitUU  %
	_contactsUU& /
.UU/ 0
UpdateContactsUU0 >
(UU> ?
contactUU? F
)UUF G
;UUG H
ifWW 
(WW 
contactUpdateWW 
==WW  
nullWW! %
)WW% &
{XX 
_loggerYY 
.YY 
LogErrorYY  
(YY  !
$strYY! ?
)YY? @
;YY@ A
returnZZ 

BadRequestZZ !
(ZZ! "
$strZZ" @
)ZZ@ A
;ZZA B
}[[ 
_logger]] 
.]] 
LogInformation]] "
(]]" #
$str]]# @
)]]@ A
;]]A B
return__ 
Ok__ 
(__ 
)__ 
;__ 
}`` 	
[gg 	

HttpDeletegg	 
(gg 
$strgg #
)gg# $
]gg$ %
[hh 	
	Authorizehh	 
]hh 
publicii 
asyncii 
Taskii 
<ii 
IActionResultii '
>ii' (
DeleteContactsii) 7
(ii7 8
intii8 ;
idii< >
)ii> ?
{jj 	
_loggerkk 
.kk 
LogInformationkk "
(kk" #
$strkk# D
)kkD E
;kkE F
awaitll 
	_contactsll 
.ll 
DeleteContactsll *
(ll* +
idll+ -
)ll- .
;ll. /
_loggermm 
.mm 
LogInformationmm "
(mm" #
$strmm# A
)mmA B
;mmB C
returnnn 
Oknn 
(nn 
$strnn 4
)nn4 5
;nn5 6
}oo 	
}pp 
}qq 