using AutomobilesApi.Models.Database;
using System;

namespace AutomobilesApi.Models.Views
{
    public class AutomobileView
    {
        public long Id { get; set; }

        public ModelView Model { get; set; }

        public byte[] Image { get; set; }

        public BodyType Body { get; set; }

        public int SeatsCount { get; set; }

        public DealerView Dealer { get; set; }

        public AutomobileView() { }

        public AutomobileView(Automobile automobile)
        {
            Id = automobile.Id;
            Image = automobile.Image;
            SeatsCount = automobile.SeatsCount;
            Dealer = automobile.Dealer == null ? null : new DealerView(automobile.Dealer);
            Body = automobile.Body == null ? BodyType.Undefined : automobile.Body.Name;
            Model = automobile.Model == null ? null : new ModelView(automobile.Model);
        }
    }
}
