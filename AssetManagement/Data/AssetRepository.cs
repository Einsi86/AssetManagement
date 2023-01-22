using AssetManagement.Data.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTO;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AssetManagement.Data

{
    public class AssetRepository : IAssetRepository
    {
        private AssetDbContext _dbContext;

        public AssetRepository()
        {
            _dbContext = new AssetDbContext();
        }


        public List<AssetDTO> GetAllAssets(string? description, string? assettype, string? status, string? user)
        {
            description = description ?? string.Empty;
            assettype = assettype ?? string.Empty;
            status = status ?? string.Empty;
            user= user ?? string.Empty;


            var query = _dbContext.Assets.
                Include(t => t.AssetType).
                Include(s => s.Status).
                Include(u => u.User);  


            List<AssetDTO> assetreturnItem = new List<AssetDTO>();

            foreach (var i in query)
            {
                AssetDTO al = new AssetDTO();

                al.AssetId = i.AssetId;
                al.Description = i.Description ;
                al.LongDescription = i.LongDescription  ;
                al.AssetTypeId = i.AssetTypeId ;
                al.StatusId = i.StatusId ;
                al.UserId = i.UserId ;
                al.AssetType = i.AssetType.Description ;
                al.Status = i.Status.Description ;
                al.User = i.User.Name ;
                al.Created = i.Created;

                assetreturnItem.Add(al);
                
            }
            var result = from item in assetreturnItem
                         where item.Description.ToLower().Contains( description.ToLower() )
                         && item.AssetType.ToLower().Contains( assettype.ToLower() )
                         && item.Status.ToLower().Contains(status.ToLower())
                         && item.User.ToLower().Contains ( user.ToLower())
                         select item;

            return result.ToList();

        }



        public Asset? GetAssetById(int id)
        {          

            return _dbContext.Assets.Where(t => t.AssetId == id).FirstOrDefault();
        }

        public void CreateAsset(AssetPostDTO asset)
        {
            Asset a = new Asset();

            a.Description = asset.Description;
            a.LongDescription = asset.LongDescription;
            a.AssetTypeId = asset.AssetTypeId;
            a.StatusId = asset.StatusId;
            a.UserId = asset.UserId;
            a.Created = DateTime.Now;

            _dbContext.Assets.Add(a);
            _dbContext.SaveChanges();
        }

        public bool DeleteAsset(Asset asset)
        {

            try
            {
                _dbContext.Assets.Remove(asset);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }


        }

        public Asset? UpdateAsset(int id, AssetDTO assetFromBody)
        {
            
            
            Asset? assetFromDB = GetAssetById(id);

            if (assetFromDB == null)
            {
                return null;
            }

            assetFromDB.LongDescription = assetFromBody.LongDescription;
            assetFromDB.Description = assetFromBody.Description;
            assetFromDB.StatusId = assetFromBody.StatusId;
            assetFromDB.AssetTypeId = assetFromBody.AssetTypeId;
            assetFromDB.UserId = assetFromBody.UserId;


            _dbContext.SaveChanges();


            return assetFromDB;
        }
    }

}