Feature: GET_Todo_API

Scenario: 01_Get Todo by Id using API
	Given I make 'GET' request to '/todos/{id}'
	| Placeholder | Value |
	| id          | 11    |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Try to get Todo using not exist Id
	Given I make 'GET' request to '/todos/{id}'
	| Placeholder | Value |
	| id          | 5000  |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'

Scenario: 03_Get list of todos using API
	Given I make 'GET' request to '/todos'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'