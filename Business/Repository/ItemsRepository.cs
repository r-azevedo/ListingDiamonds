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
    public class ItemsRepository : IItemsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ItemsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateItem(ItemsDTO itemDTO)
        {
            try
            {
                var item = _mapper.Map<ItemsDTO, Items>(itemDTO);
                await _db.Items.AddAsync(item);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeleteItemById(int id)
        {
            try
            {
                var item = await _db.Items.FindAsync(id);

                if (item is not null)
                {
                    _db.Items.Remove(item);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ItemsDTO> GetItemById(int id)
        {
            return _mapper.Map<Items, ItemsDTO>(await _db.Items.FindAsync(id));
        }

        public async Task<IEnumerable<ItemsDTO>> GetlAllItems()
        {
            return _mapper.Map<IEnumerable<Items>, IEnumerable<ItemsDTO>>(await _db.Items.ToListAsync());
        }

        public async Task<ItemsDTO> UpdateItem(int id, ItemsDTO itemDTO)
        {
            try
            {
                if (id == itemDTO.Id)
                {
                    var item = await _db.Items.FindAsync(id);
                    var updatedItem = _mapper.Map<ItemsDTO, Items>(itemDTO, item);

                    var resultedUpdateItem = _db.Items.Update(updatedItem).Entity;

                    await _db.SaveChangesAsync();

                    return _mapper.Map<Items, ItemsDTO>(resultedUpdateItem);
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
