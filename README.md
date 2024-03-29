# README

## General information
### Prerequisites
- installed docker
- installed Visual Studio Code (preferably) with C#
 - if VS Code is chosen, make sure the following extensions are installed:
  - Nuget Package Manager
  - .NET Test Explorer

### Instructions on how to perform a setup of the website itself
- perform a docker pull using the following command...
> docker pull wethinkcode/weshare-qa:2022
- then run the image using the following command...
> docker run -p 5050:5050 -d wethinkcode/weshare-qa:2022

### Instructions on how to set up the framework properly
- clone this repository into any folder
- open the solution in (preferably) Visual Studio Code
- in the terminal, navigate to the root folder of the cloned project and perform a restore to download all necessary packages using the following command...
> dotnet restore
- then build the project, and run the tests...
> dotnet build
> dotnet test
- NOTE: for a list of all the tests available, perform the following command...
> dotnet test -t

### Notes
- note that the data gets refreshed every time you re-run your docker container, except the data that is fixed

## Filestructure
- CoreLibrary
  - API -> contains classes with methods relevant to each endpoint
  - Extras -> contains classes with extensional functionalities to the base functions of Selenium and etc.
  - Models -> contains classes with the base models used when deserializing API requests, and the DTO (Data Transfer Object) versions of those same models used when performing POST requests 
  - Pages -> contains classes that act as Page Object Models, with all methods relevant to the page they're executed on
  - Setup -> contains the main setup and teardown functionalities of the testing framework
- WeShareTests
  - API -> contains all API tests
  - UI -> contains all UI tests


