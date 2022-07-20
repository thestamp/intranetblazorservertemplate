using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntranetServerTemplate.Core.Data.Models;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Web.Pages
{
    public class CustomersBase : ComponentBase, IDisposable
    {
        [Inject] CustomerService CustomerService { get; set; }

        protected Customer[]? customers;

        protected override async Task OnInitializedAsync()
        {
            var customerList = await CustomerService.GetCustomers().ToListAsync();
            customers = customerList.ToArray();
        }

        public void Dispose()
        {
            CustomerService?.Dispose();
        }
    }
}
