Feature: RainfallAPI
  I want to be able to specify a limit and a date with a station onto the request 

  Scenario: Send GET request and verify status is 200
    Given I have the API endpoint
    When I send a GET request to the API with a valid integer for limit
    Then I should receive a response with status 200

  Scenario: Send GET request with an invalid parameter
    Given I have the API endpoint
    When I send a GET request with an invalid parameter
    Then I should receive a response with status 400

  Scenario: Send GET request with limit of 5 and verify the response contains 5 items
    Given I have the API endpoint
    When I send a GET request to the API with a limit of 5
    Then the response should contain 5 items

  Scenario: Send GET request with a specified station parameter
    Given I have the API endpoint
    When I send a GET request to the API with a station specified
    Then I should receive a response with status 200

    Scenario: Send GET request with a specified station parameter and date
    Given I have the API endpoint
    When I send a GET request to the API with a station specified and a date
    Then I should receive a response with status 200

  Scenario: Send GET request with an invalid station parameter
    Given I have the API endpoint
    When I send a GET request to the API with an invalid station specified
    Then I should receive a response with status 404

