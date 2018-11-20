Feature: GET_User_API

Background: 
	Given I make 'GET' request to '/users/{id}'
	| Placeholder | Value |
	| id          | 5     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Get User by Id using API
	When I send a request
	Then response code is '200'

