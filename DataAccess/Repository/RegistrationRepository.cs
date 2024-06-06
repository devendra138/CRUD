using DataAccess.IRepository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        CompanyDetailsContext context = new CompanyDetailsContext();

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public async Task<int?> Add(Employee employee)
        {
            var data = await context.AddAsync(employee);
            context.SaveChangesAsync();
            return data.Entity.EmployeeId;
        }

        /// <summary>
        /// Get employees list
        /// </summary>
        /// <returns>Employee</returns>
        public async Task<List<Employee>> Get()
        {
            var data = await context.Employees.ToListAsync();
            return data;
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public async Task<int?> Update(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChangesAsync();
            return employee.EmployeeId;
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> Delete(int id)
        {
            // Find the employee by ID
            var employee = await context.Employees.FindAsync(id);

            // If the employee doesn't exist, return false
            if (employee == null)
            {
                return false;
            }

            // Mark the employee for deletion
            context.Employees.Remove(employee);

            // Save changes to the database
            await context.SaveChangesAsync();

            return true;
        }
    }
}
