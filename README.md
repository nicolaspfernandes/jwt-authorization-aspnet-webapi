## JWT Authorization ASP.NET WebApi

Simple application in order to show how to use JWT to control authorization flow into WebApi applications.
The authorization token is created based on a given role. It is sent to the requests through Authorization header attribute.

The ActionFilter will check the headers in order to find an Authorization attribute with value and check it against the verification logic.
If the request is denied, the response will send a **403 (Forbidden)** status back to the user.

## Testing the application

- Requests for creating tokens: *http://localhost:11111/tokens/* (You'll need to send an integer value that represents the role enum value)
- Requests with specific permissions: *http://localhost:11111/requests/{anonymous|common|superuser|administrator}*. Add the token as a header attribute with 'Authorization' name.

1. Open Postman collection under *Extra/Postman* folder in order to run the requests against the WebApi project.    
2. Run requests manually against the browser the requests to see the results.

##Built with

- .NET framework 4.5.2
- Visual Studio 2015 Express
- JUnit for Test Cases [here] (https://github.com/nicolaspfernandes/nunit)
- Implementation of JWT for .NET [here] (https://github.com/nicolaspfernandes/jwt)
