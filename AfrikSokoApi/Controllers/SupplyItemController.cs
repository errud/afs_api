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
    public class SupplyItemController : ControllerBase
    {
        private readonly ISupplyItemRepository _supitemrepo;

        public SupplyItemController(ISupplyItemRepository supitemrepo)
        {
            _supitemrepo = supitemrepo;
        }

        /// <summary>
        /// Retrieve The Complete List of Supplied Items
        /// </summary>
        /// <response code="200">Return The List of Supplied Items</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>  
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_supitemrepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Return the Items supplied by an user 
        /// Parameter type as integer
        /// </summary>
        /// <response code="200">Return supplied items</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>Object type is supplyitem</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_supitemrepo.GetByUser(id).Select(x => x.ToApi()));
        }

        /// <summary>
        /// Allow to Register a New Supplied Item
        /// Requires a model SupplyItem to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewSupplyItemCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _supitemrepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify SupplyItem based on Id
        /// Requires a model SupplyItem to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifySupplyItem form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _supitemrepo.Update(form.ProToDal());
            return Ok();
        }


        /// <summary>
        /// Delete  based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        /*[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _supitemrepo.Delete(id);
            return Ok();
        }*/


    }
}
