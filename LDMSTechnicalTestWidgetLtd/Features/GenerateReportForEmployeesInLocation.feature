Feature: Generate Report For Employees In Location
As a Widget Ltd user
I want to be able create employee data
So I Can generate a report

Scenario Outline: A valid location returns a list of Employees in report
	Given Widget Ltd have a record of their departments
		And Widget Ltd have a record of their employees
	When a report is generated with '<location>'
	Then the report contains employees for that location

	Examples:
		| location  |
		| London    |
		| Cardiff   |
		| Edinburgh |
		| Belfast   |

Scenario: An invalid location no Employees in report
	Given Widget Ltd have a record of their departments
		And Widget Ltd have a record of their employees
	When a report is generated with 'invalid'
	Then the report does not contain for that location