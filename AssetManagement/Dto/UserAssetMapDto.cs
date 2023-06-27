namespace AssetManagement.Dto
{
    public class UserAssetMapDto
    {
        public string Asset { get; set; }
        public string AssignedTo { get; set; }
        public DateTime AssignedOn { get; set; }
        public string AssignedBy { get; set; }
        public string Department { get; set; }
        public int DocumentId { get; set; }
    }
}
