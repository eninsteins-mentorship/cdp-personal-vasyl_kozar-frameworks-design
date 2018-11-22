Feature: POST_Photo_API

Background:
	Given I make 'POST' request to '/photos'
	| Placeholder | Value |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Create Photo using API call	
	Given request has body from file 'Photo\photo_create.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '201'

Scenario: 02_Create Photo without title	
	Given request has body from file 'Photo\photo_create.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '201'

Scenario: 03_Create Photo without url	
	Given request has body from file 'Photo\photo_create.json'
	| Attribute | Type | Value |
	| url       | null |       |
	When I send a request
	Then response code is '201'

Scenario: 04_Create Photo without thumbnailUrl	
	Given request has body from file 'Photo\photo_create.json'
	| Attribute    | Type | Value |
	| thumbnailUrl | null |       |
	When I send a request
	Then response code is '201'

Scenario: 05_Try to create Photo with existed Id	
	Given request has body from file 'Photo\photo_create.json'
	| Attribute | Type   | Value |
	| id        | string | 3     |
	When I send a request
	Then response code is '500'
	And response contains the fallowing message:
	| Message                     |
	| Insert failed, duplicate id |