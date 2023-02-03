using Employee_Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Commands
{
    public class GetEmployeeByLastNameCommand : IRequest<IEnumerable<Employee>>
    {
        public string lastname { get; set; }
    }
}
