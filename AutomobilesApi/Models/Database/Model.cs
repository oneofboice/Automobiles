using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobilesApi.Models.Database
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Name { get; set; }

        public List<Automobile> Automobiles { get; set; }


        /// <summary>
        /// Default database constructor
        /// </summary>
        public Model() { }

        public Model(int id, int brandId, string name)
        {
            Id = id;
            BrandId = brandId;
            Name = name;
        }
    }
}
