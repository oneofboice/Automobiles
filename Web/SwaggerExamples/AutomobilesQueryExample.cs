using AutomobilesApi.Models.Database;
using AutomobilesApi.Models.Queries;
using Swashbuckle.AspNetCore.Filters;

namespace Web.SwaggerExamples
{
    public class AutomobilesQueryExample : IExamplesProvider<AutomobilesQuery>
    {
        public AutomobilesQuery GetExamples()
        {
            return new AutomobilesQuery(1, 5, new SortingConfiguration(nameof(Automobile.CreationDate), SortingDirection.Desc));
        }
    }
}
