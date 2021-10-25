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
		| Name  |
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

Scenario: a User assigns his party
	Given A Party is registered as:
		| Type       | Name   | LastName | NationalNumber |
		| individual | Assign | sample   | 1230099905     |
	And 	A user is registered as:
		| Name  |
		| AUser |
	When I assign the party to the user
	And I get the user by Id
	Then I will find the user with the party

Scenario: Register a User with a Party
	Given A Party is registered as:
		| Type       | Name     | LastName | NationalNumber |
		| individual | Register | sample   | 9099301030     |
	And A user is defined as:
		| Name  |
		| RUser |
	When I register the user with registered party as default
	And I get the user by Id
	Then I will find the user with the party

