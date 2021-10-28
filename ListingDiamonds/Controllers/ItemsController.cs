using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListingDiamonds.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;


        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                ItemsDTO item = await _itemsRepository.GetItemById(id.Value);

                if (item is not null)
                {
                    List<ItemsDTO> items = new List<ItemsDTO>();
                    items.Add(item);
                    return Ok(item);
                }
            }
            else
            {
                var items = await _itemsRepository.GetlAllItems();
                return Ok(items);
            }
            return null;
        }
    }
}