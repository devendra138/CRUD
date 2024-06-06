using APICRUDOperations.Models;
using BusinessLogic.IServices;
using BusinessLogic.Models;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICRUDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public readonly IRegistrationService _iregistration;

        public RegistrationController(IRegistrationService registration)
        {
            _iregistration = registration;
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>ResponceModel</returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ResponceModel> Add(Employee employeeModel)
        {
            var res = _iregistration.Add(employeeModel);
            ResponceModel responce = new ResponceModel();
            if (res != null)
            {
                responce.StatusCode = 200;
                responce.Message = "success";
                responce.Data = res;
            }
            else
            {
                responce.StatusCode = 500;
                responce.Message = "failed";
                responce.Data = null;
            }
            
            return responce;
        }

        /// <summary>
        /// Get employee List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public async Task<List<EmployeeListModel>> Get()
        {
            var lst = await _iregistration.Get();
            
            return lst;
        }

        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>ResponceModel</returns>
        [HttpPost]
        [Route("Update")]
        public async Task<ResponceModel> Update(Employee employeeModel)
        {
            var res = _iregistration.Update(employeeModel);
            ResponceModel responce = new ResponceModel();
            if (res != null)
            {
                responce.StatusCode = 200;
                responce.Message = "success";
                responce.Data = res;
            }
            else
            {
                responce.StatusCode = 500;
                responce.Message = "failed";
                responce.Data = null;
            }

            return responce;
        }


        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponceModel</returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<ResponceModel> Delete(int id)
        {
            var res = await _iregistration.Delete(id);
            ResponceModel responce = new ResponceModel();
            if (res)
            {
                responce.StatusCode = 200;
                responce.Message = "success";
                responce.Data = res;
            }
            else
            {
                responce.StatusCode = 500;
                responce.Message = "failed";
                responce.Data = res;
            }

            return responce;
        }
    }
}
