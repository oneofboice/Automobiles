using AutomobilesApi.Models.Database;

namespace AutomobilesApi.Models.Queries
{
    public class AutomobilesQuery
    {
        /// <summary>
        /// Sequential page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of page elements
        /// </summary>
        public int Size { get; set; } = 10;

        /// <summary>
        /// Configurate field and direction for sorting
        /// </summary>
        public SortingConfiguration Sorting { get; set; }

        public AutomobilesQuery() { }

        public AutomobilesQuery(int page)
        {
            Page = page;
            Sorting = new SortingConfiguration(nameof(Automobile.CreationDate));
        }

        public AutomobilesQuery(int page, int size, SortingConfiguration sorting)
        {
            Page = page;
            Size = size;
            Sorting = sorting;
        }
    }

    public class SortingConfiguration
    {
        public string Field { get; set; }

        public SortingDirection Direction { get; set; }

        public SortingConfiguration(string field, SortingDirection direction = SortingDirection.Asc)
        {
            Field = field;
            Direction = direction;
        }
    }

    public enum SortingDirection
    {
        Asc,
        Desc
    }
}
