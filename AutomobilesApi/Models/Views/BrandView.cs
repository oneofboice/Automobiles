using AutomobilesApi.Models.Database;

namespace AutomobilesApi.Models.Views
{
    public class BrandView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BrandView() { }

        public BrandView(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
        }
    }
}
