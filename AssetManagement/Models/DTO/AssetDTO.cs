using System.Text.Json.Serialization;

namespace AssetManagement.Models.DTO
{
    public class AssetDTO
    {

        public int AssetId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int AssetTypeId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string AssetType { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public DateTime Created { get; set; }
    }
}
