using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Created { get; set; }
        public int AssetId { get; set; }
        public string Comment { get; set; }


    }
}
