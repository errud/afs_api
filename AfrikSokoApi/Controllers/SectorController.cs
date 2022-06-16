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
    public class SectorController : ControllerBase
    {
        private readonly ISectorRepository _secrepo;

        public SectorController(ISectorRepository secrepo)
        {
            _secrepo = secrepo;
        }


        /// <summary>
        /// Retrieve The Complete List of Sector
        /// </summary>
        /// <response code="200">Return The List of Categories</response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_secrepo.GetAll().Select(x => x.ToApi()));
        }
        
        /// <summary>
        /// Allow to Add a New Sector
        /// Requires a model Sector to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewSectorCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _secrepo.Create(form.ProToDal());
            return Ok();
                       
        }

    }
}
