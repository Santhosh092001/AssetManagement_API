using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class UserRoleMap
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
