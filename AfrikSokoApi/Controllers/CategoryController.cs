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

namespace AfrikSokoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _catrepo;

        public CategoryController(ICategoryRepository catrepo)
        {
            _catrepo = catrepo;
        }
 
        /// <summary>
        /// Retrieve The Complete List of Categories
        /// </summary>
        /// <response code="200">Return The List of Categories</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_catrepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Allow to Register a New Category
        /// Requires a model Category to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>     
        [HttpPost]
        public IActionResult Create(NewCategoryCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _catrepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify Category based on Id
        /// Requires a model Category to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifyCategory form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _catrepo.Update(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Delete Category based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _catrepo.Delete(id);
            return Ok();
        }

    }
}
