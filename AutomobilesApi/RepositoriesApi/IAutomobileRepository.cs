using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Queries;
using AutomobilesApi.Models.Response;
using System.Threading.Tasks;

namespace AutomobilesApi.RepositoriesApi
{
    public interface IAutomobileRepository
    {
        public Task<ListResult<Automobile>> ReadAll(AutomobilesQuery query);
    }
}
