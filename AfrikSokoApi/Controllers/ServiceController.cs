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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _servrepo;

        public ServiceController(IServiceRepository servrepo)
        {
            _servrepo = servrepo;
        }


        /// <summary>
        /// Retrieve The Complete List of Services
        /// </summary>
        /// <response code="200">Return The List of Services/response>
        /// <response code="400">There is an error on server side</response>
        /// <remarks>Accessible only if user connected</remarks> 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_servrepo.GetAll().Select(x => x.ToApi()));
        }

        /// <summary>
        /// Allow to Add a New Service
        /// Requires a model Service to Dal
        /// </summary>
        /// <response code="200">Creation Ok</response>
        /// <response code="400">There is an error on server side</response>
        /// <returns>A message in the event of error</returns>
        /// <remarks>Accessible only if Admin role user</remarks>        
        [HttpPost]
        public IActionResult Create(NewServiceCreate form)
        {
            if (!ModelState.IsValid) return BadRequest();

            _servrepo.Create(form.ProToDal());
            return Ok();

        }
    }
}
