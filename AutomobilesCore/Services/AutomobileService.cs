using AutomobilesApi;
using AutomobilesApi.Models;
using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Queries;
using AutomobilesApi.Models.Response;
using AutomobilesApi.Models.Views;
using AutomobilesApi.RepositoriesApi;
using AutomobilesApi.ServicesApi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobilesCore.Services
{
    public class AutomobileService : IBaseService<AutomobileView>, IAutomobileService
    {
        private const string _logMessageFormat = "{0} {1} {2}";
        private readonly IBaseRepository<Automobile> _baseRepository;
        private readonly IAutomobileRepository _automobileRepository;
        private ILogger<AutomobileService> _logger;
        public AutomobileService(IBaseRepository<Automobile> baseRepository,
            IAutomobileRepository automobileRepository,
            ILogger<AutomobileService> logger)
        {
            _baseRepository = baseRepository;
            _automobileRepository = automobileRepository;
            _logger = logger;
        }

        public async Task<ExecutionResult> Create(AutomobileView automobile)
        {
            if (automobile.Id > 0)
            {
                return new ExecutionResult(false, Errors.ExistedObjectError);
            }
            var preparationResult = Prepare(automobile);
            if (!preparationResult.Success)
            {
                return preparationResult;
            }
            var result =  await _baseRepository.Create(preparationResult.Model);
            var created = await _baseRepository.Read(preparationResult.Model.Id);
            _logger.LogInformation(_logMessageFormat, nameof(Create), created.Model.Brand.Name, created.Model.Name);
            return result;
        }

        public async Task Delete(long id)
        {
            var automobile = await _baseRepository.Read(id);
            await _baseRepository.Delete(id);
            _logger.LogInformation(_logMessageFormat, nameof(Delete), automobile.Model.Brand.Name, automobile.Model.Name);
        }

        public async Task<AutomobileView> Read(long id)
        {
            var automobile = await _baseRepository.Read(id);
            return new AutomobileView(automobile);
        }

        public Task<ListResult<AutomobileView>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ListResult<AutomobileView>> ReadAll(AutomobilesQuery query)
        {
            if (query == null)
            {
                return new ListResult<AutomobileView>(0, new List<AutomobileView>());
            }
            var listResult = await _automobileRepository.ReadAll(query);
            var result = listResult.Objects.Select(auto => new AutomobileView(auto));
            return new ListResult<AutomobileView>(listResult.TotalCount, result, query.Size);
        }

        public async Task<ExecutionResult> Update(AutomobileView automobile)
        {
            if (automobile.Id <= 0)
            {
                return new ExecutionResult(false, Errors.UnexistedObjectError);
            }
            var preparationResult = Prepare(automobile);
            if (!preparationResult.Success)
            {
                return preparationResult;
            }
            var result = await _baseRepository.Update(preparationResult.Model);
            var edited = await _baseRepository.Read(preparationResult.Model.Id);
            _logger.LogInformation(_logMessageFormat, nameof(Update), edited.Model.Brand.Name, edited.Model.Name);
            return result;
        }

        private DbModelPrepareResult<Automobile> Prepare(AutomobileView automobile)
        {
            var viewValidationResult = ValidateView(automobile);
            if (!viewValidationResult.Success)
            {
                return new DbModelPrepareResult<Automobile>(null, viewValidationResult.Success, viewValidationResult.Message);
            }
            Automobile dbAutomobile;
            if (automobile.Dealer == null || automobile.Dealer.Id <=0)
            {
                dbAutomobile = new Automobile(automobile.Id, automobile.Model.Id, (int)automobile.Body, automobile.SeatsCount, automobile.Image);
            }
            else
            {
                dbAutomobile = new Automobile(automobile.Id, automobile.Model.Id, (int)automobile.Body, automobile.SeatsCount, automobile.Image, automobile.Dealer.Id);
            }
            return new DbModelPrepareResult<Automobile>(dbAutomobile);
        }

        public ExecutionResult ValidateView(AutomobileView automobile)
        {
            /*if (automobile.Image == null)
            {
                return new ExecutionResult(false, string.Format(Errors.EmptyValueError, nameof(AutomobileView.Image)));
            }*/
            if (automobile.Body == BodyType.Undefined)
            {
                return new ExecutionResult(false, string.Format(Errors.EmptyValueError, nameof(AutomobileView.Body)));
            }
            if (automobile.SeatsCount <= 0)
            {
                return new ExecutionResult(false, string.Format(Errors.EmptyValueError, nameof(AutomobileView.SeatsCount)));
            }
            if (automobile.Model == null || automobile.Model.Id <= 0)
            {
                return new ExecutionResult(false, string.Format(Errors.EmptyValueError, nameof(AutomobileView.Model)));
            }
            return new ExecutionResult();
        }
    }
}
