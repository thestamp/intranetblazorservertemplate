using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntranetServerTemplate.Core.Data;
using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Web.Pages
{
    public class CustomersBase : ComponentBase
    {
        [Inject] IDbContextFactory<DataContext> contextFactory { get; set; }

        protected Customer[]? customers;

        protected override async Task OnInitializedAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var service = new CustomerService(context);
            var customerList = await service.GetCustomers().ToListAsync();
            customers = customerList.ToArray();
        }

    }
}
