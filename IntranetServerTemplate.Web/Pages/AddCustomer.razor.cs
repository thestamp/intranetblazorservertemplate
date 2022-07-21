using IntranetServerTemplate.Core.Data;
using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;


namespace IntranetServerTemplate.Web.Pages
{
    //this is for when we want to share the same datacontext across multiple buttons, sharing the same model to be saved to the database at the end.
    //for a more isolated datacontext data model approach, see EditCustomer.


    /*
     * Jeff's comments
     * 
     *   we COULD also add DI for CustomerService, but then we would start leaning toward the global singleton antipattern.
     *      we would also need to add save/rollback methods to the base class.
     *      data context injection in the service classes would be necessary, but the top-level method would lose control over the unit-of-work.
     *   Conclusion Opinion: DI should be for infrastructure-based items only.
     */
    public class AddCustomerBase : ComponentBase, IDisposable
    {
        [Inject] IDbContextFactory<DataContext> contextFactory { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected Customer customer = new Customer();

        private DataContext dataContext;

        protected override async Task OnInitializedAsync()
        {
            dataContext = await contextFactory.CreateDbContextAsync();
        }

        protected async Task AddCustomer()
        {
            var service = new CustomerService(dataContext);

            service.AddCustomer(customer);
            await dataContext.SaveChangesAsync();

            NavigationManager.NavigateTo("customers");
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
