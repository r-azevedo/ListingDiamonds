using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IItemsRepository
    {
        public Task<int> CreateItem(ItemsDTO itemDTO);
        public Task<int> DeleteItemById(int id);
        public Task<ItemsDTO> GetItemById(int id);
        public Task<ItemsDTO> UpdateItem(int id, ItemsDTO itemDTO);
        public Task<IEnumerable<ItemsDTO>> GetlAllItems();
    }
}
