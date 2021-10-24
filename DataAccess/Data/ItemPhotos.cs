using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ItemPhotos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ItemId { get; set; }
        [Required]
        public int TypeId { get; set; }
        public string FileName { get; set; }
        public int Position { get; set; }
        public string Alt { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        [Required]
        public bool IsActive { get; set; }


        [ForeignKey("ItemId")]
        public Items Item{ get; set; }
        [ForeignKey("TypeId")]
        public Types Types { get; set; }
    }
}
