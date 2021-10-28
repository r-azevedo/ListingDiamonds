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
    public class TypePropertySetController : ControllerBase
    {
        private readonly ITypePropertySetRepository _typePropertySetRepository;

        public TypePropertySetController(ITypePropertySetRepository typePropertySetRepository)
        {
            _typePropertySetRepository = typePropertySetRepository;
        }

        [HttpGet]
        [Route("TypePropertySet")]
        public async Task<IEnumerable<TypePropertySetDTO>> GetTypePropertySet(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                TypePropertySetDTO typePropertySet = await _typePropertySetRepository.GetTypePropertySetById(id.Value);

                if (typePropertySet is not null)
                {
                    List<TypePropertySetDTO> typePropertySets= new List<TypePropertySetDTO>();
                    typePropertySets.Add(typePropertySet);
                    return typePropertySets;
                }
            }
            else
            {
                return await _typePropertySetRepository.GetlAllTypePropertySet();
            }
            return null;
        }
    }
}
