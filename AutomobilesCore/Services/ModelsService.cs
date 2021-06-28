using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Response;
using AutomobilesApi.Models.Views;
using AutomobilesApi.RepositoriesApi;
using AutomobilesApi.ServicesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobilesCore.Services
{
    public class ModelsService : IBaseService<ModelView>
    {
        private readonly IBaseRepository<Model> _modelRepository;
        public ModelsService(IBaseRepository<Model> modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public Task<ExecutionResult> Create(ModelView automobile)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelView> Read(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResult<ModelView>> ReadAll()
        {
            var models = await _modelRepository.ReadAll();
            var result = models.Select(model => new ModelView(model));
            return new ListResult<ModelView>(models.Count, result);
        }

        public Task<ExecutionResult> Update(ModelView automobile)
        {
            throw new NotImplementedException();
        }
    }
}
