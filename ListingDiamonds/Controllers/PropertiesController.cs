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
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesRepository _propertiesRepository;

        public PropertiesController(IPropertiesRepository propertiesRepository)
        {
            _propertiesRepository = propertiesRepository;
        }

        [HttpGet]
        [Route("GetProperties")]
        public async Task<IEnumerable<PropertiesDTO>> GetItemPhotoPropertySet(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                PropertiesDTO property = await _propertiesRepository.GetPropertyById(id.Value);

                if (property is not null)
                {
                    List<PropertiesDTO> properties = new List<PropertiesDTO>();
                    properties.Add(property);
                    return properties;
                }
            }
            else
            {
                return await _propertiesRepository.GetlAllProperties();
            }
            return null;
        }
    }
}
