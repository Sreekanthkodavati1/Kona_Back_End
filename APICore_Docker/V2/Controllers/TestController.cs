using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_APIService.V2.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class TestController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {

        /// <summary>
        /// Getting the data
        /// </summary>        
        [HttpGet]
        public async Task<IActionResult> getList()
        {
            try
            {
                var resultData = await Task.Run(() =>
                {
                    return new { Name = "Yoga" };
                });
                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }


        }
    }
}
