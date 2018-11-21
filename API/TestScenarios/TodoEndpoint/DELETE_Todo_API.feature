Feature: DELETE_Todo_API

Scenario: 01_Delete Todo by Id using API
	Given I make 'DELETE' request to '/todos/{id}'
	| Placeholder | Value |
	| id          | 10    |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Delete Todo using unexisted Id
	Given I make 'DELETE' request to '/todos/{id}'
	| Placeholder | Value  |
	| id          | 500000 |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'