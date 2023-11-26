Feature: Sort First Name

  Scenario: Sort customers by first name
    Given I am on the banking website
    When I select "Login as Bank Manager" option
    Then I click "Customers" to see a list of customers
    When I click the "First Name"
    Then I should see the sorted list by DESC
    When I click the "First Name"
    Then I should see the sorted list by ASC
    #Then I should see an error message
    Then I should close Chrome