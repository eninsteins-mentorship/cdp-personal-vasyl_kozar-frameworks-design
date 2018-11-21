Feature: PUT_Todo_API

Background:
	Given I make 'PUT' request to '/todos/{id}'
	| Placeholder | Value |
	| id          | 3     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update Todo using API call	
	Given request has body from file 'Todo\todo_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'

Scenario: 02_Update Todo without user Id	
	Given request has body from file 'Todo\todo_update.json'
	| Attribute | Type | Value |
	| userId    | null |       |
	When I send a request
	Then response code is '200'

Scenario: 03_Update Todo without title
	Given request has body from file 'Todo\todo_update.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '200'

Scenario Outline: 04_Update Todo with completed values
	Given request has body from file 'Todo\todo_update.json'
	| Attribute | Type   | Value       |
	| completed | string | <completed> |
	When I send a request
	Then response code is '200'
	Examples:
	| completed |
	| true      |
	| false     |
	| null      |