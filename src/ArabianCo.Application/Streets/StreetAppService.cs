using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ArabianCo.Areas;
using ArabianCo.Areas.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.Areas;
using ArabianCo.Domain.Countries;
using ArabianCo.Domain.Streets;
using ArabianCo.Localization.SourceFiles;
using ArabianCo.Streets.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Streets
{
	public class StreetAppService : ArabianCoAsyncCrudAppService<Street, StreetDetailsDto, int, LiteStreetDto,
		PagedStreetResultRequestDto, CreateStreetDto, UpdateStreetDto>,
		IStreetAppService
	{
		private readonly IStreetManager _streetManager;
		private readonly ICountryManager _countryManager;



		/// <summary>
		/// Region AppService
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="regionManager"></param>
		/// <param name="countryManager"></param>
		/// <param name="regionTranslationRepository"></param>

		public StreetAppService(IRepository<Street> repository, IStreetManager streetManager,
			ICountryManager countryManager)
		: base(repository)
		{

			_streetManager = streetManager;
			_countryManager = countryManager;
		}
		/// <summary>
		/// Get Region Details ById
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public override async Task<StreetDetailsDto> GetAsync(EntityDto<int> input)
		{
			var street = await _streetManager.GetEntityByIdAsync(input.Id);
			if (street is null)
				throw new UserFriendlyException(string.Format(Exceptions.ObjectWasNotFound, Tokens.Street));
			return MapToEntityDto(street);
		}
		/// <summary>
		/// Get All Regions Details
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAllowAnonymous]
		public override async Task<PagedResultDto<LiteStreetDto>> GetAllAsync(PagedStreetResultRequestDto input)
		{

			return await base.GetAllAsync(input);
		}
		/// <summary>
		/// Add New Region Details
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAllowAnonymous]
		public override async Task<StreetDetailsDto> CreateAsync(CreateStreetDto input)
		{
			CheckCreatePermission();
			var Translation = ObjectMapper.Map<List<StreetTranslation>>(input.Translations);
			if (await _streetManager.CheckIfStreetIsExist(Translation))
				throw new UserFriendlyException(string.Format(Exceptions.ObjectIsAlreadyExist, Tokens.Street));
			var street = ObjectMapper.Map<Street>(input);
			street.IsActive = true;
			street.CreationTime = DateTime.UtcNow;
			await Repository.InsertAsync(street);
			return MapToEntityDto(street);
		}
		/// <summary>
		/// Update Region Details
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize]
		public override async Task<StreetDetailsDto> UpdateAsync(UpdateStreetDto input)
		{
			CheckUpdatePermission();
			var street = await _streetManager.GetEntityByIdAsync(input.Id);
			if (street is null)
				throw new UserFriendlyException(string.Format(Exceptions.ObjectWasNotFound, Tokens.Street));
			street.Translations.Clear();
			MapToEntity(input, street);
			street.LastModificationTime = DateTime.UtcNow;
			await Repository.UpdateAsync(street);
			return MapToEntityDto(street);
		}

		/// <summary>
		/// Delete Region Details
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize]
		public override async Task DeleteAsync(EntityDto<int> input)
		{
			CheckDeletePermission();
			var region = await _streetManager.GetEntityByIdAsync(input.Id);
			if (region is null)
				throw new UserFriendlyException(string.Format(Exceptions.ObjectWasNotFound, Tokens.Street));
			await Repository.DeleteAsync(region);
		}

		/// <summary>
		/// Filter For A Group Of Regions
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		protected override IQueryable<Street> CreateFilteredQuery(PagedStreetResultRequestDto input)
		{
			var data = base.CreateFilteredQuery(input);
			data = data.Include(x => x.Translations);
			data = data.Include(x => x.Area).ThenInclude(x => x.Translations).
				Include(x => x.Area).ThenInclude(x => x.Streets).ThenInclude(x => x.Translations);
			if (!input.Keyword.IsNullOrEmpty())
				data = data.Where(x => x.Translations.Where(x => x.Name.Contains(input.Keyword)).Any());
			if (input.AreaId.HasValue)
				data = data.Where(x => x.AreaId == input.AreaId);
			if (input.IsActive.HasValue)
				data = data.Where(x => x.IsActive == input.IsActive.Value);
			return data;
		}

		/// <summary>
		/// Sorting Filtered Regions
		/// </summary>
		/// <param name="query"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		protected override IQueryable<Street> ApplySorting(IQueryable<Street> query, PagedStreetResultRequestDto input)
		{
			return query.OrderByDescending(r => r.CreationTime);
		}

		/// <summary>
		/// Switch Activation Of A Region
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<StreetDetailsDto> SwitchActivationAsync(SwitchActivationInputDto input)
		{
			CheckUpdatePermission();
			var region = await _streetManager.GetLiteEntityByIdAsync(input.Id);
			if (region is null)
				throw new UserFriendlyException(string.Format(Exceptions.ObjectWasNotFound, Tokens.Street));
			region.IsActive = !region.IsActive;
			return MapToEntityDto(region);
		}
	}
}
