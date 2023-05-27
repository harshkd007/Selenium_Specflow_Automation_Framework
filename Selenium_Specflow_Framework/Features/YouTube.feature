Feature: Youtube

Youtube workflow automation

@tag1
Scenario: Search Ch. Shivaji Maharaj on youtube
	Given Open the chrome browser
	When I enter the URL
	When search 'Ch shivaji Maharaj' on youtube
	Then I verify the title 'Ch shivaji Maharaj'
