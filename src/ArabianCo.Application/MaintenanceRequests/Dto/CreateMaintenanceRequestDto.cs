using Abp;
using Abp.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ArabianCo.Enums.Enum;

namespace ArabianCo.MaintenanceRequests.Dto;

public class CreateMaintenanceRequestDto : IValidatableObject, IShouldInitialize
{
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string Email { get; set; }
    [Required]
    [StringLength(AbpUserBase.MaxNameLength)]
    public string FullName { get; set; }
    [Required]
    [MaxLength(10)]
    [MinLength(10)]
    public string PhoneNumber { get; set; }
    public string SerialNumber { get; set; }
    public string ModelNumber { get; set; }
    public string Problem { get; set; }
    public MaintenanceRequestsStatus Status { get; set; }
    [Required]
    public bool IsInWarrantyPeriod { get; set; }

    [Required]
    public int CityId { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string Area { get; set; }
    public string OtherNotes { get; set; }

    [Required]
    public int BrandId { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public int? AttachmentId { get; set; }

    public void Initialize()
    {
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}
