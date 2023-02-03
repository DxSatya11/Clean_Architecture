using Employee_Application.Commands;
using Employee_Application.Mappers;
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

namespace Employee_Application.Handlers
{
    public class LoginHandler : IRequestHandler<CreateLoginCommand, LoginResponse>
    {
        private readonly IRepository<Login> _loginrepository;
        public LoginHandler(IRepository<Login> loginrepository)
        {
            _loginrepository = loginrepository;
        }
        public async Task<LoginResponse> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var logonentity = LoginMapper.Mapper.Map<Login>(request);
            if (logonentity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newLogin = await _loginrepository.AddAsync(logonentity);
            var loginResponse = LoginMapper.Mapper.Map<LoginResponse>(newLogin);
            return loginResponse;
        }


    }
}
