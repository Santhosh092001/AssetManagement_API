using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string? Filename { get; set; }
        public long Filesize { get; set; }
        public string? Filetype { get; set; }
        public byte[]? Filecontent { get; set; }
    }
}
