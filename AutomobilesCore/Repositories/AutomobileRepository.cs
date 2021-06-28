using AutomobilesApi;
using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Queries;
using AutomobilesApi.Models.Response;
using AutomobilesApi.RepositoriesApi;
using AutomobilesCore.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobilesCore.Repositories
{
    public class AutomobileRepository : IAutomobileRepository, IBaseRepository<Automobile>
    {
        private readonly AutomobilesDbContext _dbCtx;
        public AutomobileRepository(AutomobilesDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<ExecutionResult> Create(Automobile automobile)
        {
            if (IsDuplicate(automobile))
            {
                return new ExecutionResult(false, Errors.ExistedObjectError);
            }
            await _dbCtx.Automobiles.AddAsync(automobile);
            await _dbCtx.SaveChangesAsync();
            return new ExecutionResult();
        }

        public Task<Automobile> Read(long id)
        {
            return _dbCtx.Automobiles
                .Include(automobile => automobile.Model)
                .Include(automobile => automobile.Model.Brand)
                .Include(automobile => automobile.Body)
                .Include(automobile => automobile.Dealer)
                .FirstOrDefaultAsync(automobile => automobile.Id == id);
        }

        public Task<List<Automobile>> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ListResult<Automobile>> ReadAll(AutomobilesQuery query)
        {
            var automobiles = GetSortedAutomobilesList(query);
            var result = await automobiles
                .Skip((query.Page - 1) * query.Size)
                .Take(query.Size)
                .Include(automobile => automobile.Model)
                .Include(automobile => automobile.Model.Brand)
                .Include(automobile => automobile.Body)
                .Include(automobile => automobile.Dealer)
                .ToListAsync();
            return new ListResult<Automobile>(automobiles.Count(), result);
        }

        public async Task<ExecutionResult> Update(Automobile automobile)
        {
            if (IsDuplicate(automobile))
            {
                return new ExecutionResult(false, Errors.ExistedObjectError);
            }
            _dbCtx.Automobiles.Update(automobile);
            await _dbCtx.SaveChangesAsync();
            return new ExecutionResult();
        }

        public async Task Delete(long id)
        {
            var automobile = await _dbCtx.Automobiles.FindAsync(id);
            if (automobile != null)
            {
                _dbCtx.Automobiles.Remove(automobile);
                await _dbCtx.SaveChangesAsync();
            }
        }


        private bool IsDuplicate(Automobile automobile)
        {
            var existed = _dbCtx.Automobiles.FirstOrDefault(auto =>
                auto.Id != automobile.Id
                && auto.ModelId == automobile.ModelId
                && auto.BodyId == automobile.BodyId
                && auto.SeatsCount == automobile.SeatsCount);
            return existed != null;
        }

        private IOrderedQueryable<Automobile> GetSortedAutomobilesList(AutomobilesQuery query)
        {
            if (query.Sorting == null)
            {
                return _dbCtx.Automobiles
                    .OrderBy(automobile => automobile.CreationDate);
            }
            switch (query.Sorting.Direction)
            {
                case SortingDirection.Desc:
                {
                    return _dbCtx.Automobiles.OrderBy(e => EF.Property<object>(e, query.Sorting.Field));
                }
                default:
                {
                    return _dbCtx.Automobiles.OrderByDescending(e => EF.Property<object>(e, query.Sorting.Field));
                }
            }
        }
    }
}
