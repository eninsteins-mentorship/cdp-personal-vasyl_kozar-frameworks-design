Feature: PUT_Album_API

Background:
	Given I make 'PUT' request to '/albums/{id}'
	| Placeholder | Value |
	| id          | 5     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update Album using API call	
	Given request has body from file 'Album\album_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'
	
Scenario: 02_Update Album without title	
	Given request has body from file 'Album\album_update.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '200'