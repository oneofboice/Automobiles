using System;
using System.ComponentModel.DataAnnotations;

namespace AutomobilesApi.Models.Database
{
    public class Automobile
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int ModelId { get; set; }
        [Required]
        public Model Model { get; set; }

        //[Required]
        public byte[] Image { get; set; } = new byte[] { };

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int BodyId { get; set; }
        [Required]
        public Body Body { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        public long? DealerId { get; set; }
        public Dealer Dealer { get; set; }

        /// <summary>
        /// Default database constructor
        /// </summary>
        public Automobile() { }

        public Automobile(long id, int modelId, int bodyId, int seatsCount, byte[] image)
        {
            Id = id;
            ModelId = modelId;
            BodyId = bodyId;
            SeatsCount = seatsCount;
            Image = image;
        }
        public Automobile(long id, int modelId, int bodyId, int seatsCount, byte[] image, long dealerId)
        {
            Id = id;
            ModelId = modelId;
            BodyId = bodyId;
            DealerId = dealerId;
            SeatsCount = seatsCount;
            Image = image;
        }
    }
}
