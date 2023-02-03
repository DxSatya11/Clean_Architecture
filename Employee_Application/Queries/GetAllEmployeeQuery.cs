using Employee_Application.Commands;
using Employee_Application.Responses;
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

namespace Employee_Application.Queries
{
    public record GetAllEmployeeQuery : IRequest<IEnumerable<Employee>>;
   
}
