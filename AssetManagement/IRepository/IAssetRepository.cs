using AssetManagement.Dto;
using AssetManagement.Models;

namespace AssetManagement.IRepository
{
    public interface IAssetRepository
    {
        public bool AddAsset(Asset newasset);
        public List<Asset> getAsset();
        public bool updateAsset(Asset newasset);
        public List<string> getOpenAsset();
        public int addDocument(Document document);
        public bool assignedAsset(UserAssetMapDto userasset);
    }
}
