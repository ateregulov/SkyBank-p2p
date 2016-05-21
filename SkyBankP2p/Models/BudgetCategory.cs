using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class BudgetCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsParent { get; set; }
        public bool IsPositive { get; set; }
    }
}