using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobilesApi.Models.Response
{
    public class ExecutionResult
    {
        public bool Success { get; }
        public string Message { get; }

        public ExecutionResult(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
