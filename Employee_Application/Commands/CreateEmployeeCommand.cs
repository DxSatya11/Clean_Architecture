using Amazon.Runtime.Internal;
using Employee_Application.Responses;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Commands
{
    public class CreateEmployeeCommand : IRequest <EmployeeResponse>
    {
       // public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}

