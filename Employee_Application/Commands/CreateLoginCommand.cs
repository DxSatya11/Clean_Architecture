using Employee_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Commands
{
    public class CreateLoginCommand : IRequest<LoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
