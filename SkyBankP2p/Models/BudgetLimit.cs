using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class BudgetLimit
    {
        public int Id { get; set; }
        public int BudgetCategoryId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        public decimal Amount { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
    }
}