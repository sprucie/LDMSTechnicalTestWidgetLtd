Feature: Generate Report For Employees In Department
As a Widget Ltd user
I want to be able create employee data
So I Can generate a report

Scenario Outline: A valid department id returns a list of Employees in report
	Given Widget Ltd have a record of their departments
		And Widget Ltd have a record of their employees
	When a report is generated with '<departmentId>'
	Then the report contains employees for that department

	Examples:
		| departmentId |
		| 1            |
		| 2            |
		| 3            |
		| 4            |

Scenario: An invalid department id does not return employees in report
	Given Widget Ltd have a record of their departments
		And Widget Ltd have a record of their employees
	When a report is generated with '-1'
	Then the report does not contains employees for that department