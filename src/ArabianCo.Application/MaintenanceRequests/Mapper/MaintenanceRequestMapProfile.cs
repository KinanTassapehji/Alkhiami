using ArabianCo.Domain.MaintenanceRequests;
using ArabianCo.MaintenanceRequests.Dto;
using AutoMapper;

namespace ArabianCo.MaintenanceRequests.Mapper;

internal class MaintenanceRequestMapProfile:Profile
{
    public MaintenanceRequestMapProfile()
    {
        CreateMap<CreateMaintenanceRequestDto, MaintenanceRequest>()
            .ForMember(dest => dest.AddressId, opt => opt.Ignore())
            .ForMember(dest => dest.Address, opt => opt.Ignore());
        CreateMap<UpdateMaintenanceRequestDto, MaintenanceRequest>()
            .ForMember(dest => dest.AddressId, opt => opt.Ignore())
            .ForMember(dest => dest.Address, opt => opt.Ignore());
        CreateMap<MaintenanceRequest, LiteMaintenanceRequestDto>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Address.Area))
            .ForMember(dest => dest.OtherNotes, opt => opt.MapFrom(src => src.Address.OtherNotes));
        CreateMap<MaintenanceRequest, MaintenanceRequestDto>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Address.Area))
            .ForMember(dest => dest.OtherNotes, opt => opt.MapFrom(src => src.Address.OtherNotes))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));
    }
}
