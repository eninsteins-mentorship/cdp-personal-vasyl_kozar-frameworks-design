Feature: POST_User_API

Scenario: 01_Create User using API call
	Given I make 'POST' request to '/users'
	| Placeholder | Value |
	And request has body from file 'User\user_create.json'
	| Attribute | Type | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '201'
	And response has fallowing attribute:
	| Attribute | Type   | Value          |
	| name      | string | Dastin Hoffman |