using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string UserRole { get; set; }
    }
}
