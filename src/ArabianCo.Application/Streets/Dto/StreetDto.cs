using Abp.Application.Services.Dto;
using ArabianCo.Areas.Dto;
using ArabianCo.Cities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets.Dto
{
	public class StreetDto : EntityDto<int>
	{
		[Required]
		[StringLength(500)]
		public string Name { get; set; }
		public bool IsActive { get; set; }
		public LiteAreaDto Area { get; set; }
		public List<StreetTranslationDto> Translations { get; set; }
	}
}
