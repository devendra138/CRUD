
using APICRUDOperations.Models;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.IServices
{
    public interface IRegistrationService
    {
        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public Task<int?> Add(Employee employee);

        /// <summary>
        /// Get employees list
        /// </summary>
        /// <returns>EmployeeListModel</returns>
        public Task<List<EmployeeListModel>> Get();

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public Task<int?> Update(Employee employee);

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> Delete(int id);
    }
}
