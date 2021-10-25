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
    public class ItemPhotoPropertySetRepository : IItemPhotoPropertySetRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ItemPhotoPropertySetRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateItemPhotoPropertySet(ItemPhotoPropertySetDTO itemPhotoPropertySetDTO)
        {
            try
            {
                var itemPhotoPropertySet = _mapper.Map<ItemPhotoPropertySetDTO, ItemPhotoPropertySet>(itemPhotoPropertySetDTO);
                await _db.ItemPhotoPropertySets.AddAsync(itemPhotoPropertySet);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeleteItemPhotoPropertySetById(int id)
        {
            try
            {
                var itemPhotoPropertySet = await _db.ItemPhotoPropertySets.FindAsync(id);

                if (itemPhotoPropertySet is not null)
                {
                    _db.ItemPhotoPropertySets.Remove(itemPhotoPropertySet);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ItemPhotoPropertySetDTO> GetItemPhotoPropertySetById(int id)
        {
            return _mapper.Map<ItemPhotoPropertySet, ItemPhotoPropertySetDTO>(await _db.ItemPhotoPropertySets.FindAsync(id));
        }

        public async Task<IEnumerable<ItemPhotoPropertySetDTO>> GetlAllITemPhotoPropertySet()
        {
            return _mapper.Map<IEnumerable<ItemPhotoPropertySet>, IEnumerable<ItemPhotoPropertySetDTO>>(await _db.ItemPhotoPropertySets.ToListAsync());
        }

        public async Task<ItemPhotoPropertySetDTO> UpdateItemPhotoPropertySet(int id, ItemPhotoPropertySetDTO itemPhotoPropertySetDTO)
        {
            try
            {
                if (id == itemPhotoPropertySetDTO.Id)
                {
                    var itemPhotoPropertySet = await _db.ItemPhotoPropertySets.FindAsync(id);
                    var updatedItemPhotoPropertySet = _mapper.Map<ItemPhotoPropertySetDTO, ItemPhotoPropertySet>(itemPhotoPropertySetDTO, itemPhotoPropertySet);

                    var resultedUpdateItemPhotoPropertySet = _db.ItemPhotoPropertySets.Update(updatedItemPhotoPropertySet).Entity;

                    await _db.SaveChangesAsync();

                    return _mapper.Map<ItemPhotoPropertySet, ItemPhotoPropertySetDTO>(resultedUpdateItemPhotoPropertySet);
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
