using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ITypePropertySetRepository
    {
        public Task<int> CreateTypePropertySet(TypePropertySetDTO typePropertySetDTO);
        public Task<int> DeleteTypePropertySetById(int id);
        public Task<TypePropertySetDTO> GetTypePropertySetById(int id);
        public Task<TypePropertySetDTO> UpdateTypePropertySet(int id, TypePropertySetDTO typePropertySetDTO);
        public Task<IEnumerable<TypePropertySetDTO>> GetlAllTypePropertySet();
    }
}
