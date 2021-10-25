using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IPropertiesRepository
    {
        public Task<int> CreateProperty(PropertiesDTO propertyDTO);
        public Task<int> DeletePropertyById(int id);
        public Task<PropertiesDTO> GetPropertyById(int id);
        public Task<PropertiesDTO> UpdateProperty(int id, PropertiesDTO propertyDTO);
        public Task<IEnumerable<PropertiesDTO>> GetlAllProperties();
    }
}
