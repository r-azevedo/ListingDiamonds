using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IItemPhotosRepository
    {
        public Task<int> CreateItemPhoto(ItemPhotosDTO itemPhotoDTO);
        public Task<int> DeleteItemPhotoById(int id);
        public Task<ItemPhotosDTO> GetItemPhotoById(int id);
        public Task<ItemPhotosDTO> UpdateItemPhoto(int id, ItemPhotosDTO itemPhotoDTO);
        public Task<IEnumerable<ItemPhotosDTO>> GetlAllItemPhotos();
    }
}
