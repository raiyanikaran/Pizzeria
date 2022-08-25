using Microsoft.AspNetCore.Mvc;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzeria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: api/<UserController>
        [HttpGet, Route("")]
        public ActionResult<List<User>> GetUsers()
        {
            try
            {
                return Ok(userService.GetAllUsers());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
