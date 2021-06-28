using AutomobilesApi.Models;
using AutomobilesApi.ServicesApi;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class BodyController : Controller
    {
        private IBodyService _bodyService;
        public BodyController(IBodyService bodyService)
        {
            _bodyService = bodyService;
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<IEnumerable<BodyType>> ReadAll()
        {
            return await _bodyService.ReadAll();
        }
    }
}
