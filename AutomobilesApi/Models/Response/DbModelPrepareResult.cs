namespace AutomobilesApi.Models.Response
{
    public class DbModelPrepareResult<T> : ExecutionResult
    {
        public T Model { get; }

        public DbModelPrepareResult(T model, bool success = true, string message = null)
            :base(success, message)
        {
            Model = model;
        }
        public DbModelPrepareResult(ExecutionResult result)
            : base(result.Success, result.Message)
        {
        }
    }
}
