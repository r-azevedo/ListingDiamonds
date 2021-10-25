using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IItemPhotoPropertySetRepository
    {
        public Task<int> CreateItemPhotoPropertySet(ItemPhotoPropertySetDTO itemPhotoPropertySetDTO);
        public Task<int> DeleteItemPhotoPropertySetById(int id);
        public Task<ItemPhotoPropertySetDTO> GetItemPhotoPropertySetById(int id);
        public Task<ItemPhotoPropertySetDTO> UpdateItemPhotoPropertySet(int id, ItemPhotoPropertySetDTO itemPhotoPropertySetDTO);
        public Task<IEnumerable<ItemPhotoPropertySetDTO>> GetlAllITemPhotoPropertySet();

    }
}
