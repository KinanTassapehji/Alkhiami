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
	public class CreateStreetDto : ICustomValidate
	{
		[Required]
		public List<StreetTranslationDto> Translations { get; set; }
		[Required]
		public int AreaId { get; set; }
		public virtual void AddValidationErrors(CustomValidationContext context)
		{
			if (AreaId == 0)
				context.Results.Add(new ValidationResult("Area must has value"));
			if (Translations is null || Translations.Count < 2)
				context.Results.Add(new ValidationResult("Translations must contain at least two elements"));
		}
	}
}
