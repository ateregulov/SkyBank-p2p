using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyBankP2p.Models
{
    public class OperationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public bool IsTransfer { get; set; }
    }
}