using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Streets
{
	public class StreetTranslation : FullAuditedEntity, IEntityTranslation<Street>
	{
		public string Name { get; set; }
		public Street Core { get; set; }
		public int CoreId { get; set; }
		public string Language { get; set; }
	}
}
