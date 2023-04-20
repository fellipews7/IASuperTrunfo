using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }

        public void ConfigureServices (IServiceCollection services)
        {
            
        }
    }
}
