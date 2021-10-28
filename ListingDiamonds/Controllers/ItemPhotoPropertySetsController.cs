using Business.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDiamonds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPhotoPropertySetsController : ControllerBase
    {
        private readonly IItemPhotoPropertySetRepository _itemPhotoPropertySetRepository;

        public ItemPhotoPropertySetsController(IItemPhotoPropertySetRepository itemPhotoPropertySetRepository)
        {
            _itemPhotoPropertySetRepository = itemPhotoPropertySetRepository;
        }

        [HttpGet]
        [Route("GetItemPhotoPropertySet")]
        public async Task<IEnumerable<ItemPhotoPropertySetDTO>> GetItemPhotoPropertySet(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                ItemPhotoPropertySetDTO itemPhotoPropertySet = await _itemPhotoPropertySetRepository.GetItemPhotoPropertySetById(id.Value);

                if (itemPhotoPropertySet is not null)
                {
                    List<ItemPhotoPropertySetDTO> itemPhotoPropertySets = new List<ItemPhotoPropertySetDTO>();
                    itemPhotoPropertySets.Add(itemPhotoPropertySet);
                    return itemPhotoPropertySets;
                }
            }
            else
            {
                return await _itemPhotoPropertySetRepository.GetlAllITemPhotoPropertySet();
            }
            return null;
        }
    }
}
