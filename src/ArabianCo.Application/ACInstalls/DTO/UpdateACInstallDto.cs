using Abp.Application.Services.Dto;
using ArabianCo.MaintenanceRequests.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls.DTO
{
	public class UpdateACInstallDto: CreateACInstallDto, IEntityDto
	{
		public int Id { get; set; }
	}
}
