using AssetManagement.Data.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTO;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class TypeStatusRepository : ITypeStatusRepository
    {
        private AssetDbContext _dbContext;

        public TypeStatusRepository()
        {
            _dbContext = new AssetDbContext();
        }


        public List<AssetType> GetAllAssetTypes()
        {
            return _dbContext.AssetTypes.ToList();
        }


        public void CreateAssetType(AssetType assetType)
        {
            _dbContext.AssetTypes.Add(assetType);
            _dbContext.SaveChanges();
        }


        public List<Status> GetAllStatuses()
        {
            return _dbContext.Statuses.ToList();
        }


        public void CreateStatus(Status status)
        {
            _dbContext.Statuses.Add(status);
            _dbContext.SaveChanges();
        }


        public List<Transaction?> GetAssetById(int id)
        {

            return _dbContext.Transactions.Where(t => t.AssetId == id).ToList();
        }

        public void CreateTransaction(TransactionDTO transaction)
        {
            Transaction t = new Transaction();

            t.Comment = transaction.Comment;
            t.AssetId = transaction.AssetId;
            t.Created = DateTime.Now;

            _dbContext.Transactions.Add(t);
            _dbContext.SaveChanges();
        }

     
            

    }
}
