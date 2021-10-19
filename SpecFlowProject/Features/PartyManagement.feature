Feature: PartyManagement
	Simple Definition for file

Scenario: Create a party
	Given A party is defined as :
	| Type     | Name    | LastName | NationalNumber |
	| business | Alireza | Rahmani  | 1230055502     |
	When I register the party
	And I get the party by Id
	Then I will find the party