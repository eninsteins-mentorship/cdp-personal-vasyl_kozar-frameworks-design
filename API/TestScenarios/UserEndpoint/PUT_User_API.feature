Feature: PUT_User_API

Background:
	Given I make 'PUT' request to '/users/{id}'
	| Placeholder | Value |
	| id          | 3     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update User using API call	
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'
	And response has fallowing attribute:
	| Attribute | Type   | Value        |
	| name      | string | Till Scwiger |
	
Scenario: 02_Update User without name	
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |
	| name      | null |       |	
	When I send a request
	Then response code is '200'

Scenario: 03_Update User without username
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |
	| username  | null |       |
	When I send a request
	Then response code is '200'

Scenario: 04_Update User without username
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |
	| email     | null |       |
	When I send a request
	Then response code is '200'

Scenario Outline: 05_Update User without Address field
	Given request has body from file 'User\user_update.json'
	| Attribute       | Type   | Value     |
	| address.street  | string | <street>  |
	| address.suite   | string | <suite>   |
	| address.city    | string | <city>    |
	| address.zipcode | string | <zipcode> |
	When I send a request
	Then response code is '200'
	Examples:
	| street      | suite   | city  | zipcode         |
	| null        | Apt. 11 | Paris | 9387482998-3874 |
	| Dark Avenue | null    | Paris | 38748-3874      |
	| Dark Avenue | Apt. 11 | null  | 38748-3874      |
	| Dark Avenue | Apt. 11 | Paris | null            |

Scenario Outline: 06_Update User without Geo field
	Given request has body from file 'User\user_update.json'
	| Attribute | Type   | Value |
	| geo.lat   | string | <lat> |
	| geo.lng   | string | <lng> |
	When I send a request
	Then response code is '200'
	Examples:
	| lat      | lng     |
	| null     | 81.1496 |
	| -37.3159 | null    |

Scenario: 07_Update User without phone
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |
	| phone     | null |       |
	When I send a request
	Then response code is '200'

Scenario: 08_Update User without website
	Given request has body from file 'User\user_update.json'
	| Attribute | Type | Value |
	| website   | null |       |
	When I send a request
	Then response code is '200'

Scenario Outline: 09_Update User without company field
	Given request has body from file 'User\user_update.json'
	| Attribute           | Type   | Value         |
	| company.name        | string | <name>        |
	| company.catchPhrase | string | <catchPhrase> |
	| company.bs          | string | <bs>          |
	When I send a request
	Then response code is '200'
	Examples:
	| name         | catchPhrase                            | bs         |
	| null         | Multi-layered client-server neural-net | e-magazine |
	| Sunny-Garden | null                                   | e-magazine |
	| Sunny-Garden | Multi-layered client-server neural-net | null       |