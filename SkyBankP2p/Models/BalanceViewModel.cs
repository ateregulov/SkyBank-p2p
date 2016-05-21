using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class BalanceViewModel
    {
        public List<Item> Items { get; set; }

        public BalanceViewModel()
        {
            Items = new List<Item>();
        }

        public class Item
        {
            public string Name { get; set; }
            public decimal StartAmount { get; set; }
            public decimal EndAmount { get; set; }
        }
    }
}