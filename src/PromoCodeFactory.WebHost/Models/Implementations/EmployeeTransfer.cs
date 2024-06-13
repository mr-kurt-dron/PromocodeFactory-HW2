using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models.Abstraction;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class EmployeeTransfer(IRepository<Employee> _employeeRepository, IRepository<Role> _roleRepository) : ITransfer<EmployeeRequest, EmployeeResponse>
    {
        public async Task<Guid> SendCreate(EmployeeRequest entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.RolesId == null) throw new ArgumentException("Должна быть указана хотя бы одна роль!");
            var roles = await _roleRepository.GetAllAsync();
            var employee = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Roles = roles.Where(x => entity.RolesId.Contains(x.Id)).ToList(),
                AppliedPromocodesCount = entity.AppliedPromocodesCount,
            };
            var id = await _employeeRepository.CreateAsync(employee);
            return id;
        }

        public async Task<EmployeeResponse> SendGet(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with id {id} not found");
            }

            var employeeModel = new EmployeeFullResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Roles = employee.Roles.Select(x => new RoleItemResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return employeeModel;
        }

        public async Task<IEnumerable<EmployeeResponse>> SendGetList()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeesModelList = employees.Select(x =>
            new EmployeeResponse()
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
            }).ToList();
            return employeesModelList;
        }

        public async Task<EmployeeResponse> SendUpdate(Guid id, EmployeeRequest entity)
        {
            var roles = await _roleRepository.GetAllAsync();
            if (entity.RolesId == null) throw new ArgumentException("Должна быть указана хотя бы одна роль!");
            var employee = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Roles = roles.Where(x => entity.RolesId.Contains(x.Id)).ToList(),
                AppliedPromocodesCount = entity.AppliedPromocodesCount,
            };
            var updatedEmployee = await _employeeRepository.UpdateAsync(id, employee);
            var employeeResponse = new EmployeeFullResponse()
            {
                Id = updatedEmployee.Id,
                FullName = updatedEmployee.FullName,
                Email = updatedEmployee.Email,
                Roles = updatedEmployee.Roles.Select(x => new RoleItemResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                AppliedPromocodesCount = updatedEmployee.AppliedPromocodesCount
            };
            return employeeResponse;
        }
        public async Task SendDelete(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
