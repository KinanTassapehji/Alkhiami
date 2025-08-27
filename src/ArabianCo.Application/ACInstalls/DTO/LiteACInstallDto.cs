using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.ACInstalls.DTO
{
	public class LiteACInstallDto:EntityDto
	{
		public string Email { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string SerialNumber { get; set; }
		public string Note { get; set; }
		public bool IsInWarrantyPeriod { get; set; }
		public DateTime CreationTime { get; set; }
		public string Address { get; set; }
		public int? CityId { get; set; }
		public string OtherCity { get; set; }
		public string CityName { get; set; }
	}
}
