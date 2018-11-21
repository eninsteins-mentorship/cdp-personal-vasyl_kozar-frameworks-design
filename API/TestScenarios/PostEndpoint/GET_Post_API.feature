Feature: GET_Post_API

Scenario: 01_Get Post by Id using API
	Given I make 'GET' request to '/posts/{id}'
	| Placeholder | Value |
	| id          | 15    |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Try to get Post using not exist Id
	Given I make 'GET' request to '/posts/{id}'
	| Placeholder | Value |
	| id          | 5000  |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'

Scenario: 03_Get list of posts using API
	Given I make 'GET' request to '/posts'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'