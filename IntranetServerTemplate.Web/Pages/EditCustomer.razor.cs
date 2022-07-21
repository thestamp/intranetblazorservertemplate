using IntranetServerTemplate.Core.Data;
using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Web.Pages
{
    //todo: support for concurrency conflict: https://github.com/dotnet/blazor-samples/blob/main/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor
    //this is for when we want model isolation between each action.
        //for a more shared datacontext data model approach, see AddCustomer.
    public class EditCustomerBase : ComponentBase
    {
        [Inject] IDbContextFactory<DataContext> contextFactory { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; } = 0;

        protected Customer customer;

        protected override async Task OnInitializedAsync()
        {
            using var dataContext = contextFactory.CreateDbContext();
            var service = new CustomerService(dataContext);

            customer = service.GetCustomers().First(i => i.Id == Id);

        }

        protected async Task EditCustomer()
        {
            using var dataContext = contextFactory.CreateDbContext();
            var service = new CustomerService(dataContext);

            var customerInDb = service.GetCustomers().First(i => i.Id == Id);
            customerInDb.Name = customer.Name;
            await dataContext.SaveChangesAsync();

            NavigationManager.NavigateTo("customers");
        }

        /*
         * Support for UnitOfWork - https://docs.microsoft.com/en-us/aspnet/core/blazor/blazor-server-ef-core?view=aspnetcore-6.0
         * 1) In Program.cs, change builder.Services.AddDbContext to builder.Services.AddDbContextFactory
         *
         * 2) In Program.cs, We want each injected service to be its own instance, with their own datacontext:
         *  2.1) change builder.Services.AddDbContext to builder.Services.AddDbContextFactory
         *
         * 3) use EditCustomer or AddCustomer codebehind as templates depending on your functional needs:
         *  - for an example of a datacontext that exists for the lifetime of the page, use AddCustomer
         *  - if you need a datacontext's lifecycle to only exist for a specific method, use EditCustomer's EditCustomer() example
         *  Note: If needed, you can certainly have a datacontext that exists for the lifetime of the page, and have a seperate datacontext for a specific method 
         *
         */
    }
}
