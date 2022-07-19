

# A pragmatic, [Agile](https://en.wikipedia.org/wiki/Agile_software_development)-minded [SOA](https://en.wikipedia.org/wiki/Service-oriented_architecture) Intranet Web Application Template

![NetworkLayer](assets/diagrams/NetworkLayer.png)

This is an *opinionated* intranet Line-of-business web application intranet template, great for **small to medium**-scale web applications with maintainability in mind and flexibility to grow.
  
  ## Agile Development Manifesto
  - **Individuals and interactions** over processes and tools
  - **Working software** over comprehensive documentation
  - **Customer collaboration** over contract negotiation
  - **Responding to change** over following a plan

## Service-Oriented Architecture Manifesto
  - **Business value** is given more importance than technical strategy.
  - **Strategic goals** are given more importance than project-specific benefits.
  - **Intrinsic interoperability** is given more importance than custom integration.
  - **Shared services** are given more importance than specific-purpose implementations.
  - **Flexibility** is given more importance than optimization.
  - **Evolutionary refinement** is given more importance than pursuit of initial perfection.

  *That is, while there is value in the items on the right, **we value the items on the left more.***

# Features
- Blazor Server
- Azure AD Authentication using the Microsoft Identity Platform 
- Microsoft Identity Platform 

## Planned Features
- Microsoft Identify Platform - Authorization 
    - [MS Doc](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/azure-active-directory-groups-and-roles?view=aspnetcore-6.0) 
    - [how to assign user to roles](https://docs.microsoft.com/en-us/azure/active-directory/manage-apps/add-application-portal-assign-users)) (note: app registration to manage app, enteprise application to manage user assignments )
    - https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-add-app-roles-in-azure-ad-apps
    - https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/app-roles#roles-using-azure-ad-app-roles
    - https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/README.md
    - https://docs.microsoft.com/en-us/azure/security/fundamentals/identity-management-best-practices
## How-To Wishlist

- How to re-create this project from scratch 
    1. Creating Blazor App
        - .NET 6
        - Server
        - Auth - Microsoft Identity Platform
            - Add new Azure AD application right in the wizard 
    2. Adding AppOptions
    3. Adding Services via Core class library
    4. Adding Razor CodeBehind
    5. Adding Entity Framework CRUD
    6. Adding Authorization


## Out of scope
- Adding Microsoft Identity Platform to existing asp.net app (out of scope, maybe seperate article?)


## External Articles
- Using CodeBehind files for razor pages (Based on [this](https://medium.com/stories-by-progress/using-a-code-behind-approach-to-blazor-components-da6525f576cc))

## Feature Wishlist