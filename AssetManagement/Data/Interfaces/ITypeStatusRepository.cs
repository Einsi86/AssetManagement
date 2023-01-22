using AssetManagement.Models;


namespace AssetManagement.Data.Interfaces
{
    public interface ITypeStatusRepository
    {
        void CreateAssetType(AssetType assetType);
        List<AssetType> GetAllAssetTypes();
        List<Status> GetAllStatuses();
        void CreateStatus(Status status);
        List<Transaction?> GetAssetById(int id);
        void CreateTransaction(TransactionDTO transaction);
    }
}
