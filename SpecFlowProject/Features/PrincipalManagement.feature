Feature: Principal Management

Scenario: Register a principal
	Given A Principal is defined as:
		| Name   |
		| Hassan |
	When I register the principal
	And I get the principal by Id
	Then I will find the principal

Scenario: Update a principal
	Given A principal is registered as:
		| Name   |
		| Hassan |
	When I Update the principal to:
		| Name |
		| Ali  |
	And I get the principal by Id
	Then I will find the principal with updated values

Scenario: Delete a user
	Given A principal is registered as:
		| Name   |
		| Hassan |
	When I Delete the principal
	And I get the principal by Id
	Then I will not find the principal