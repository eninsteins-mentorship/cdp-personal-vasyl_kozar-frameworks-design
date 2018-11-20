Feature: GET_Photo_API

Scenario: 01_Get Photo by Id using API
	Given I make 'GET' request to '/photos/{id}'
	| Placeholder | Value |
	| id          | 12    |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Try to get Photo using not exist Id
	Given I make 'GET' request to '/photos/{id}'
	| Placeholder | Value |
	| id          | 50000 |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'

Scenario: 03_Get list of photos using API
	Given I make 'GET' request to '/photos'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'