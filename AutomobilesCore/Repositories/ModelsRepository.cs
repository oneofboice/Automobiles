using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Response;
using AutomobilesApi.RepositoriesApi;
using AutomobilesCore.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobilesCore.Repositories
{
    public class ModelsRepository : IBaseRepository<Model>
    {
        private readonly AutomobilesDbContext _dbCtx;
        public ModelsRepository(AutomobilesDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<ExecutionResult> Create(Model automobile)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Model> Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Model>> ReadAll()
        {
            return await _dbCtx.Models
                .Include(model => model.Brand)
                .ToListAsync();
        }

        public Task<ExecutionResult> Update(Model automobile)
        {
            throw new System.NotImplementedException();
        }
    }
}
