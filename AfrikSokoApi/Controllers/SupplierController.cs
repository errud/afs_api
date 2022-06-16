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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _suprepo;

        public SupplierController(ISupplierRepository suprepo)
        {
            _suprepo = suprepo;
        }
        /// <summary>
        /// Retrieve The Complete List of Suppliers
        /// </summary>
        /// <response code="200">Return The List of Suppliers</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>  
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_suprepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Return the Supplier based on its Id
        /// Parameter type as integer
        /// </summary>
        /// <response code="200">Return one supplier</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>Object type is supplier</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_suprepo.GetById(id).ToApi());
        }

        /// <summary>
        /// Allow to Register a New Supplier
        /// Requires a model Supplier to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewSupplierCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _suprepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify Supplier based on Id
        /// Requires a model Supplier to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifySupplier form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _suprepo.Update(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Delete Supplier based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _suprepo.Delete(id);
            return Ok();
        }

    }
}
