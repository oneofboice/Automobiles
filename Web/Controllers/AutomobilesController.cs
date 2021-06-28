using AutomobilesApi.Models.Queries;
using AutomobilesApi.Models.Response;
using AutomobilesApi.Models.Views;
using AutomobilesApi.ServicesApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using Web.SwaggerExamples;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AutomobilesController : Controller
    {
        private IBaseService<AutomobileView> _baseService;
        private IAutomobileService _automobileService;
        public AutomobilesController(IBaseService<AutomobileView> baseService,
            IAutomobileService automobileService)
        {
            _baseService = baseService;
            _automobileService = automobileService;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(AutomobilesQuery), typeof(AutomobilesQueryExample))]
        [Route("Create")]
        public async ValueTask<ExecutionResult> Create([FromBody] AutomobileView model)
        {
            return await _baseService.Create(model);
        }

        [HttpPost]
        [Route("Update")]
        public async ValueTask<ExecutionResult> Update([FromBody] AutomobileView model)
        {
            var result =  await _baseService.Update(model);
            return result;
        }

        [HttpGet]
        [Route("Read/{id}")]
        public async ValueTask<AutomobileView> Read(long id)
        {
            return await _baseService.Read(id);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(AutomobilesQuery), typeof(AutomobilesQueryExample))]
        [Route("ReadAll")]
        public async Task<ListResult<AutomobileView>> ReadAll([FromBody] AutomobilesQuery query)
        {
            return await _automobileService.ReadAll(query);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ExecutionResult> Delete(long id)
        {
            await _baseService.Delete(id);
            return new ExecutionResult();
        }
    }
}
