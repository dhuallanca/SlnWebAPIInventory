# NetCoreCleanArchitecture
Template for Clean Architecture

https://www.c-sharpcorner.com/article/how-to-build-a-clean-architecture-web-api-with-net-core-8/

https://medium.com/@codebob75/entity-framework-core-code-first-introduction-best-practices-repository-pattern-clean-22b6152bcb81

https://developer.auth0.com/resources/code-samples/api/aspnet-core/basic-role-based-access-control

https://medium.com/@madu.sharadika/clean-architecture-in-net-8-web-api-483979161c80


https://dev.to/karenpayneoregon/gentle-introduction-to-generic-repository-pattern-with-c-1jn0

https://medium.com/@mohanedzekry/clean-architecture-in-asp-net-core-web-api-d44e33893e1d

Domain> Entities: Models, Validations, Errors
Application: use Cases, singIng, CRUD, Infraestucture Interfaces
Infaestructure: Repositories, shared service(Authentication, email).

Identity tables:
https://www.linkedin.com/pulse/database-structure-user-role-management-aj-february/

Result patter: https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern
https://www.youtube.com/watch?v=5emVIkthkDg
https://www.youtube.com/watch?v=WCCkEe_Hy2Y
https://www.youtube.com/watch?v=uOEDM0c9BNI

new global exception:
https://dev.to/muhammad_salem/comprehensive-guide-to-error-handling-in-aspnet-core-329
https://www.youtube.com/watch?v=uOEDM0c9BNI

Hybrid IexceptionHandler + Result Pattern
https://dev.to/k_ribaric/net-error-handling-balancing-exceptions-and-the-result-pattern-ljo

CQRS pattern:
https://www.csharp.com/article/building-robust-asp-net-core-web-apis-with-cqrs-and-mediatr/
https://www.csharp.com/article/cqrs-and-mediatr-pattern-implementation-using-net-core-6-web-api/
https://codewithmukesh.com/blog/cqrs-and-mediatr-in-aspnet-core/

troubleshooting issues:
Add EFCore.Design to webAPI to run migrations (issue with default project)
Add TrustServerCertificate=True to connection string
Add app.UseExceptionHandler(_ => { }); into program to use new IexceptionHandler

Add injection for HTttpContextAccessor services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

encrypt: https://code-maze.com/csharp-hashing-salting-passwords-best-practices/


https://weblogs.asp.net/ricardoperes/accessing-the-httpcontext-from-a-dbcontext

Creation CurrentCancellationTokenService to inject cancellation token


get user id:
https://fiseni.com/posts/current-user-aspnetcore/

Jwtoken:

https://medium.com/@madu.sharadika/authentication-and-authorization-in-net-web-api-with-jwt-b46ef2f54e31

https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication?view=aspnetcore-9.0

https://medium.com/@sajadshafi/jwt-authentication-in-c-net-core-7-web-api-b825b3aee11d

https://curity.io/resources/learn/dotnet-api/

https://github.com/patrickgod/JwtWebApiDotNet7/blob/master/JwtWebApiDotNet7/appsettings.json

Unit of work:
https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

https://www.youtube.com/watch?v=7nM7E-c7vYw