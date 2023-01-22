using AssetManagement.Data.Interfaces;
using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    public class TypeStatusController : ControllerBase
    {
        private ITypeStatusRepository _repo;

        public TypeStatusController(ITypeStatusRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("GetType")]
        public List<AssetType> GetAllAssetTypes()
        {
            return _repo.GetAllAssetTypes();
        }




        [HttpPost]
        [Route("PostType")]
        public void CreateAssetType(string description)
        {
            AssetType t = new AssetType();
            t.Description = description;

            _repo.CreateAssetType(t);
        }


        [HttpGet]
        [Route("GetStatus")]
        public List<Status> GetAllStatuses()
        {
            return _repo.GetAllStatuses();
        }


        [HttpPost]
        [Route("PostStatus")]
        public void CreateStatus(string description)
        {
            Status s = new Status();
            s.Description = description;

            _repo.CreateStatus(s);
        }


        [HttpGet]
        [Route("GetTransaction")]
        public List<Transaction?> GetAssetById(int Id)
        {
            return _repo.GetAssetById(Id);
        }


        [HttpPost]
        [Route("PostTransaction")]
        public void CreateTransaction(TransactionDTO transaction)
        {
            _repo.CreateTransaction(transaction);
        }

    }
}
