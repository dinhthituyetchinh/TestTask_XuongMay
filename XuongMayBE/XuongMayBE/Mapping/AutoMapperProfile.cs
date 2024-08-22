using AutoMapper;
using XuongMayBE.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Mapping giữa ProductionLine và ProductionLineDTO
        CreateMap<ProductionLine, ProductionLineDTO>().ReverseMap();

        // Mapping giữa Task và TaskDTO
        CreateMap<Tasks, TaskDTO>().ReverseMap();
    }
}