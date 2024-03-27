Feature: Login

@mytag
Scenario: Successful login with valid credentials
	Given user is at the Login page
	When user enters '<userName>' and '<password>'
	And user clicks the login button
	Then the page should navigate to profile page

Examples: 
| userName   | password |
| testuser_1 | Test@123 |
| testuser   | Test@123 |
| laiba123   |Laiba@123|

Scenario: Failed login when both fields are empty
	Given user is at the Login page
	When user enters '' and ''
	And user clicks the login button
	Then the username field should show error
	And the password field should show error

Scenario: Failed login when username is empty and password is correct
	Given user is at the Login page
	When user enters '' and 'Test@123'
	And user clicks the login button
	Then the username field should show error

Scenario: Failed login when username is correct and password is empty
	Given user is at the Login page
	When user enters 'testuser_1' and ''
	And user clicks the login button
	Then the password field should show error

Scenario: Failed login when username is incorrect and password is correct
	Given user is at the Login page
	When user enters 'laiba' and 'Test@123'
	And user clicks the login button
	Then the page should display an error message

Scenario: Failed login when username is correct and password is incorrect
	Given user is at the Login page
	When user enters 'testuser_1' and 'test123'
	And user clicks the login button
	Then the page should display an error message

Scenario: Failed login when both fields are invalid
	Given user is at the Login page
	When user enters 'laiba' and 'Test123'
	And user clicks the login button
	Then the page should display an error message