Feature: POST_Comment_API

Background:
	Given I make 'POST' request to '/comments'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create Comment using API call	
	Given request has body from file 'Comment\comment_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'

Scenario: 02_Create Comment without name	
	Given request has body from file 'Comment\comment_create.json'
	| Attribute | Type | Value |
	| name      | null |       |
	When I send a request
	Then response code is '201'

Scenario: 03_Create Comment without email	
	Given request has body from file 'Comment\comment_create.json'
	| Attribute | Type | Value |
	| email     | null |       |
	When I send a request
	Then response code is '201'

Scenario: 04_Create Comment without body	
	Given request has body from file 'Comment\comment_create.json'
	| Attribute | Type | Value |
	| body      | null |       |
	When I send a request
	Then response code is '201'

Scenario: 05_Try to create Comment with existed Id	
	Given request has body from file 'Comment\comment_create.json'
	| Attribute | Type   | Value |
	| id        | string | 3     |
	When I send a request
	Then response code is '500'
	And response contains the fallowing message:
	| Message                     |
	| Insert failed, duplicate id |