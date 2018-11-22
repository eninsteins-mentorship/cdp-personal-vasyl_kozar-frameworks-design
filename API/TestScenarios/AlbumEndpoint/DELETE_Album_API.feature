Feature: DELETE_Album_API

Scenario: 01_Delete Album by Id using API
	Given I make 'DELETE' request to '/albums/{id}'
	| Placeholder | Value |
	| id          | 5     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Delete Album using unexisted Id
	Given I make 'DELETE' request to '/albums/{id}'
	| Placeholder | Value  |
	| id          | 500000 |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'