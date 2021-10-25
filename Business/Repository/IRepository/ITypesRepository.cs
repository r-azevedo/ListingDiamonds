using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ITypesRepository
    {
        public Task<int> CreateTypesSet(TypesDTO typesDTO);
        public Task<int> DeleteTypesById(int id);
        public Task<TypesDTO> GetTypesById(int id);
        public Task<TypesDTO> UpdateTypesSet(int id, TypesDTO typesDTO);
        public Task<IEnumerable<TypesDTO>> GetlAllTypesSet();
    }
}
