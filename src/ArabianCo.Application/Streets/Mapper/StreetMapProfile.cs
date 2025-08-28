using ArabianCo.Areas.Dto;
using ArabianCo.Domain.Areas;
using ArabianCo.Domain.Streets;
using ArabianCo.Streets.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets.Mapper
{
	public class StreetMapProfile : Profile
	{
		public StreetMapProfile()
		{
			CreateMap<CreateStreetDto, Street>();
			CreateMap<CreateStreetDto, StreetDto>();
			CreateMap<StreetDto, Street>();
			CreateMap<UpdateStreetDto, Street>();
			CreateMap<LiteStreetDto, Street>();
		}
	}
}
