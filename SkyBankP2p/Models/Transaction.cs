using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public int BudgetCategoryId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public string Comment { get; set; }
    }
}