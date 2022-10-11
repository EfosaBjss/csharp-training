Feature: Login

In order to use the application to book flights, I should be able to login

@SmokeTest
Scenario: Log in to the Application
	Given I navigate to the adactin website
	And I enter my username and password
	When I click on the login button
	Then I should see the hotel search page