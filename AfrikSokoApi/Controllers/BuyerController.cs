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
    public class BuyerController : ControllerBase
    {

        private readonly IBuyerRepository _buyrepo;

        public BuyerController(IBuyerRepository buyrepo)
        {
            _buyrepo = buyrepo;
           
        }

        /// <summary>
        /// Retrieve The Complete List of Buyers
        /// </summary>
        /// <response code="200">Return The List of Buyers</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>  
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_buyrepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Return the Buyer based on its Id
        /// Parameter type as integer
        /// </summary>
        /// <response code="200">Return one Buyer</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>Object type is buyer</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_buyrepo.GetById(id).ToApi());
        }
        /// <summary>
        /// Allow to Register a New Buyer
        /// Requires a model Buyer to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>     
        [HttpPost]
        public IActionResult Create(NewBuyerCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _buyrepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify Buyer based on Id
        /// Requires a model Buyer to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifyBuyer form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _buyrepo.Update(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Delete Buyer based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _buyrepo.Delete(id);
            return Ok();
        }



    }
}
