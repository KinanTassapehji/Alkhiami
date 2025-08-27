using Abp.Application.Services.Dto;
using ArabianCo.Areas.Dto;
using ArabianCo.Attachments.Dto;
using ArabianCo.Brands.Dto;
using ArabianCo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls.DTO
{
	public class ACInstallDto : EntityDto
	{
		public string Email { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string SerialNumber { get; set; }
		public string Problem { get; set; }
		public bool IsInWarrantyPeriod { get; set; }
		public string Address { get; set; }
		public DateTime CreationTime { get; set; }
		public AreaDetailsDto Area { get; set; }
		public BrandDto Brand { get; set; }
		public CategoryDto Category { get; set; }
		public LiteAttachmentDto Attachment { get; set; }
	}
}
