using DataAccess.Models;

namespace DataAccess.IRepository
{
    public interface IRegistrationRepository
    {
        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public Task<int?> Add(Employee employeeModel);

        /// <summary>
        /// Get employees list
        /// </summary>
        /// <returns>Employee</returns>
        public Task<List<Employee>> Get();

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public Task<int?> Update(Employee employeeModel);

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> Delete(int id);
    }
}
