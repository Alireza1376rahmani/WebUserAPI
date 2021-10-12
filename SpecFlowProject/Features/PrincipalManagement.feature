Feature: Principal Management

Scenario: Register a User
	Given A User is defined as:
		| Name   | Groups |
		| Hassan |        |
	When I register the User
	And I get the User by Id
	Then I will find the User

Scenario: Register a User with groupes
	Given A Group is registered as:
		| Name   | Groups |
		| Group1 |        |
	And A User is defined as:
		| Name   | Groups |
		| Hassan | Group1 |    
	When I register the User
	And I get the User by Id
	Then I will find the User

Scenario: Update a User
	Given A User is registered as:
		| Name   | Groups |
		| Hassan |        |
	When I Update the User to:
		| Name | Groups |
		| Ali  |        |
	And I get the User by Id
	Then I will find the User with updated values

Scenario: Delete a user
	Given A User is registered as:
		| Name   | Groups |
		| Hassan |        |
	When I Delete the User
	And I get the User by Id
	Then I will not find the User
