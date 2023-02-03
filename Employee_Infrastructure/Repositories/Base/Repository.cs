using Employee_Core.Entities;
using Employee_Core.Repositories.Base;
using Employee_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeContext _employeeContext;
        public Repository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _employeeContext.Set<T>().AddAsync(entity);
            await _employeeContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> DeleteAsync(int Id)
        {
            //var Employee = new Employee()
            //{
            //    EmployeeId = Id
            //};
            //_employeeContext.employees.Remove(Employee);
            //_employeeContext.employees.Remove(Employee);
            //await _employeeContext.SaveChangesAsync();
            //return Employee;




            var Employee = await _employeeContext.employees.FindAsync(Id);
            //if (Employee == null)
            //{
            //    return "Employee Not found";
            //}
            _employeeContext.employees.Remove(Employee);
            await _employeeContext.SaveChangesAsync();
            return Employee;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _employeeContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _employeeContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }



    }
}
