Feature: DELETE_Post_API

Scenario: 01_Delete Post by Id using API
	Given I make 'DELETE' request to '/posts/{id}'
	| Placeholder | Value |
	| id          | 10    |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Delete Post using unexisted Id
	Given I make 'DELETE' request to '/posts/{id}'
	| Placeholder | Value  |
	| id          | 500000 |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'