using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace ArabianCo.Domain.ACInstalls
{
	internal class ACInstallManager:DomainService, IACInstallManager
	{
		private readonly IRepository<ACInstall> _repository;

		public ACInstallManager(IRepository<ACInstall> repository)
		{
			_repository = repository;
		}

		public async Task<ACInstall> GetEntityByIdAsync(int id)
		{
                        var entity = await _repository.GetAll().Where(x => x.Id == id)
                                .Include(x => x.Brand)
                                .Include(x => x.Category)
                                .Include(x => x.Address).ThenInclude(a => a.City).ThenInclude(c => c.Translations)
                                .Include(x => x.Address).ThenInclude(a => a.City).ThenInclude(c => c.Country).ThenInclude(c => c.Translations).FirstOrDefaultAsync();
			if (entity == null)
				throw new EntityNotFoundException(typeof(ACInstall), id);
			return entity;
		}

		public async Task InsertAsync(ACInstall aCInstall)
		{
			await _repository.InsertAsync(aCInstall);
		}
	}
}
