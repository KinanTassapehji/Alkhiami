using Abp.AutoMapper;
using ArabianCo.Domain.Areas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets.Dto
{
	[AutoMap(typeof(AreaTranslation))]
	public class StreetTranslationDto
	{
		/// <summary>
		/// Name
		/// </summary>
		[Required]
		public string Name { get; set; }
		/// <summary>
		/// Language
		/// </summary>
		[Required]
		public string Language { get; set; }
	}
}
