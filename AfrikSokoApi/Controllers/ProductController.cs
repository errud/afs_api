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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository<DAL.Product, DAL.SupplyItem> _prorepo;
       

        public ProductController(IProductRepository<DAL.Product, DAL.SupplyItem> prorepo)
        {
            _prorepo = prorepo;
        }

        /// <summary>
        /// Retrieve The Complete List of Products
        /// </summary>
        /// <response code="200">Return The List of Products</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks>        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_prorepo.GetAll().Select(x => x.ProToApi()));
        }

        /*
        /// <summary>
        /// Broad View The List of Products
        /// </summary>
        /// <response code="200">View The List of Products</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>IEnumerable of Products with Items Supplied by Supplier</returns>
        /// <remarks>Accessible only if user connected</remarks>        
        [HttpGet]
        public IActionResult ViewAll()
        {
            return Ok(_prorepo.ViewAll().Select(x => x.ViewAllToApi()));
        }
        */

        /// <summary>
        /// Return the Product based on its Id
        /// Parameter type as integer
        /// </summary>
        /// <response code="200">Return one product</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>Object type is product</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_prorepo.GetById(id).ProToApi());
        }

        /// <summary>
        /// Allow to Register a New Product
        /// Requires a model Product to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewProductCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _prorepo.Create(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Update or Modify Product based on Id
        /// Requires a model Product to Dal
        /// </summary>
        /// <response code="200">Update Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpPut]
        public IActionResult Update(ModifyProduct form)
        {
            if (!ModelState.IsValid) return BadRequest();
   
            _prorepo.Update(form.ProToDal());
            return Ok();
        }

        /// <summary>
        /// Delete Product based on Id
        /// </summary>
        /// <response code="200">Delete Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prorepo.Delete(id);
            return Ok();
        }






    }


















}
