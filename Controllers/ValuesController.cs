using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using AssignmentProject.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using AssignmentProject.Services.Contract;
using AssignmentProject.Utilities;

namespace AssignmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService _userService;
        public UserController(IuserService userService)
        {
            _userService = userService;

        }
        [HttpPost]
        [Authorize]
        public IActionResult postCustomerDetails(ResponseUser responseUser)
        {
            ResponseApi<ResponseUser> Response = new ResponseApi<ResponseUser>();

            try
            {
                ResponseUser newdeatil = _userService.AddData(responseUser);
                Response  = new ResponseApi<ResponseUser>
                {
                    Status = true,
                    Msg = "Added",
                    Value = newdeatil
                };
                return StatusCode(StatusCodes.Status200OK, Response);

            }
            catch (Exception ex)
            {
                Response = new ResponseApi<ResponseUser>(); Response.Msg = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, Response);

            }
        }

        [HttpPost("verify")]
        
        public ActionResult<ResponseUser> CheckUser([FromBody] ResponseUser responseUser)
        {
            try
            {
                var responses = this._userService.Verify(responseUser);
                if (string.IsNullOrWhiteSpace(responseUser.Email) || string.IsNullOrWhiteSpace(responseUser.UserPassword))
                {
                    return BadRequest(responses);
                }
                if (responses == "verification failed" || responses == "Wrong Password")
                {
                    return BadRequest(responses);
                }
                return Ok(responses);
            }
            catch (Exception ex)
            {
                var response = new ResponseApi<ResponseUser>();
                response.Msg = ex.Message;
                return BadRequest(response);

            }
        }

    }


}




