# MezoShoppingApi

## Introduction
Thank you for considering this project.

## Getting Started
Mezo Shopping, as I've named it, is a straightforward web API application crafted in the style of Minimal API. It has been developed using .NET 7 with the integration of Entity Framework 7.

### Running The API
- To run the web API, you can use Visual Studio (I utilised VS2022) or VS Code with Kestrel.
- For your convenience and to facilitate this test, I have included a functional SQLite database named "MezoShopping.db" in the repository. However, if you prefer, you can remove it and execute `UPDATE-DATABASE` via the package manager console, to create a fresh one. Some initial data is seeded, but you'll need to post some customer information along with their addresses via the API, if you choose to delete the database.
- I've also included an `.http` file to simplify sending requests with pre-populated data. Alternatively, you can utilize Swagger, which launches in debug mode when you run the solution. Another option is Postman however I haven't exported any requests but should be easy to setup.

## General Thoughts
I chose to build this application using the new Minimal API style, which was a learning opportunity for me. 

I invested time in structuring the application in a layered manner and implemented techniques to reduce repetitive tasks. This includes the use of a generic repository and the mapping of entity objects to DTOs. Additionally, I employed a library called Carter for API endpoint separation, which prevents cluttering the program.cs file with numerous endpoints.

## General Tech Stack
- Minimal API with .NET 7
- Entity Framework 7
- SQLite Database
- Carter (Endpoint Abstraction)
- Mapperly (for object-to-DTO mapping)

## What If...?
If I had more time, I would have likely included a small frontend project as well. My preferred frontend technologies are Vue.js, Bootstrap CSS, SASS, Webpack, or Vite, among other tools. You can find some of my other projects on GitHub if you're interested.

## Closing Thoughts
I want to express my gratitude for the opportunity to work on this test. Admittedly, it took longer than expected, about 4-5 hours, due to my desire to learn something new, like the Minimal API style, and my responsibilities in family life. However, I genuinely enjoyed developing this application and solving the challenges it presented. Once again, thank you for this opportunity.
