using Employee_Core.Entities;
using Employee_Infrastructure.Data;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Handlers
{
    public class AuthServices : IAuthDataRepository<Login>
    {
        public readonly EmployeeContext? _apiDbContext;
        public AuthServices(EmployeeContext? apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public Login Checkauth(string username, string password)
        {
            var obj = _apiDbContext.logins.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return obj;
        }
    }
}
