Feature: GET_Album_API

Scenario: 01_Get Album by Id using API
	Given I make 'GET' request to '/albums/{id}'
	| Placeholder | Value |
	| id          | 5     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'

Scenario: 02_Try to get Album using not exist Id
	Given I make 'GET' request to '/albums/{id}'
	| Placeholder | Value |
	| id          | 5000  |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '404'

Scenario: 03_Get list of albums using API
	Given I make 'GET' request to '/albums'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |
	When I send a request
	Then response code is '200'