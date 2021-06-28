using AutomobilesApi.Models.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomobilesApi.Models.Database
{
    public class Dealer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public Uri Url { get; set; }

        public List<Automobile> Automobiles { get; set; }


        /// <summary>
        /// Default database constructor
        /// </summary>
        public Dealer() { }

        public Dealer(long id, string url)
        {
            Id = id;
            Url = new Uri(url);
        }

        public Dealer(DealerView view)
        {
            Id = view.Id;
            Url = view.Url;
        }
    }
}
