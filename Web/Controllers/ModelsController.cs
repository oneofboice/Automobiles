using AutomobilesApi.Models.Response;
using AutomobilesApi.Models.Views;
using AutomobilesApi.ServicesApi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ModelsController : Controller
    {
        private IBaseService<ModelView> _baseService;
        public ModelsController(IBaseService<ModelView> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ListResult<ModelView>> ReadAll()
        {
            return await _baseService.ReadAll();
        }
    }
}
