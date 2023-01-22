using AssetManagement.Data;
using AssetManagement.Data.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api")]
    [ApiController]
    public class AssetController : ControllerBase
    {

        private IAssetRepository _repo;

        public AssetController(IAssetRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("GetAsset")]
        public List<AssetDTO> GetAllAssets( string? description, string? assettype, string? status, string? user)
        {
            return _repo.GetAllAssets(description, assettype, status, user);
        }

        [HttpPost]
        [Route("PostAsset")]
        public ActionResult CreateAsset(AssetPostDTO asset)
        {
            _repo.CreateAsset(asset);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAsset")]
        public ActionResult<bool> DeleteAsset(int id)
        {
            try
            {
                Asset? asset = _repo.GetAssetById(id);

                if (asset == null)
                {
                    return NotFound();
                }

                bool success = _repo.DeleteAsset(asset);

                if (!success)
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("PutAsset")]

        public IActionResult UpdateAsset(int id, AssetPostDTO assetFromBody2)
        {
            AssetDTO  assetFromBody = new AssetDTO();
            assetFromBody.AssetId = id;
            assetFromBody.Description = assetFromBody2.Description;
            assetFromBody.LongDescription = assetFromBody2.LongDescription;
            assetFromBody.AssetTypeId = assetFromBody2.AssetTypeId;
            assetFromBody.StatusId = assetFromBody2.StatusId;
            assetFromBody.UserId = assetFromBody2.UserId;





            if (id != assetFromBody.AssetId)
            {
                return BadRequest();
            }


            try
            {
                Asset? updated = _repo.UpdateAsset(id, assetFromBody);
                if (updated == null)
                {
                    return NotFound();
                }

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
