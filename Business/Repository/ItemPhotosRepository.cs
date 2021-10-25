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
    public class ItemPhotosRepository : IItemPhotosRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ItemPhotosRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateItemPhoto(ItemPhotosDTO itemPhotoDTO)
        {
            try
            {
                var itemPhotos = _mapper.Map<ItemPhotosDTO, ItemPhotos>(itemPhotoDTO);
                await _db.ItemPhotos.AddAsync(itemPhotos);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex; /*Always better to log the error*/
            }
        }

        public async Task<int> DeleteItemPhotoById(int id)
        {
            try
            {
                var itemPhotos = await _db.ItemPhotos.FindAsync(id);

                if (itemPhotos is not null)
                {
                    _db.ItemPhotos.Remove(itemPhotos);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ItemPhotosDTO> GetItemPhotoById(int id)
        {
            return _mapper.Map<ItemPhotos, ItemPhotosDTO>(await _db.ItemPhotos.FindAsync(id));
        }

        public async Task<IEnumerable<ItemPhotosDTO>> GetlAllItemPhotos()
        {
            return _mapper.Map<IEnumerable<ItemPhotos>, IEnumerable<ItemPhotosDTO>>(await _db.ItemPhotos.ToListAsync());
        }

        public async Task<ItemPhotosDTO> UpdateItemPhoto(int id, ItemPhotosDTO itemPhotoDTO)
        {
            try
            {
                if (id == itemPhotoDTO.Id)
                {
                    var itemPhotos = await _db.ItemPhotos.FindAsync(id);
                    var updatedItemPhoto = _mapper.Map<ItemPhotosDTO, ItemPhotos>(itemPhotoDTO, itemPhotos); 

                    var resultedUpdateItemPhoto = _db.ItemPhotos.Update(updatedItemPhoto).Entity;

                    await _db.SaveChangesAsync();

                    return _mapper.Map<ItemPhotos, ItemPhotosDTO>(resultedUpdateItemPhoto);
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
