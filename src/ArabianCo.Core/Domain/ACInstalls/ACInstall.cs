using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.Addresses;
using ArabianCo.Domain.Brands;
using ArabianCo.Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArabianCo.Enums.Enum;

namespace ArabianCo.Domain.ACInstalls
{
	public class ACInstall:FullAuditedEntity
	{
		[EmailAddress]
		[StringLength(AbpUserBase.MaxEmailAddressLength)]
		public string Email { get; set; }
		[Required]
		[StringLength(AbpUserBase.MaxNameLength)]
		public string FullName { get; set; }
		[Required]
		[StringLength(AbpUserBase.MaxPhoneNumberLength)]
		public string PhoneNumber { get; set; }
		public string SerialNumber { get; set; }
		public string ModelNumber { get; set; }
		public string Note { get; set; }
                public MaintenanceRequestsStatus Status { get; set; }
                [Required]
                public int AddressId { get; set; }
                [ForeignKey(nameof(AddressId))]
                public virtual Address Address { get; set; }
		[Required]
		public int BrandId { get; set; }
		[ForeignKey(nameof(BrandId))]
		public virtual Brand Brand { get; set; }
		[Required]
		public int CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
		public virtual Category Category { get; set; }

	}
}
