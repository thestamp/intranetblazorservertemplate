using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntranetServerTemplate.Core.Data;

namespace IntranetServerTemplate.Core.Services
{
    public class ServiceBaseData
    {
        protected readonly DataContext Context;

        public ServiceBaseData(DataContext context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
