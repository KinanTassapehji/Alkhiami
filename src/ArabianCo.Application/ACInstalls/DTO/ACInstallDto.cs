using Abp.Application.Services.Dto;
using ArabianCo.Attachments.Dto;
using ArabianCo.Brands.Dto;
using ArabianCo.Categories.Dto;
using ArabianCo.Cities.Dto;
using System;

namespace ArabianCo.ACInstalls.DTO
{
        public class ACInstallDto : EntityDto
        {
                public string Email { get; set; }
                public string FullName { get; set; }
                public string PhoneNumber { get; set; }
                public string SerialNumber { get; set; }
                public string Note { get; set; }
                public string Street { get; set; }
                public string Area { get; set; }
                public string OtherNotes { get; set; }
                public DateTime CreationTime { get; set; }
                public CityDetailsDto City { get; set; }
                public BrandDto Brand { get; set; }
                public CategoryDto Category { get; set; }
                public LiteAttachmentDto Attachment { get; set; }
        }
}
