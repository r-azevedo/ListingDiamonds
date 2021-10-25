using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemPhotoPropertySetDTO
    {
        public int Id { get; set; }
        public int ItemPhotoId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        
        public ItemPhotosDTO ItemPhotos { get; set; }
        public PropertiesDTO Properties { get; set; }
    }
}
