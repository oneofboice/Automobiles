using AutomobilesApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobilesApi.RepositoriesApi
{
    public interface IBaseRepository<T>
    {
        public Task<ExecutionResult> Create(T automobile);
        public Task<T> Read(long id);
        public Task<ExecutionResult> Update(T automobile);
        public Task Delete(long id);
        public Task<List<T>> ReadAll();
    }
}
