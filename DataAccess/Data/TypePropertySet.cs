using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TypePropertySet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MediaTypeId { get; set; }
        [Required]
        public int PropertyId { get; set; }


        [ForeignKey("PropertyId")]
        public Properties Properties { get; set; }
        [ForeignKey("MediaTypeId")]
        public Types Types { get; set; }
    }
}
