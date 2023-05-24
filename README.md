# _Test App CryptoCUR_
### by Kyrychenko Nikita
#

Simple desktop application for give information about cryptocurrency.
## Features
- View top 10 cryptocurrency from API.
- Find cryptocurrency by symbol.
- View detail information: rank (by API), symbol, name, volume, change volume by 24 hour, price USD.
- View top 5 (by API) markets specific cryptocurrency.
- Converting one unit cryptocurrency to another one unit.

#
## Tech
The application was developed in C#, and using only 2 plaguins and one API.
For this API was used only GET requests.
During development, SOLID and MVVM patterns were used.
| API | DOCS |
|-----|------|
|CoinCap|[docs.coincap.io][RAc]|

#
## Plaguins
Only plugins necessary for work were used. Their list is presented below.
| Plaguins | DOCS |
|-----|------|
| Community Toolkits MVVM |[MS Docs website][RPctmvvm]|
| Newtonsoft JSON |[newtonsoft.com/json/help][RPnsjson]|

#
## License
MIT

[RAc]: <https://docs.coincap.io/>
[RPctmvvm]: <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/>
[RPnsjson]: <https://www.newtonsoft.com/json/help/html/Introduction.htm>