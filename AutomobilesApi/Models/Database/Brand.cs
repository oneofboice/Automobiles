using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomobilesApi.Models.Database
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Model> Models { get; set; }

        /// <summary>
        /// Default database constructor
        /// </summary>
        public Brand() { }

        public Brand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
