using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_BAL;
using Core_DomainModel;
using Core_BALInterfaceCore;
//using Microsoft.Extensions.Configuration

namespace Core_APIService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBAL userBAL;
        //UserBAL userBAL = new UserBAL();
        public UserController(IUserBAL userBAL)
        {
            this.userBAL = userBAL;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            // return new string[] { "value1", "value2" };
            return Ok(userBAL.GetUsers());

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetUser(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
