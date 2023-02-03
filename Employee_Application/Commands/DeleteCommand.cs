using Employee_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Commands
{
    public class DeleteCommand : IRequest<Unit>
    {
        public int EmployeeId { get; set; }
    }
}
