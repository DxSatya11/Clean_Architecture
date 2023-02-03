using Employee_Core.Entities;
using Employee_Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Core.Repositories
{

    public interface IEmployeeRepository : IRepository<Employee>
    {
       // Task DeleteAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname);
    }

}
