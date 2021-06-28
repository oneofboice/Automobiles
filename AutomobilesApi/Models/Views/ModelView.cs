using AutomobilesApi.Models.Database;

namespace AutomobilesApi.Models.Views
{
    public class ModelView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public ModelView() { }

        public ModelView(Model model)
        {
            Id = model.Id;
            Name = model.Name;
            BrandName = model.Brand.Name;
        }
    }
}
