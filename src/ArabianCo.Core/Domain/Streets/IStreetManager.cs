using Abp.Domain.Services;
using ArabianCo.Domain.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Streets
{
	public interface IStreetManager : IDomainService
	{
		Task<Street> GetEntityByIdAsync(int id);
		Task<bool> CheckIfStreetIsExist(List<StreetTranslation> Translations);

		Task<Street> GetLiteEntityByIdAsync(int id);
		Task IsEntityExistAsync(int id);
		Task<List<string>> GetAllStreetNamesForAutoComplete(string inputAutoComplete);
	}
}
