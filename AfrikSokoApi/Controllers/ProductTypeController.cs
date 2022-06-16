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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _prodtrepo;

        public ProductTypeController(IProductTypeRepository prodtrepo)
        {
            _prodtrepo = prodtrepo;
        }

        /// <summary>
        /// Retrieve The Complete List of Product Types
        /// </summary>
        /// <response code="200">Return The List of Product Types</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_prodtrepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Allow to Add a New Product Type
        /// Requires a model ProductType to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewProductTypeCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _prodtrepo.Create(form.ProToDal());
            return Ok();

        }




    }

}
