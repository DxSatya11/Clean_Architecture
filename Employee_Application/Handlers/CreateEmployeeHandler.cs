using Employee_Application.Commands;
using Employee_Application.Mappers;
using Employee_Application.Responses;
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
    public class CreateEmployeeHandler: IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepo;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntitiy = EmployeeMapper.Mapper.Map<Employee>(request);
            if (employeeEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newEmployee = await _employeeRepo.AddAsync(employeeEntitiy);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
            return employeeResponse;
        }

    }
}
