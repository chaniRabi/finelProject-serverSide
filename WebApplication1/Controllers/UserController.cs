using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BL;
using DAL;
using Entities.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<List<User>> GetUsers()
        {
            var Users = await _userBL.GetUsers();
            return Users;
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<User> GetUserById(int id)
        {
            User currentUser = await _userBL.GetUserById(id);
            return currentUser;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDTO>> login([FromBody] UserLoginDTO user)
        {
            UserDTO currentUser = await _userBL.login(user);
            if(currentUser != null)
            {
                return Ok(currentUser);
            }
            return StatusCode(204, "email or password no correct");
        }

        //[HttpPost]
        //[Route("login")]
        //public IActionResult login(UserDTO user)
        //{
        //    // Validate credentials
        //    bool isValid = _userBL.login(email , pasword);
        //        //_authenticationService.ValidateCredentials(loginRequest.Username, loginRequest.Password);

        //    if (isValid)
        //    {
        //        // Generate access token
        //        string accessToken = GenerateAccessToken();
        //        DateTime expirationTime = DateTime.Now.AddHours(1);

        //        // Create and return the response DTO
        //        var responseDTO = new LoginResponseDTO
        //        {
        //            UserId = 1, // Set the appropriate user ID
        //            AccessToken = accessToken,
        //            ExpirationTime = expirationTime
        //        };

        // POST api/<UserController>
        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO user)
        {
            try
            {
                UserDTO isAddUser = await _userBL.AddUser(user);
                return Ok(isAddUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> RemoveUser([FromBody] int id)
        {
            try
            {
                bool isRmoveUser = await _userBL.RemoveUser(id);
                return isRmoveUser;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update([FromBody] UserDTO user, int id)
        {
            try
            {
                UserDTO updatedUser = await _userBL.Update(user, id);
                if (updatedUser != null)
                    return Ok(user);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string modifiedMessage = ex.Message + "somthing went wrong";
                throw new Exception(modifiedMessage);
            }

        }

    }
}
