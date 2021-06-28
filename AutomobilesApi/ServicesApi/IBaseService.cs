using AutomobilesApi.Models.Response;
using System.Threading.Tasks;

namespace AutomobilesApi.ServicesApi
{
    public interface IBaseService<T>
    {
        public Task<ExecutionResult> Create(T automobile);
        public Task<T> Read(long id);
        public Task<ExecutionResult> Update(T automobile);
        public Task Delete(long id);
        public Task<ListResult<T>> ReadAll();
    }
}
