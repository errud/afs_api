using AfrikSoko_BLL.LocalModels;
using AfrikSoko_BLL.LocalServices.Interface;
using AfrikSoko_DAL.Interface;
using AfrikSoko_DAL.Models;
using AfrikSokoApi.Models;
using AfrikSokoApi.Tools;
using AfrikSokoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL = AfrikSoko_BLL.LocalModels;
using API = AfrikSokoApi.Models;
using DAL = AfrikSoko_DAL.Models;
using IF = AfrikSoko_DAL.Interface;

namespace AfrikSokoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _comrepo;
        private readonly IUserService _userService;
        private readonly IProductRepository<DAL.Product, DAL.SupplyItem> _prorepo;


        public CommentController(ICommentRepository comrepo, IUserService userService, IF.IProductRepository<DAL.Product, DAL.SupplyItem> prorepo)
        {
            _comrepo = comrepo;
            _userService = userService;
            _prorepo = prorepo;
        }

        /// <summary>
        /// Retrieve The Complete List of Comments
        /// </summary>
        /// <response code="200">Return The List of Comments</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_comrepo.GetAll().Select(x => x.ToApi()));
   

        }

        /// <summary>
        /// Allow to Register a New Comment
        /// Requires a model Comment to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>     
        [HttpPost]
        public IActionResult Create(NewCommentCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _comrepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify Comment based on Id
        /// Requires a model Comment to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifyComment form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _comrepo.Update(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Delete Comment based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _comrepo.Delete(id);
            return Ok();
        }
    }
}
