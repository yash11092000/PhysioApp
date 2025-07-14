using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhysioApp.Models;
using PhysioApp.Repository;

namespace PhysioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("/Home")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<Users> users = await _userRepository.GetAllUsers();
            if (User != null)
            {
                return Ok(users);
            }
            return BadRequest("Users Not Found");
        }

        [HttpPost("/AddUsers")]
        public async Task<ActionResult> AddUsers(Users user)
        {
            string UserSerialNo = await _userRepository.AddUsers(user);
            if (UserSerialNo != "")
            {
                return Ok(UserSerialNo + " Has Been Created");
            }
            return BadRequest("Error Occured");
        }

        [HttpGet("/GetUserById")]
        public async Task<ActionResult> GetUserById(int UserId)
        {
            Users User = await _userRepository.GetUserById(UserId);
            if (User != null)
            {
                return Ok(User);
            }
            return BadRequest("Error Occured");
        }

        [HttpPost("EditUsers")]
        public async Task<ActionResult> EditUsers(Users user)
        {
            int result = await _userRepository.EditUsers(user);
            if (result > 0)
            {
                return Ok("Updated Successyully");
            }
            return BadRequest("error Occured");
        }
    }
}
