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
    public class TypesController : ControllerBase
    {
        private readonly ITypesRepository _typesRepository;

        public TypesController(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        [HttpGet]
        [Route("GetTypes")]
        public async Task<IEnumerable<TypesDTO>> GetTypes(int? id = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                TypesDTO type = await _typesRepository.GetTypesById(id.Value);

                if (type is not null)
                {
                    List<TypesDTO> types = new List<TypesDTO>();
                    types.Add(type);
                    return types;
                }
            }
            else
            {
                return await _typesRepository.GetlAllTypes();
            }
            return null;
        }

    }
}
