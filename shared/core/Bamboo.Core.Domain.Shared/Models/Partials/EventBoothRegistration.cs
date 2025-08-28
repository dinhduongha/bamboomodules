using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("event_booth_registration")]
//[Index("SaleOrderLineId", "EventBoothId", Name = "event_booth_registration_unique_registration", IsUnique = true)]
public partial class EventBoothRegistration
{

    [Column("contact_mobile")]
    public string? ContactMobile { get; set; }

}
