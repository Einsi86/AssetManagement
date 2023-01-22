namespace AssetManagement.Models.DTO
{
    public class AssetPostDTO
    {
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int AssetTypeId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
    }
}
