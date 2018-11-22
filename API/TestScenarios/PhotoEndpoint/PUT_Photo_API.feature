Feature: PUT_Photo_API

Background:
	Given I make 'PUT' request to '/photos/{id}'
	| Placeholder | Value |
	| id          | 3     |
	And request contains headers
	| Placeholder  | Value            |
	| Content-Type | application/json |

Scenario: 01_Update Photo using API call	
	Given request has body from file 'Photo\photo_update.json'
	| Attribute | Type | Value |	
	When I send a request
	Then response code is '200'

Scenario: 02_Update Photo without title	
	Given request has body from file 'Photo\photo_update.json'
	| Attribute | Type | Value |
	| title     | null |       |
	When I send a request
	Then response code is '200'

Scenario: 03_Update Photo without url	
	Given request has body from file 'Photo\photo_update.json'
	| Attribute | Type | Value |
	| url       | null |       |
	When I send a request
	Then response code is '200'

Scenario: 04_Update Photo without thumbnailUrl	
	Given request has body from file 'Photo\photo_update.json'
	| Attribute    | Type | Value |
	| thumbnailUrl | null |       |
	When I send a request
	Then response code is '200'