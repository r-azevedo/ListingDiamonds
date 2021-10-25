using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TypePropertySetDTO
    {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public int PropertyId { get; set; }


        public PropertiesDTO Properties { get; set; }
        public TypesDTO Types { get; set; }
    }
}
