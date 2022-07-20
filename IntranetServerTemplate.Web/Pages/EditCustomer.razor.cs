using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Web.Pages
{
    //todo: support for concurrency conflict: https://github.com/dotnet/blazor-samples/blob/main/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor
    public class EditCustomerBase : ComponentBase
    {
        [Inject] CustomerService CustomerService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; } = 0;

        protected Customer customer;

        protected override async Task OnInitializedAsync()
        {
            var customerInDb = CustomerService.GetCustomers().First(i => i.Id == Id);

            customer = customerInDb with { }; //the with {} will clone the record, disconnecting the changes in this form's model from the rest of the app's in case the user navigates away (or presses cancel)
            //todo can we find a better way to bind the data model in the form, yet dispose it once the user navigates away? does the blazor example's dispose method do this? https://github.com/dotnet/blazor-samples/blob/main/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor

        }

        protected async Task EditCustomer()
        {
            var customerInDb = CustomerService.GetCustomers().First(i => i.Id == Id);

            //update the form field 
            //todo can we find a better way to bind the data model in the form, yet dispose it once the user navigates away? does the blazor example's dispose method do this? https://github.com/dotnet/blazor-samples/blob/main/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor

            customerInDb.Name = customer.Name;

           // CustomerService.EditCustomer(customer);
            await CustomerService.SaveChangesAsync();
            NavigationManager.NavigateTo("customers");
        }
    }
}
