Feature: Principal Management

Scenario: Register a principal
	Given A Principal is defined as:
		| Name   |
		| Hassan |
	When I register the principal
	And I get the principal by Id
	Then I will find the principal

Scenario: Update a user
	Given A User is registerd as:
		| Name   |
		| Hassan |
	When I Update the user to:
		| Name |
		| Ali  |
	And I get the user by Id
	Then I will find the user with updated values

Scenario: Delete a user
	Given A User is registerd as:
		| Name   |
		| Hassan |
	When I Delete the user:
	And I get the user by Id
	Then I will not find the user