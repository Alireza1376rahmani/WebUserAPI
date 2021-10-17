Feature: user Management

Scenario: Register a user
	Given A user is defined as:
		| Name  |
		| rUser |
	When I register the user
	And I get the user by Id
	Then I will find the user

Scenario: Update a user
	Given A user is registered as:
		| Name  |
		| uUser |
	When I Update the user to:
		| Name        |
		| updatedUser |
	And I get the user by Id
	Then I will find the user with updated values

Scenario: Delete a user
	Given A user is registered as:
		| Name  |
		| dUser |
	When I Delete the user
	And I get the user by Id
	Then I will not find the user

Scenario: Register a User with groups
	Given A Group is registered as:
		| Name      |
		| hisGroups |
	And A user is defined as:
		| Name   |
		| cUser |
	When I register the user with registered group as default
	And I get the user by Id
	Then I will find the user with the group

Scenario: a User joins to a group
	Given A Group is registered as:
		| Name   |
		| jGroup |
	And 	A user is registered as:
		| Name  |
		| jUser |
	When I join the user to the group
	And I get the user by Id
	Then I will find the user with the group

Scenario: a User leaves a group
	Given A Group is registered as:
		| Name   |
		| LGroup |
	And 	A user is registered as:
		| Name  |
		| LUser |
	And the user is in group
	When I leave the user from group
	And I get the user by Id
	Then I will not find the group in groups of user