using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Core_BALInterfaceCore;
using Microsoft.AspNetCore.Http;
using Core_Domain;

namespace Core_APIService.V1.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
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

        [HttpGet("{UserId}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int UserId)
        {
            try
            {
                var users = await _UserBal.GetUserById(UserId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertData([FromBody]User User)
        {
            try
            {

                var result = await _UserBal.Insert(User);
                if (result.Item2) return CreatedAtRoute("GetUserById", new { UserId = result.Item1 }, User);
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
