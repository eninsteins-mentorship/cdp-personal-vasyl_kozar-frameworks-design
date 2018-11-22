Feature: PUT_Comment_API

Background:
	Given I make 'PUT' request to '/comments/{id}'
	| Placeholder | Value |
	| id          | 3     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update Comment using API call	
	Given request has body from file 'Comment\commet_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'

Scenario: 02_Update Comment without name	
	Given request has body from file 'Comment\commet_update.json'
	| Attribute | Type | Value |
	| name      | null |       |
	When I send a request
	Then response code is '200'

Scenario: 03_Update Comment without email	
	Given request has body from file 'Comment\commet_update.json'
	| Attribute | Type | Value |
	| email     | null |       |
	When I send a request
	Then response code is '200'

Scenario: 04_Update Comment without body	
	Given request has body from file 'Comment\commet_update.json'
	| Attribute | Type | Value |
	| body      | null |       |
	When I send a request
	Then response code is '200'
