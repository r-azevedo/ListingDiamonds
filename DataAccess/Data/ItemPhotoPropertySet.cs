using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ItemPhotoPropertySet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ItemPhotoId { get; set; }
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public string Value { get; set; }

        [ForeignKey("ItemPhotoId")]
        public ItemPhotos ItemPhotos { get; set; }
        [ForeignKey("PropertyId")]
        public Properties Properties { get; set; }
    }
}
