Feature: user Management

Scenario: Register a user
	Given A user is defined as:
		| Name   |
		| Hassan |
	When I register the user
	And I get the user by Id
	Then I will find the user

Scenario: Update a user
	Given A user is registered as:
		| Name   |
		| Hassan |
	When I Update the user to:
		| Name |
		| Ali  |
	And I get the user by Id
	Then I will find the user with updated values

Scenario: Delete a user
	Given A user is registered as:
		| Name   |
		| Hassan |
	When I Delete the user
	And I get the user by Id
	Then I will not find the user

Scenario: Register a User with groups
	Given A user with groups is defined as:
		| Name   | Groups |
		| Hassan | Group1 |
	And A Group is registered as:
		| Name   | Groups |
		| Group1 |        |
	When I register the user
	And I get the user by Id
	Then I will find the user with his groups

Scenario: a User joins to a group
	Given A user is registered as:
		| Name  |
		| gholi |
	And A Group is registered as:
		| Name |
		| gp1  |
	When I join the user to the group
	And I get the user by Id
	Then I will find the user with the group

Scenario: a User leaves a group
	Given A user is registered as:
		| Name  |
		| gholi |
	And A Group is registered as:
		| Name |
		| gp1  |
	And the user is in group
	When I leave the user from group
	And I get the user by Id
	Then I will not find the group in groups of user