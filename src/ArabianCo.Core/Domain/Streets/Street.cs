using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ArabianCo.Domain.Areas;
using ArabianCo.Domain.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Streets
{
	public class Street : FullAuditedEntity, IMultiLingualEntity<StreetTranslation>
	{
		public Street()
		{
			Translations = new HashSet<StreetTranslation>();
		}
		public bool IsActive { get; set; }
		public int AreaId { get; set; }
		[ForeignKey(nameof(AreaId))]
		public virtual Area Area { get; set; }
		public ICollection<StreetTranslation> Translations { get; set; }

	}
}
