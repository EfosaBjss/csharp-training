Feature: SearchHotel

In order to book a hotel, I should perform a seach

@tag1
Scenario: As a customer, I should be able to search for a hotel
	Given I am already logged into the application
	When I enter the below search credentials
	| field             | values         |
	| Location          | London         |
	| Hotels            | Hotel Sunshine |
	| RoomType          | Double         |
	| NumberOfRooms     | 1 - One        |
	| CheckInDate       | 20/10/2022     |
	| CheckOutDate      | 30/10/2022     |
	| AdultsPerRoom     | 2 - Two        |
	| ChildrenPerRoom   | 0 - None       |
	And I click on the Search button
	Then the select hotel page should return
	And the button "Book Itenary" displayed at the top of the page
