Feature: 001-RestaurantTill

Scenario: 001-Validate till calculates total cost with no starters
	Given I have the following order reciept
	| Starters | Mains |
	| 0        | 4     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 28.0  |

Scenario: 002-Validate till calculates total cost with no mains
	Given I have the following order reciept
	| Starters | Mains |
	| 4        | 0     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 17.6  |

Scenario: 003-Validate till calculates total cost with both starters and mains
	Given I have the following order reciept
	| Starters | Mains |
	| 4        | 6     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 59.6  |

Scenario: 004-Validate till calculates total cost with no starters and no mains
	Given I have the following order reciept
	| Starters | Mains |
	| 0        | 0     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 0     |

## Alternative way of running the above tests is to use the Specflow Scenario Outline
Scenario Outline: 005-Validate till calculates total cost
	Given I have <starters> starter courses and <mains> main courses
	When I am at the checkout
	Then the calculated total cost will be <total>
	Examples: 
	| starters | mains | total |
	| 0        | 4     | 28.0  |
	| 4        | 0     | 17.6  |
	| 4        | 6     | 59.6  |
	| 0        | 0     | 0     |

Scenario: 006-Validate till calculates total cost when updated to remove starters
	Given I have the following order reciept
	| Starters | Mains |
	| 2        | 2     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 22.8  |
	When I update to remove 2 starters
	Then the new total cost will be 14

Scenario: 007-Validate till calculates total cost when updated to remove mains
	Given I have the following order reciept
	| Starters | Mains |
	| 2        | 2     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 22.8  |
	When I update to remove 2 mains
	Then the new total cost will be 8.8

Scenario: 008-Validate till calculates total cost when updated to add starters
	Given I have the following order reciept
	| Starters | Mains |
	| 2        | 2     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 22.8  |
	When I update to add 1 starters
	Then the new total cost will be 27.2

Scenario: 009-Validate till calculates total cost when updated to add mains
	Given I have the following order reciept
	| Starters | Mains |
	| 2        | 2     |
	When I am at the checkout
	Then I can calculate the total cost
	| Total |
	| 22.8  |
	When I update to add 1 mains
	Then the new total cost will be 29.8
