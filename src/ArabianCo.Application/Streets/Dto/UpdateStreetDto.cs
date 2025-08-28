using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using ArabianCo.Areas.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets.Dto
{
	public class UpdateStreetDto : CreateStreetDto, IEntityDto, ICustomValidate
	{
		[Required]
		public int Id { get; set; }

		public override void AddValidationErrors(CustomValidationContext context)
		{
			if (Id == 0)
				context.Results.Add(new ValidationResult("Id must has value"));
			if (AreaId == 0)
				context.Results.Add(new ValidationResult("AreaId must has value"));
			if (Translations is null || Translations.Count < 2)
				context.Results.Add(new ValidationResult("Translations must contain at least two elements"));
		}
	}
}
