Feature: POST_Post_API

Background:
	Given I make 'POST' request to '/posts'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create Post using API call	
	Given request has body from file 'Post\post_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'

Scenario: 02_Try to create Post with existed Id	
	Given request has body from file 'Post\post_create.json'
	| Attribute | Type   | Value |
	| id        | string | 3     |
	When I send a request
	Then response code is '500'
	And response contains the fallowing message:
	| Message                     |
	| Insert failed, duplicate id |

Scenario: 03_Create Post without user Id	
	Given request has body from file 'Post\post_create.json'
	| Attribute | Type | Value |
	| userId    | null |       |
	When I send a request
	Then response code is '201'

Scenario: 04_Create Post without title
	Given request has body from file 'Post\post_create.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '201'

Scenario: 05_Create Post without body
	Given request has body from file 'Post\post_create.json'
	| Attribute | Type | Value |
	| body      | null |       |
	When I send a request
	Then response code is '201'