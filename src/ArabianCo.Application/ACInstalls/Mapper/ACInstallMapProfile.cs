using ArabianCo.ACInstalls.DTO;
using ArabianCo.Domain.ACInstalls;
using ArabianCo.Domain.MaintenanceRequests;
using ArabianCo.MaintenanceRequests.Dto;
using AutoMapper;

namespace ArabianCo.ACInstalls.Mapper
{
	internal class ACInstallMapProfile:Profile
	{
		public ACInstallMapProfile()
		{
                        CreateMap<CreateACInstallDto, ACInstall>()
                                .ForMember(dest => dest.AddressId, opt => opt.Ignore())
                                .ForMember(dest => dest.Address, opt => opt.Ignore());
                        CreateMap<UpdateACInstallDto, ACInstall>()
                                .ForMember(dest => dest.AddressId, opt => opt.Ignore())
                                .ForMember(dest => dest.Address, opt => opt.Ignore());
                        CreateMap<ACInstall, LiteACInstallDto>()
                                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Address.Area))
                                .ForMember(dest => dest.OtherNotes, opt => opt.MapFrom(src => src.Address.OtherNotes));
                        CreateMap<ACInstall, ACInstallDto>()
                                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Address.Area))
                                .ForMember(dest => dest.OtherNotes, opt => opt.MapFrom(src => src.Address.OtherNotes))
                                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));
                }
        }
}
