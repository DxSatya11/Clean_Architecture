using Employee_Application.Queries;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using Employee_Core.Repositories.Base;
using Employee_Infrastructure.Repositories.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepo;
        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }
        

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeelist = await _employeeRepo.GetAllAsync();
            return employeelist;
        }
    }
}
