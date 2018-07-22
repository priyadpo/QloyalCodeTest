Feature: phptravel_UserFacility
	As a PHPTRAVELS site user	
	I want to be able to book hotels, flights or tours of my choice


@UI
Scenario: Search for hotels of my choice and view details
	Given I am in the PHPTRAVELS site as a new user
	When I choose to book a hotel of my choice as HotelName:"Rendezvous Hotel" StartDate:"17/09/2019" EndDate:"18/09/2019" NumberOfAdults:"2" NumberOfChildren:"0"
	And I click on search
	Then I reach the details page of the Rendezvous hotel and view the available room details 
	

	
