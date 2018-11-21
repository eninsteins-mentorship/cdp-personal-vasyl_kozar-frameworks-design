Feature: POST_User_API

Background:
	Given I make 'POST' request to '/users'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create User using API call	
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'
	And response has fallowing attribute:
	| Attribute | Type   | Value          |
	| name      | string | Dastin Hoffman |

Scenario: 02_Create User without name	
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	| name      | null |       |	
	When I send a request
	Then response code is '201'

Scenario: 03_Create User without username
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	| username  | null |       |
	When I send a request
	Then response code is '201'

Scenario: 04_Create User without username
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	| email     | null |       |
	When I send a request
	Then response code is '201'

Scenario Outline: 05_Create User without Address field
	Given request has body from file 'User\user_create.json'
	| Attribute       | Type   | Value     |
	| address.street  | string | <street>  |
	| address.suite   | string | <suite>   |
	| address.city    | string | <city>    |
	| address.zipcode | string | <zipcode> |
	When I send a request
	Then response code is '201'
	Examples:
	| street       | suite   | city   | zipcode    |
	| null         | Apt. 71 | London | 92998-3874 |
	| Light Avenue | null    | London | 92998-3874 |
	| Light Avenue | Apt. 71 | null   | 92998-3874 |
	| Light Avenue | Apt. 71 | London | null       |

Scenario Outline: 06_Create User without Geo field
	Given request has body from file 'User\user_create.json'
	| Attribute | Type   | Value |
	| geo.lat   | string | <lat> |
	| geo.lng   | string | <lng> |
	When I send a request
	Then response code is '201'
	Examples:
	| lat      | lng     |
	| null     | 81.1496 |
	| -37.3159 | null    |

Scenario: 07_Create User without phone
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	| phone     | null |       |
	When I send a request
	Then response code is '201'

Scenario: 08_Create User without website
	Given request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	| website   | null |       |
	When I send a request
	Then response code is '201'

Scenario Outline: 09_Create User without company field
	Given request has body from file 'User\user_create.json'
	| Attribute           | Type   | Value         |
	| company.name        | string | <name>        |
	| company.catchPhrase | string | <catchPhrase> |
	| company.bs          | string | <bs>          |
	When I send a request
	Then response code is '201'
	Examples:
	| name       | catchPhrase                            | bs        |
	| null       | Multi-layered client-server neural-net | e-markets |
	| King-Crown | null                                   | e-markets |
	| King-Crown | Multi-layered client-server neural-net | null      |