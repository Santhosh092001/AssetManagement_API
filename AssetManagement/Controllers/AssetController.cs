using AssetManagement.DBContext;
using AssetManagement.Dto;
using AssetManagement.IRepository;
using AssetManagement.Models;
using AssetManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class AssetController : ControllerBase
    {
        private readonly AMDbcontext _context;
        private readonly IAssetRepository _assetRpository;
        public AssetController(AMDbcontext context, IAssetRepository assetRepository)
        {
            _context = context;
            _assetRpository = assetRepository;
        }

        [HttpPost]
        public IActionResult AddAsset(Asset newasset)
        {
            var asset = _assetRpository.AddAsset(newasset);
            return Ok(asset);
        }

        [HttpGet]
        public IActionResult GetAsset()
        {
            var assset = _assetRpository.getAsset();
            return Ok(assset);
        }

        [HttpPut]
        public IActionResult UpdateAsset(Asset newasset)
        {
            var updateAsset = _assetRpository.updateAsset(newasset);
            return Ok(updateAsset);
        }

        [HttpGet]
        public IActionResult GetOpenAsset()
        {
            var asset = _assetRpository.getOpenAsset();
            if(asset != null)
                return Ok(asset);
            else
            {
                return NotFound("No Asset Available");
            }
        }


        [HttpPost]
        public IActionResult AssignedAsset()
        {
            Document document = new Document();
            var request = Request;
            IFormFileCollection formFiles = request.Form.Files;
            using (Stream st = formFiles[0].OpenReadStream())
            {
                using (BinaryReader br = new BinaryReader(st))
                {
                    byte[] bytes = br.ReadBytes((Int32)st.Length);
                    if (bytes.Length > 0)
                    {
                        document.Filename = formFiles[0].FileName;
                        document.Filetype = formFiles[0].ContentType;
                        document.Filesize = formFiles[0].Length;
                        document.Filecontent = bytes;
                    }
                }
            }
            if (document != null)
            {
                var id = _assetRpository.addDocument(document);
                if(id != 0)
                {
                    UserAssetMapDto userAsset = new UserAssetMapDto();
                    userAsset.DocumentId = id;
                    userAsset.Asset = request.Form["Asset"];
                    userAsset.AssignedBy = request.Form["AssignedBy"];
                    userAsset.AssignedTo = request.Form["AssignedTo"];
                    userAsset.AssignedOn = DateTime.Parse(request.Form["AssignedOn"]);
                    userAsset.Department = request.Form["Department"];
                    _assetRpository.assignedAsset(userAsset);
                    return Ok(new { message =  "Assign Successfully"});
                }
                else
                {
                    return BadRequest("Document not Uploaded");
                }
            }
            else
            {
                return BadRequest("Upload Document");
            }
        }

    }
}
