using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

namespace Templete.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userServices)
        {
            this.userService = userServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(this.userService.Get());
        }
        [HttpPost]
        public IActionResult Post(UserViewModel userViewModel)
        {

            return Ok(this.userService.Post(userViewModel));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {

            return Ok(this.userService.GetById(id));
        }
        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.userService.Put(userViewModel));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            return Ok(this.userService.Delete(id));
        }
        [HttpPost("Authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {

            return Ok(this.userService.Authenticate(userViewModel));
        }
    }
}
