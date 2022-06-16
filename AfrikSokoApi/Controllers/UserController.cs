using AfrikSoko_BLL.LocalModels;
using AfrikSoko_BLL.LocalServices.Interface;
using AfrikSoko_DAL.Interface;
using AfrikSokoApi.Models;
using AfrikSokoApi.Services;
using AfrikSokoApi.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API = AfrikSokoApi.Models;
using DAL = AfrikSoko_DAL.Models;

namespace AfrikSokoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly TokenService _tokenService;
        private readonly IUserRepository<DAL.User> _userRepo;
       

        public UserController(TokenService tokenService, IUserRepository<DAL.User> userRepo, IUserService userService)
        {
            _tokenService = tokenService;
            _userRepo = userRepo;
            _userService = userService;
     
        }
        /// <summary>
        /// Connect as user (Login)
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only for user who has already registered before</remarks>
        //[Authorize("User")]
        [HttpPost("login")]
        public IActionResult Login(FormLogin form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                API.AppUser currentUser = _userRepo.Login(form.Email, form.Password).ToApi();

                currentUser.Token = _tokenService.GenerateJWT(currentUser);

                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserInfo newUser)
        {
            try
            {
                _userService.RegisterUser(newUser.ToLocal());
                return Ok("Account registered successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Return The List of All Users
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if Admin role user</remarks>
        //[Authorize("Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Return The User Profile
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>
       // [Authorize("User")]
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                return Ok(_userService.GetById(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Remove The User (in soft delete mode)
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if Admin role user</remarks>
        //[Authorize("Admin")]
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                _userService.Switchactivate(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update or Modify The User Profile
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>
      //  [Authorize("User")]
        [HttpPut]
        public IActionResult Update(CompleteAppUser u)
        {
            try
            {
                _userService.Update(u);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Assign the User the Admin or no Admin role
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if Admin role user</remarks>
        //[Authorize("Admin")]
        [HttpPut("/setAdmin/{Id}")]
        public IActionResult SwitchAdmin(int Id)
        {
            try
            {
                _userService.SwitchAdmin(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
