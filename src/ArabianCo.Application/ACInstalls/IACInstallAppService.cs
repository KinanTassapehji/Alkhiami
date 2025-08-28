using ArabianCo.ACInstalls.DTO;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.MaintenanceRequests.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls
{
	public interface IACInstallAppService : IArabianCoAsyncCrudAppService<ACInstallDto, int, LiteACInstallDto, PagedACInstallResultDto, CreateACInstallDto, UpdateACInstallDto>
	{
	}
}
