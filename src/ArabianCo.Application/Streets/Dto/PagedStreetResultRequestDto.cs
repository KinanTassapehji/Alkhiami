using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets.Dto
{
	public class PagedStreetResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
		public int? AreaId { get; set; }
		public bool? IsActive { get; set; }
	}
}
