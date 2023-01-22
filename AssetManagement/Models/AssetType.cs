using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class AssetType
    {
        public int AssetTypeId { get; set; }
        public string Description { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
