using Employee_Application.Commands;
using Employee_Application.Queries;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Handlers
{
    public class GetEmployeeByLastNameHandler : IRequestHandler<GetEmployeeByLastNameCommand, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeByLastNameHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        

        public async Task<IEnumerable<Employee>> Handle(GetEmployeeByLastNameCommand request, CancellationToken cancellationToken)
        {
           
            var employeelist = await _employeeRepository.GetEmployeeByLastName(request.lastname);
            return employeelist;
        }
    }
}
