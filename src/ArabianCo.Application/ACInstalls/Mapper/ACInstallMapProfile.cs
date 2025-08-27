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
			CreateMap<ACInstallAppService, ACInstall>();
			CreateMap<UpdateACInstallDto, ACInstall>();
			CreateMap<ACInstall, LiteACInstallDto>();
			CreateMap<ACInstall, ACInstallDto>()
				.ForMember(src => src.Area, destinationMember => destinationMember.Ignore());
		}
	}
}
