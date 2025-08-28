using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ArabianCo.Domain.Areas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Streets
{
	internal class StreetManager : DomainService, IStreetManager
	{
		private readonly IRepository<Street> _streetRepository;
		private readonly IRepository<StreetTranslation> _streetTranslationRepository;

		public StreetManager(IRepository<Street> streetRepository,
			IRepository<StreetTranslation> streetTranslationRepository)
		{
			_streetRepository = streetRepository;
			_streetTranslationRepository = streetTranslationRepository;
		}

		public async Task<Street> GetEntityByIdAsync(int id)
		{
			var entity = await _streetRepository.GetAll()
				 .Include(c => c.Translations)
				 .Include(c => c.Area).ThenInclude(c => c.Translations)
				 .Include(c => c.Area).ThenInclude(c => c.City)
				 .ThenInclude(c => c.Translations)
				 .FirstOrDefaultAsync(x => x.Id == id);
			if (entity == null)
				throw new EntityNotFoundException(typeof(Street), id);
			return entity;
		}

		public async Task<Street> GetLiteEntityByIdAsync(int id)
		{
			var entity = await _streetRepository.GetAsync(id);
			if (entity == null)
				throw new EntityNotFoundException(typeof(Street), id);
			return entity;
		}
		public async Task IsEntityExistAsync(int id)
		{
			var entity = await _streetRepository.GetAsync(id);
			if (entity == null)
				throw new EntityNotFoundException(typeof(Street), id);
		}

		public async Task<bool> CheckIfStreetIsExist(List<StreetTranslation> Translations)
		{
			var Streets = await _streetTranslationRepository.GetAll().ToListAsync();
			foreach (var Translation in Translations)
			{
				foreach (var street in Streets)
					if (street.Name == Translation.Name && street.Language == Translation.Language)
						return true;
			}
			return false;
		}

		public async Task<List<string>> GetAllStreetNameForAutoComplete(string inputAutoComplete)
		{
			return await _streetTranslationRepository.GetAll().Where(x => x.Name.Contains(inputAutoComplete)).Select(x => x.Name).ToListAsync();
		}

		public Task<bool> CheckIfAreaIsExist(List<StreetTranslation> Translations)
		{
			throw new NotImplementedException();
		}

		public Task<List<string>> GetAllStreetNamesForAutoComplete(string inputAutoComplete)
		{
			throw new NotImplementedException();
		}
	}
}
