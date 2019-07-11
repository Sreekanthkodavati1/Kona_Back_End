using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_DomainModel;
using Core_BALInterfaceCore;
using Microsoft.AspNetCore.Http;
namespace Core_APIService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEntityBAL<User> _UserBal;


        public UserController(IEntityBAL<User> userBal)
        {
            _UserBal = userBal;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _UserBal.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertData(string firstName, string lastName)
        {
            try
            {
                var user = new User { UserId = 2, FirstName = firstName, LastName = lastName };

                if (await _UserBal.Insert(user))
                {
                    return Ok(user);
                }
                return BadRequest("Some thing wen wrong in saving the changes");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDataById([FromBody]User model)
        {
            try
            {

                if (await _UserBal.Delete(model, model.UserId))
                {
                    return Ok(true);
                }
                return BadRequest("Some thing wen wrong in deleting the records");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData([FromBody]User model)
        {
            try
            {

                if (await _UserBal.Update(model))
                {
                    return Ok(model);
                }
                return BadRequest("Some thing wen wrong in updating the changes");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
