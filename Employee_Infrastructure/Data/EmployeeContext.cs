using Employee_Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Azure.Identity;
using Azure.Core;

namespace Employee_Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            //var conn = (System.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();
            //conn.AccessToken = new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/").Result;

            //var conn = (Microsoft.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();
            //conn.AccessToken = (new DefaultAzureCredential()).GetToken("https://satyaserver.database.windows.net").Result;
            var tokenRequestContext = new TokenRequestContext(new[] { "https://database.windows.net/" });
            var accessToken = (new DefaultAzureCredential()).GetToken(tokenRequestContext);
            var conn = (Microsoft.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();
            conn.AccessToken = accessToken.Token;

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<AuthenticateResponse> authentications { get; set; }
         
    }
}
