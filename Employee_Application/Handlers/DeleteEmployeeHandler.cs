using Employee_Application.Commands;
using Employee_Application.Mappers;
using Employee_Application.Queries;
using Employee_Application.Responses;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using Employee_Core.Repositories.Base;
using Employee_Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteCommand,Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteAsync(request.EmployeeId);
            return Unit.Value;
        }
    }
}
