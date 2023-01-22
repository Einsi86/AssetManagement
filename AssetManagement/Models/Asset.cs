using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Asset
    {
    
        public int AssetId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int AssetTypeId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }


        public AssetType AssetType { get; set; }    
        public User User { get; set; }
        public Status Status { get; set; }
        
    }
}
