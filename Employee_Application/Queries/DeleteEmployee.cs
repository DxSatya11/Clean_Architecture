using Amazon.Runtime.Internal;
using Employee_Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Queries
{
    public record DeleteEmployee : IRequest<IEnumerable<Employee>>
    {
        public int EmployeeId { get; set; }
    }
}

