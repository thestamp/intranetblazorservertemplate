using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntranetServerTemplate.Core.Data;
using IntranetServerTemplate.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Core.Services
{
    public class CustomerService : ServiceBaseData
    {
        public CustomerService(DataContext context) : base(context)
        {
        }

        public IQueryable<Customer> GetCustomers()
        {
            return Context.Customers.AsQueryable();
        }

        public void EditCustomer(Customer customer)
        {
            Context.Customers.Update(customer);
        }

        public void AddCustomer(Customer customer)
        {
            Context.Customers.Add(customer);
        }
    }
}
