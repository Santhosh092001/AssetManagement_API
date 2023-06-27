using AssetManagement.DBContext;
using AssetManagement.Dto;
using AssetManagement.IRepository;
using AssetManagement.Models;

namespace AssetManagement.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AMDbcontext _context;
        public AssetRepository(AMDbcontext amdContext)
        {
            _context = amdContext;
        }

        public bool AddAsset(Asset newasset)
        {
            try
            {
                var asset = _context.Assets.FirstOrDefault(x => x.Name == newasset.Name);
                if (asset == null)
                {
                    _context.Assets.Add(newasset);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Asset> getAsset()
        {
            return _context.Assets.ToList();
        }

        public bool updateAsset(Asset newasset)
        {
            _context.Assets.Update(newasset);
            _context.SaveChanges();
            return true;
            /*            var updateAsset = _context.Assets.FirstOrDefault(x => x.Id == newasset.Id);
                        if (updateAsset != null)
                        {
                            updateAsset.Name = newasset.Name;
                            updateAsset.Description = newasset.Description;
                            updateAsset.Type = newasset.Type;
                            updateAsset.Status = newasset.Status;
                            _context.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }*/
        }


        public List<string> getOpenAsset()
        {
            var openAsset = _context.Assets.Where(x => x.Status == "Open").ToList();
            var assetList = new List<string>();
            if (openAsset.Count > 0)
            {
                foreach (Asset asset in openAsset)
                {
                    assetList.Add(asset.Name);
                }
                return assetList.ToList();
            }
            else
            {
                return null;
            }
        }


        public int addDocument(Document document)
        {
            if (document != null)
            {
                _context.Documents.Add(document);
                _context.SaveChanges();
                return document.Id;
            }
            else
                return 0;
        }

        public bool assignedAsset(UserAssetMapDto userasset)
        {
            var assignAsset = new UserAssetMap();
            var user = _context.Users.FirstOrDefault(x => x.FirstName + ' ' + x.LastName == userasset.AssignedTo);
            var asset = _context.Assets.FirstOrDefault(x => x.Name == userasset.Asset);
            if (user != null && asset != null)
            {
                assignAsset.UserId = user.Id;
                assignAsset.AssetId = asset.Id;
                assignAsset.AssignedOn = userasset.AssignedOn;
                assignAsset.AssignedBy = userasset.AssignedBy;
                assignAsset.DocumentId = userasset.DocumentId;
                assignAsset.User = null;
                assignAsset.Document = null;
                assignAsset.Asset = null;
                _context.UserAssetMaps.Add(assignAsset);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}
