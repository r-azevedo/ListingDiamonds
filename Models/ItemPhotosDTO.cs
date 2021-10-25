using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemPhotosDTO
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int TypeId { get; set; }
        public string FileName { get; set; }
        public int? Position { get; set; }
        public string Alt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? IsActive { get; set; }

        
        public ItemsDTO Item { get; set; }
        public TypesDTO Types { get; set; }
    }
}
