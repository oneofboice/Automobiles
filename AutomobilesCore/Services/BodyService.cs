using AutomobilesApi.Models;
using AutomobilesApi.Models.Database;
using AutomobilesApi.RepositoriesApi;
using AutomobilesApi.ServicesApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobilesCore.Services
{
    public class BodyService : IBodyService
    {
        private readonly IBaseRepository<Body> _bodyRepository;
        public BodyService(IBaseRepository<Body> bodyRepository)
        {
            _bodyRepository = bodyRepository;
        }

        public async Task<IEnumerable<BodyType>> ReadAll()
        {
            var automobilles = await _bodyRepository.ReadAll();
            return automobilles.Select(body => body.Name);
        }
    }
}
