using Abp.Application.Services.Dto;
using System;

namespace ArabianCo.MaintenanceRequests.Dto;

public class LiteMaintenanceRequestDto:EntityDto
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string SerialNumber { get; set; }
    public string Problem { get; set; }
    public bool IsInWarrantyPeriod { get; set; }
    public DateTime CreationTime { get; set; }
    public string Street { get; set; }
    public string Area { get; set; }
    public string OtherNotes { get; set; }
    public string CityName { get; set; }
}
