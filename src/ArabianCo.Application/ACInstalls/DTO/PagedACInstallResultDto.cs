using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls.DTO
{
	public class PagedACInstallResultDto:PagedResultRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public string phoneNumber { get; set; }
	}
}
