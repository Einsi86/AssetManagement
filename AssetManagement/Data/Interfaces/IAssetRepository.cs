using AssetManagement.Models;
using AssetManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Data.Interfaces
{
    public interface IAssetRepository
    {
        List<AssetDTO> GetAllAssets( string description, string assettypeid, string statusid, string userid);

        void CreateAsset(AssetPostDTO asset);

        bool DeleteAsset(Asset asset);

        Asset? GetAssetById(int id);

        Asset UpdateAsset(int id, AssetDTO assetFromBody);
    }
}
