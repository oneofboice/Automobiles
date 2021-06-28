using AutomobilesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobilesApi.ServicesApi
{
    public interface IBodyService
    {
        Task<IEnumerable<BodyType>> ReadAll();
    }
}