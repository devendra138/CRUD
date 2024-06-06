using APICRUDOperations.Models;
using AutoMapper;
using BusinessLogic.Constants;
using BusinessLogic.IServices;
using BusinessLogic.Models;
using DataAccess.IRepository;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class RegistrationService : IRegistrationService
    {
        public readonly IRegistrationRepository _iRegistrationRepository;
        private readonly IMapper _mapper;
        public RegistrationService(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _iRegistrationRepository = registrationRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public async Task<int?> Add(Employee employeeModel)
        {
            //var data = _mapper.Map<Employee>(employeeModel);
            var id = await _iRegistrationRepository.Add(employeeModel);
            return id;
        }

        /// <summary>
        /// Get employees list
        /// </summary>
        /// <returns>EmployeeListModel</returns>
        public async Task<List<EmployeeListModel>> Get()
        {
            var data = await _iRegistrationRepository.Get();
            List<EmployeeListModel> empList = new List<EmployeeListModel>();

            foreach (var item in data)
            {
                var employee = new EmployeeListModel
                {
                    EmployeeId = item.EmployeeId,
                    Name = item.Name,
                    Salary = item.Salary,
                    Designation = ((Enemerable.Designation)item.DesignationId).ToString(),
                    Gender = ((Enemerable.Gender)item.GenderId).ToString(),
                    Status = item.Status
                };

                empList.Add(employee);
            }

            return empList;
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>bool</returns>
        public async Task<int?> Update(Employee employeeModel)
        {
            var id = await _iRegistrationRepository.Update(employeeModel);
            return id;
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> Delete(int id)
        {
            var status = await _iRegistrationRepository.Delete(id);
            return status;
        }
    }
}
