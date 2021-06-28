using AutomobilesApi.Models.Queries;
using AutomobilesApi.Models.Response;
using AutomobilesApi.Models.Views;
using System.Threading.Tasks;

namespace AutomobilesApi.ServicesApi
{
    public interface IAutomobileService
    {
        public Task<ListResult<AutomobileView>> ReadAll(AutomobilesQuery query);
    }
}
