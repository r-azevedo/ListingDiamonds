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
    public class TypesRepository : ITypesRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TypesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateTypesSet(TypesDTO typesDTO)
        {
            try
            {
                var type = _mapper.Map<TypesDTO, Types>(typesDTO);
                await _db.Types.AddAsync(type);

                return await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeleteTypesById(int id)
        {
            try
            {
                var type = await _db.Types.FindAsync(id);

                if(type is not null)
                {
                    _db.Types.Remove(type);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<TypesDTO>> GetlAllTypesSet()
        {
            return _mapper.Map<IEnumerable<Types>, IEnumerable<TypesDTO>>(await _db.Types.ToListAsync());
        }

        public async Task<TypesDTO> GetTypesById(int id)
        {
            return _mapper.Map<Types, TypesDTO>(await _db.Types.FindAsync(id));
        }

        public async Task<TypesDTO> UpdateTypesSet(int id, TypesDTO typesDTO)
        {
            try
            {
                if (id == typesDTO.Id)
                {
                    var types = await _db.Types.FindAsync(id);
                    var updatedType = _mapper.Map<TypesDTO, Types>(typesDTO, types); /*Map parameter typesDTO to already existing type from database*/

                    var resultedUpdateType = _db.Types.Update(updatedType).Entity; /*Get updated entity*/

                    await _db.SaveChangesAsync();

                    return _mapper.Map<Types, TypesDTO>(resultedUpdateType);
                }

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
