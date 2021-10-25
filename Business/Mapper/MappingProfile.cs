using AutoMapper;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            /*
             * AutoMapper helps with creating an easier way to transfer data from DTOs to database 
             * Mapping profile creates a relationship between the Data from database and DTOs for data transfer
             */

            CreateMap<ItemPhotoPropertySet, ItemPhotoPropertySetDTO>().ReverseMap();
            CreateMap<ItemPhotos, ItemPhotosDTO>().ReverseMap();
            CreateMap<Items, ItemsDTO>().ReverseMap();
            CreateMap<Properties, PropertiesDTO>().ReverseMap();
            CreateMap<TypePropertySet, TypePropertySetDTO>().ReverseMap();
            CreateMap<Types, TypesDTO>().ReverseMap();
        }
    }
}
