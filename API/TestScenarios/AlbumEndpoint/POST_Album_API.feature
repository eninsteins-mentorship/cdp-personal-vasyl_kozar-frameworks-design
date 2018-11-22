Feature: POST_Album_API

Background:
	Given I make 'POST' request to '/albums'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create Album using API call	
	Given request has body from file 'Album\album_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'
	
Scenario: 02_Create Album without title	
	Given request has body from file 'Album\album_create.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '201'

Scenario: 03_Try to create Album with existed Id	
	Given request has body from file 'Album\album_create.json'
	| Attribute | Type   | Value |
	| id        | string | 3     |
	When I send a request
	Then response code is '500'
	And response contains the fallowing message:
	| Message                     |
	| Insert failed, duplicate id |