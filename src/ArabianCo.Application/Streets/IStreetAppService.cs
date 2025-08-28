using ArabianCo.Areas.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Streets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets
{
	public interface IStreetAppService : IArabianCoAsyncCrudAppService<StreetDetailsDto, int, LiteStreetDto
		, PagedStreetResultRequestDto,
		CreateStreetDto, UpdateStreetDto>
	{
	}
}
