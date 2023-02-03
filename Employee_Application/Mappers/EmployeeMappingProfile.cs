using AutoMapper;
using Employee_Application.Commands;
using Employee_Application.Queries;
using Employee_Application.Responses;
using Employee_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, GetAllEmployeeQuery>().ReverseMap();
         //   CreateMap<Employee, DeleteEmployee>().ReverseMap();


        }
    }
   
}
