using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoingPractical.DBAccess;
using VoingPractical.Model;

namespace Voingtech_Practical.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _connection;
        private readonly IRegistrationDAL _registrationDAL;

        public RegistrationController(IConfiguration config, IRegistrationDAL _RegistrationDAL)
        {
            _config = config;
            _connection = _config.GetConnectionString("dbcon");
            _registrationDAL = _RegistrationDAL;
        }

        [HttpPost("AddRegistration")]
        public async Task<IActionResult> AddRegistration(Registration Registration_obj)
        {
            List<Error> errors = new List<Error>();
            try
            {
                Registration_obj.DMLFlag = "I";
                var result = _registrationDAL.Registration_InsertUpdateDelete(_connection, Registration_obj);
                if (result > 0)
                {
                    Registration_obj.Id = result;
                    return StatusCode(StatusCodes.Status201Created, new Response<Registration> { IsSucceed = true, Errors = errors, ReturnObject = null });
                }
                else
                {
                    errors.Add(new Error() { Name = "Error", Value = "Something wrong happenned while adding registration." });
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response<Registration> { IsSucceed = false, Errors = errors });
                }
            }
            catch (Exception ex)
            {
                errors.Add(new Error() { Name = "Exception", Value = "Something wrong happenned: Error: " + ex.Message.ToString() });
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<Registration> { IsSucceed = false, Errors = errors });
            }
        }


    }
}
