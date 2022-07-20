using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;


namespace IntranetServerTemplate.Web.Pages
{
    public class AddCustomerBase : ComponentBase, IDisposable
    {
        [Inject] CustomerService CustomerService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected Customer customer = new Customer();

        protected async Task AddCustomer()
        {
            CustomerService.AddCustomer(customer);
            await CustomerService.SaveChangesAsync();
            NavigationManager.NavigateTo("customers");
        }

        public void Dispose()
        {
            CustomerService?.Dispose();
        }
    }
}
