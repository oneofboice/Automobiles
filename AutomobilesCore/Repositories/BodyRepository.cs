using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Response;
using AutomobilesApi.RepositoriesApi;
using AutomobilesCore.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobilesCore.Repositories
{
    public class BodyRepository : IBaseRepository<Body>
    {
        private readonly AutomobilesDbContext _dbCtx;
        public BodyRepository(AutomobilesDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<ExecutionResult> Create(Body automobile)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Body> Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Body>> ReadAll()
        {
            return await _dbCtx.Bodies
                .ToListAsync();
        }

        public Task<ExecutionResult> Update(Body automobile)
        {
            throw new System.NotImplementedException();
        }
    }
}
