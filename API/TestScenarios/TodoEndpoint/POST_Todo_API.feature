Feature: POST_Todo_API

Background:
	Given I make 'POST' request to '/todos'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create Todo using API call	
	Given request has body from file 'Todo\todo_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'

Scenario: 02_Try to create Todo with existed Id	
	Given request has body from file 'Todo\todo_create.json'
	| Attribute | Type   | Value |
	| id        | string | 3     |
	When I send a request
	Then response code is '500'
	And response contains the fallowing message:
	| Message                     |
	| Insert failed, duplicate id |

Scenario: 03_Create Todo without user Id	
	Given request has body from file 'Todo\todo_create.json'
	| Attribute | Type | Value |
	| userId    | null |       |
	When I send a request
	Then response code is '201'

Scenario: 04_Create Todo without title
	Given request has body from file 'Todo\todo_create.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '201'

Scenario Outline: 05_Create Todo with completed values
	Given request has body from file 'Todo\todo_create.json'
	| Attribute | Type   | Value       |
	| completed | string | <completed> |
	When I send a request
	Then response code is '201'
	Examples:
	| completed |
	| true      |
	| false     |
	| null      |
