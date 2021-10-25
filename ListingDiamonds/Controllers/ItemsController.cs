using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsController.Controllers
{
    
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;


        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        [Route("api/[controller]/GetItems/")]
        public async Task<IEnumerable<ItemsDTO>> GetItems(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                ItemsDTO item = await _itemsRepository.GetItemById(id.Value);

                if (item is not null)
                {
                    List<ItemsDTO> items = new List<ItemsDTO>();
                    items.Add(item);
                    return items;
                }
            }
            else
            {   
                return await _itemsRepository.GetlAllItems();
            }
            return null;
        }
    }
}