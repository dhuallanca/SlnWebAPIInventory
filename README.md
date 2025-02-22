# NetCoreCleanArchitecture
Template for Clean Architecture

https://www.c-sharpcorner.com/article/how-to-build-a-clean-architecture-web-api-with-net-core-8/

https://medium.com/@codebob75/entity-framework-core-code-first-introduction-best-practices-repository-pattern-clean-22b6152bcb81

https://developer.auth0.com/resources/code-samples/api/aspnet-core/basic-role-based-access-control

https://medium.com/@madu.sharadika/clean-architecture-in-net-8-web-api-483979161c80


https://dev.to/karenpayneoregon/gentle-introduction-to-generic-repository-pattern-with-c-1jn0

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


troubleshooting issues:
Add EFCore.Design to webAPI to run migrations (issue with default project)
Add TrustServerCertificate=True to connection string
Add app.UseExceptionHandler(_ => { }); into program to use new IexceptionHandler