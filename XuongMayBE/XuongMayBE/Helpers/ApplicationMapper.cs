using AutoMapper;
using XuongMayBE.Data;
using XuongMayBE.Models;

namespace XuongMayBE.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Map hai chiều
            CreateMap<Product, ProductModels>().ReverseMap();
            CreateMap<Category, CategoryModels>().ReverseMap();
        }
    }
}
