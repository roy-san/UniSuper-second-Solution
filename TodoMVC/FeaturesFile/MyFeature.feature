Feature: MyFeature

 Scenario:  Test To-Do feature 
    Given I am on the angular page 
	When I want to add a To-do item
    And I want to edit the content of an existing To-do item
    And I can complete a To-do by clicking inside the circle UI to the left of the To-do
    And I can re-activate a completed To-do by clicking inside the circle UI
	And I can add a second To-do
	And I can complete all active To-dos by clicking the down arrow at the top-left of the UI
	And I can filter the visible To-dos by Completed state
	And I can clear a single To-do item from the list completely by clicking the Close icon
	And I can clear all completed To-do items from the list completely