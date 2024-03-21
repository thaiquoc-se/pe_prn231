using API.DTO;
using API.ViewModel;
using AutoMapper;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<SilverJewelry, SilverJewelryDTO>().ForMember(dest => dest.CategoryName, opt => opt
                                            .MapFrom(src => src.Category!.CategoryName)).ReverseMap();
            CreateMap<SilverJewelry, SilverJewelryCreate>().ReverseMap();
        }
    }
}
