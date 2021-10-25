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
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PropertiesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> CreateProperty(PropertiesDTO propertyDTO)
        {
            try
            {
                var property = _mapper.Map<PropertiesDTO, Properties>(propertyDTO);
                await _db.Properties.AddAsync(property);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeletePropertyById(int id)
        {
            try
            {
                var property = await _db.Properties.FindAsync(id);

                if (property is not null)
                {
                    _db.Properties.Remove(property);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PropertiesDTO>> GetlAllProperties()
        {
            return _mapper.Map<IEnumerable<Properties>, IEnumerable<PropertiesDTO>>(await _db.Properties.ToListAsync());
        }

        public async Task<PropertiesDTO> GetPropertyById(int id)
        {
            return _mapper.Map<Properties, PropertiesDTO>(await _db.Properties.FindAsync(id));
        }

        public async Task<PropertiesDTO> UpdateProperty(int id, PropertiesDTO propertyDTO)
        {
            try
            {
                if (id == propertyDTO.Id)
                {
                    var property = await _db.Properties.FindAsync(id);
                    var updatedProperty = _mapper.Map<PropertiesDTO, Properties>(propertyDTO, property);

                    var resultedUpdateProperty = _db.Properties.Update(updatedProperty).Entity;

                    await _db.SaveChangesAsync();

                    return _mapper.Map<Properties, PropertiesDTO>(resultedUpdateProperty);
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
