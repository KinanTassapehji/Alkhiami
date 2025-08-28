using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ArabianCo.ACInstalls.DTO;
using ArabianCo.Cities.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.ACInstalls;
using ArabianCo.Domain.Attachments;
using ArabianCo.Domain.Cities;
using ArabianCo.Domain.Addresses;
using ArabianCo.EmailAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls
{
	public class ACInstallAppService : ArabianCoAsyncCrudAppService<ACInstall, ACInstallDto, int, LiteACInstallDto, PagedACInstallResultDto, CreateACInstallDto, UpdateACInstallDto>
	{
		//private readonly IMaintenanceRequestsManger _maintenanceRequestsManger;
		private readonly IAttachmentManager _attachmentManager;
                private readonly IEmailService _emailService;
                private readonly IRepository<City> _cityRepository;
                private readonly IRepository<Address> _addressRepository;
		public ACInstallAppService(IRepository<ACInstall, int> repository /*IMaintenanceRequestsManger maintenanceRequestsManger*/,
                        IAttachmentManager attachmentManager,
                        IEmailService emailService,
                        IRepository<City> cityRepository,
                        IRepository<Address> addressRepository) : base(repository)
                {
                        _attachmentManager = attachmentManager;
                        _emailService = emailService;
                        _cityRepository = cityRepository;
                        _addressRepository = addressRepository;
                        /*_maintenanceRequestsManger = maintenanceRequestsManger;*/
                }
		[AbpAllowAnonymous]
                public async override Task<ACInstallDto> CreateAsync(CreateACInstallDto input)
                {
                        input.PhoneNumber = input.PhoneNumber.Trim();
                        if (input.PhoneNumber.Length != 10)
                        {
                                throw new UserFriendlyException("Phone number should be 10 digits");
                        }
                        if (await Repository.GetAll()
                                .Where(r => r.PhoneNumber == input.PhoneNumber)
                                .Where(r => r.CreationTime > DateTime.Now.AddDays(-1))
                                .AnyAsync())
                        {
                                throw new UserFriendlyException("Only one request allowed a day");
                        }

                        var address = new Address
                        {
                                CityId = input.CityId,
                                Street = input.Street,
                                Area = input.Area,
                                OtherNotes = input.OtherNotes
                        };
                        await _addressRepository.InsertAsync(address);
                        await CurrentUnitOfWork.SaveChangesAsync();

                        var entity = ObjectMapper.Map<ACInstall>(input);
                        entity.AddressId = address.Id;

                        await Repository.InsertAsync(entity);
                        await CurrentUnitOfWork.SaveChangesAsync();

                        if (input.AttachmentId.HasValue)
                                await _attachmentManager.CheckAndUpdateRefIdAsync(input.AttachmentId.Value, Enums.Enum.AttachmentRefType.ACInstall, entity.Id);
                        try
                        {
                                string cityName = await _cityRepository.GetAll().Include(c => c.Translations)
                                                .Where(c => c.Id == input.CityId)
                                                .Select(c => c.Translations.FirstOrDefault().Name)
                                                .FirstOrDefaultAsync();
                                if (!input.Email.IsNullOrEmpty())
                                {
                                        var mailAddress = new System.Net.Mail.MailAddress(input.Email);
                                        await _emailService.SendEmailAsync(new List<string>
                                        {
                                                input.Email,
                                        }, "العربية الدولية للأجهزة،نشكر تواصلكم.", "تم رفع طلب الصيانة بنجاح ، \r\nستصلكم رسالة نصية قبل الموعد بيوم لتأكيد الفترة.\r\nيرجى التواجد في الموقع، مع إمكانية تقديم الموعد في حال توفرت إمكانية.\r\n\r\n*للتواصل والاستفسار يرجى التواصل عبر الرقم الموحد*\r\n8001244080");
                                }
                                await _emailService.SendEmailAsync(new List<string>
                                { /*"aftersales11@arabianco.com", "aftersales14@arabianco.com", "aftersales9@arabianco.com"*/ "malaz.tassapehji@gmail.com"},
                                "New Maintenance Request",
                                $"Client Name: {input.FullName} \r\nPhone: {input.PhoneNumber}\r\nCity: {cityName}\r\nArea: {input.Area}\r\nNote: {input.Note}\r\nAt: {entity.CreationTime}"
                                );
                        }
                        catch (Exception)
                        {
                        }
                        return await GetAsync(new EntityDto<int>(entity.Id));
                }
		[AbpAllowAnonymous]
		public override async Task<ACInstallDto> GetAsync(EntityDto<int> input)
		{
                        var entity = await Repository.GetAll()
                                .IgnoreQueryFilters()
                                .Where(x => x.Id == input.Id)
                                .Include(x => x.Brand).ThenInclude(x => x.Translations)
                                .Include(x => x.Category).ThenInclude(x => x.Translations)
                                .Include(x => x.Address).ThenInclude(a => a.City).ThenInclude(c => c.Translations)
                                .Include(x => x.Address).ThenInclude(a => a.City).ThenInclude(c => c.Country).ThenInclude(c => c.Translations)
                                .FirstOrDefaultAsync();

			if (entity == null)
			{
				throw new EntityNotFoundException(typeof(ACInstall), input.Id);
			}

			var attachment = await _attachmentManager.GetAttachmentByRefAsync(entity.Id, Enums.Enum.AttachmentRefType.ACInstall);
                        var result = MapToEntityDto(entity);
                        result.CreationTime = result.CreationTime.AddHours(10);

			if (attachment != null)
			{
				result.Attachment = new Attachments.Dto.LiteAttachmentDto
				{
					Id = attachment.Id,
					Url = _attachmentManager.GetUrl(attachment),
					RefType = Enums.Enum.AttachmentRefType.ACInstall
				};
			}

			return result;
		}
		[AbpAllowAnonymous]
		public override async Task<PagedResultDto<LiteACInstallDto>> GetAllAsync(PagedACInstallResultDto input)
		{
			var result = await base.GetAllAsync(input);
			foreach (var item in result.Items)
			{
				item.CreationTime = item.CreationTime.AddHours(10);
			}
			return result;
		}

                protected override LiteACInstallDto MapToLiteEntityDto(ACInstall entity)
                {
                        var dto = base.MapToLiteEntityDto(entity);
                        if (entity.Address?.City != null)
                        {
                                dto.CityName = entity.Address.City.MapTo<LiteCityDto>().Name;
                        }
                        return dto;
                }
		[ApiExplorerSettings(IgnoreApi = true)]
		public override Task<ACInstallDto> UpdateAsync(UpdateACInstallDto input)
		{
			return base.UpdateAsync(input);
		}
		public override async Task DeleteAsync(EntityDto<int> input)
		{
			await _attachmentManager.DeleteAllRefIdAsync(input.Id, Enums.Enum.AttachmentRefType.ACInstall);
			await base.DeleteAsync(input);
		}
		protected override IQueryable<ACInstall> CreateFilteredQuery(PagedACInstallResultDto input)
		{
                        IQueryable<ACInstall> query = Repository.GetAll()
                                .Include(x => x.Address).ThenInclude(a => a.City).ThenInclude(c => c.Translations);
			if (input.IsDeleted)
			{
				query = query.IgnoreQueryFilters().Where(x => x.IsDeleted);
			}
			//var query = Repository.GetAll();
			if (!input.phoneNumber.IsNullOrWhiteSpace())
			{
				query = query.Where(x => x.PhoneNumber.Contains(input.phoneNumber));
			}

			return query;
		}
	}
}
