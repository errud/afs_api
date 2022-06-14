using AfrikSoko_BLL.LocalModels;
using AfrikSoko_BLL.LocalServices.Interface;
using AfrikSoko_DAL.Interface;
using AfrikSoko_DAL.Models;
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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _adrepo;

        public AddressController(IAddressRepository adRepo)
        {
            _adrepo = adRepo;
        }

        /// <summary>
        /// Retrieve The Addresses List
        /// </summary>
        /// <response code="200">Return The List of Addresses</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>IEnumerable of Products with Items Supplied by Supplier</returns>
        /// <remarks>Accessible only if user connected</remarks>        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_adrepo.GetAll().Select(x => x.ProToApi()));
        }

        /// <summary>
        /// Return the address based on its Id
        /// Parameter type as integer
        /// </summary>
        /// <response code="200">Return one product</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>Object type is product</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_adrepo.GetByUserId(id).Select(x => x.ProToApi()));
        }

        /// <summary>
        /// Save a new address
        /// Requires a model Address to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewAddressInfo form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _adrepo.Create(form.ProToDal());
            return Ok();
        }


        /// <summary>
        /// Update or Modify Address based on Id
        /// Requires a model Address to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(PutAddress form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _adrepo.Update(form.ProToDal());
            return Ok();
        }


        /// <summary>
        /// Delete Address based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adrepo.Delete(id);
            return Ok();
        }




    }
}
