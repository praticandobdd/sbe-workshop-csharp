#language: en
Feature: Estimate lasagna times

* <https://exercism.org/tracks/csharp/exercises/lucians-luscious-lasagna>

# Rule Extractor: 
## Array.from(
##    document.getElementsByClassName("summary-title")
##           ).map(e => e.firstChild)

# Scenario Extractor: 
## Array.from(
##        document.getElementsByClassName("--summary-name")
##            ).map(e => e.firstChild)

Rule: Define the expected oven time in minutes
Scenario: Expected minutes in oven
Then expected minutes in oven should be 40

Rule: Calculate the remaining oven time in minutes
@ignore
Scenario: Remaining minutes in oven after twenty five minutes
Then remaining minutes in oven should be 15 when actual minutes is 25
Scenario: Remaining minutes in oven after thirty three minutes
Then remaining minutes in oven should be 7 when actual minutes is 33

Rule: Calculate the preparation time in minutes
Scenario: Preparation time in minutes for multiple layers
#Then preparation time in minutes should be 4 when added layers is 2
Scenario: Preparation time in minutes for one layer
#Then preparation time in minutes should be 2 when added layers is 1

Rule: Calculate the elapsed time in minutes
Scenario: Elapsed time in minutes for one layer
#Then elapsed time in minutes should be 16 when added layers is 3 and minutes in oven is 10
Scenario: Elapsed time in minutes for multiple layers
#Then elapsed time in minutes should be 11 when added layers is 2 and minutes in oven is 7
