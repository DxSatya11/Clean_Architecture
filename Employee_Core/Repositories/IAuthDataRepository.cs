using Employee_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Core.Repositories
{
    public  interface IAuthDataRepository<TEntity>
    {
        public Login Checkauth(string username, string password);
    }
}
