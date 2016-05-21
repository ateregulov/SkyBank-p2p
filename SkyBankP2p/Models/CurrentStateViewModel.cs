using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class CurrentStateViewModel
    {
        public List<Item> Items { get; set; }

        public class Item
        {
            public string BudgetCategory { get; set; }
            public decimal FactAmount { get; set; }
            public decimal PlanAmount { get; set; }
            public decimal Difference
            {
                get
                {
                    return PlanAmount - FactAmount;
                }
                set { }
            }

        }
    }
}