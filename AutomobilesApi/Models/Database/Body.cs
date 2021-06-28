using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobilesApi.Models.Database
{
    public class Body 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public BodyType Name { get; set; }

        public List<Automobile> Automobiles { get; set; }


        /// <summary>
        /// Default database constructor
        /// </summary>
        public Body() { }

        public Body(BodyType type)
        {
            Id = (int)type;
            Name = type;
        }
    }
}
