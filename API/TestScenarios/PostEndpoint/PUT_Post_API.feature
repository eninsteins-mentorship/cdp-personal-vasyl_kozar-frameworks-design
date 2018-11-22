Feature: PUT_Post_API

Background:
	Given I make 'PUT' request to '/posts/{id}'
	| Placeholder | Value |
	| id          | 5     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update Post using API call	
	Given request has body from file 'Post\post_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'

Scenario: 02_Update Post without user Id	
	Given request has body from file 'Post\post_update.json'
	| Attribute | Type | Value |
	| userId    | null |       |
	When I send a request
	Then response code is '200'

Scenario: 03_Update Post without title
	Given request has body from file 'Post\post_update.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '200'

Scenario: 04_Update Post without body
	Given request has body from file 'Post\post_update.json'
	| Attribute | Type | Value |
	| body      | null |       |
	When I send a request
	Then response code is '200'