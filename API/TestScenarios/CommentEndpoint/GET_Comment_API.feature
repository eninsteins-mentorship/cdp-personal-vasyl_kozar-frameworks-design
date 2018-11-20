Feature: GET_Comment_API

Scenario: 01_Get Comment by Id using API
	Given I make 'GET' request to '/comments/{id}'
	| Placeholder | Value |
	| id          | 9     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Try to get Comment using not exist Id
	Given I make 'GET' request to '/comments/{id}'
	| Placeholder | Value  |
	| id          | 500000 |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'

Scenario: 03_Get list of comments using API
	Given I make 'GET' request to '/comments'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'