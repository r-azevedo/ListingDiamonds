using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class TypePropertySetRepository : ITypePropertySetRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TypePropertySetRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateTypePropertySet(TypePropertySetDTO typePropertySetDTO)
        {
            try
            {
                var typePropertySet = _mapper.Map<TypePropertySetDTO, TypePropertySet>(typePropertySetDTO);
                await _db.TypePropertySets.AddAsync(typePropertySet);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeleteTypePropertySetById(int id)
        {
            try
            {
                var typePropertySet = await _db.TypePropertySets.FindAsync(id);

                if (typePropertySet is not null)
                {
                    _db.TypePropertySets.Remove(typePropertySet);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TypePropertySetDTO>> GetlAllTypePropertySet()
        {
            return _mapper.Map<IEnumerable<TypePropertySet>, IEnumerable<TypePropertySetDTO>>(await _db.TypePropertySets.ToListAsync());
        }

        public async Task<TypePropertySetDTO> GetTypePropertySetById(int id)
        {
            return _mapper.Map<TypePropertySet, TypePropertySetDTO>(await _db.TypePropertySets.FindAsync(id));
        }

        public async Task<TypePropertySetDTO> UpdateTypePropertySet(int id, TypePropertySetDTO typePropertySetDTO)
        {
            try
            {
                if (id == typePropertySetDTO.Id)
                {
                    var typePropertySet = await _db.TypePropertySets.FindAsync(id);
                    var updatedTypePropertySet = _mapper.Map<TypePropertySetDTO, TypePropertySet>(typePropertySetDTO, typePropertySet);

                    var resultedUpdateTypePropertySet = _db.TypePropertySets.Update(typePropertySet).Entity;

                    await _db.SaveChangesAsync();

                    return _mapper.Map<TypePropertySet, TypePropertySetDTO>(resultedUpdateTypePropertySet);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
