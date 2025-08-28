using Abp.Domain.Services;
using System.Threading.Tasks;

namespace ArabianCo.Domain.ACInstalls
{
	public interface IACInstallManager:IDomainService
	{
		Task InsertAsync(ACInstall aCInstall);
		Task<ACInstall> GetEntityByIdAsync(int id);
	}
}
