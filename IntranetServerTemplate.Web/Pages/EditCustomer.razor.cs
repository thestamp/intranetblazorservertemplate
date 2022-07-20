using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Web.Pages
{
    //todo: support for concurrency conflict: https://github.com/dotnet/blazor-samples/blob/main/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor
    public class EditCustomerBase : ComponentBase, IDisposable
    {
        [Inject] CustomerService CustomerService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; } = 0;

        protected Customer customer;

        protected override async Task OnInitializedAsync()
        {
            customer = CustomerService.GetCustomers().First(i => i.Id == Id);

        }

        protected async Task EditCustomer()
        {
            var customerInDb = CustomerService.GetCustomers().First(i => i.Id == Id);


            //todo find a way to save just the fields we want
            await CustomerService.SaveChangesAsync();
            NavigationManager.NavigateTo("customers");
        }

        public void Dispose()
        {
            CustomerService?.Dispose();
        }

        //todo CONFIRM NO ISSUES with using AddTransient<DataContext>() with blazor server -
        /*
         * Support for UnitOfWork - https://docs.microsoft.com/en-us/aspnet/core/blazor/blazor-server-ef-core?view=aspnetcore-6.0
         * 1) In Program.cs, change builder.Services.AddDbContext to builder.Services.AddDbContextFactory
         *
         * 2) In Program.cs, We want each injected service to be its own instance, with their own datacontext:
         *  2.1) change builder.Services.AddDbContext to builder.Services.AddDbContextFactory
         *  2.2) change all injected services using the DataContext from AddScoped to AddTransient
         *  2.2) change/add the DataContext to be AddTransient (ex: builder.Services.AddTransient<DataContext>();)
         *
         *
         * 3) For the base service class
         *  3.1) Have it inherit from IDisposable (ex: public class ServiceBaseData : IDisposable)
         *  3.2) add the following Dispose() method:
         *           public void Dispose()
         *           {
         *               Context?.Dispose();
         *           }
         *
         * 4) For each blazor component using the affected service classes, do the following:
         *   4.1) Have the Component inherit from IDisposable (ex: public class CustomersBase : ComponentBase, IDisposable)
         *   4.2) add the following Dispose() method (change to include your service classes):
         *           public void Dispose()
         *           {
         *               CustomerService?.Dispose();
         *           }
         *
         */
    }
}
