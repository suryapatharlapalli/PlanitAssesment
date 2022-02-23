Feature: Contact
	
Scenario Outline: Submit a Contact
	Given User has navigated to Contact page
	When User fill mandatory fields "<Test Data>"
	And Click Submit button
	Then Verify Contact Message is "Thanks Test, we appreciate your feedback." 
Examples: 
| Test Data |
| Task_01   |
| Task_01   |
| Task_01   |
| Task_01   |
| Task_01   |