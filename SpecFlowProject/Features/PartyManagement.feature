Feature: PartyManagement
	Simple Definition for file

Scenario: Create a party
	Given A party is defined as :
		| Type     | Name   | LastName | NationalNumber |
		| business | CParty | Buddy    | 1              |
	When I register the party
	And I get the party by Id
	Then I will find the party

Scenario: Delete a party
	Given A Party is registered as:
		| Type     | Name   | LastName | NationalNumber |
		| business | DParty | Buddy    | 2              |
	When I delete the party
	And I get the party by Id
	Then I will not find the party

Scenario: Update a party
	Given A Party is registered as:
		| Type     | Name   | LastName | NationalNumber |
		| business | DParty | Buddy    | 2              |
	When I Update party's name to "another name"
	And I get the party by Id
	Then I will find the party with updated name