using Employee_Core.Entities;
using Employee_Core.Repositories;
using Employee_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Infrastructure.Repositories.Base
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext) { }
        public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname)
        {
            return await _employeeContext.employees.Where(m => m.LastName == lastname).ToListAsync();
        }
    }
}
