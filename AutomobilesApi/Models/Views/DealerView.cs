using AutomobilesApi.Models.Database;
using System;

namespace AutomobilesApi.Models.Views
{
    public class DealerView
    {
        public long Id { get; set; }

        public Uri Url { get; set; }

        public DealerView() { }

        public DealerView(Dealer dealer)
        {
            Id = dealer.Id;
            Url = dealer.Url;
        }
    }
}
