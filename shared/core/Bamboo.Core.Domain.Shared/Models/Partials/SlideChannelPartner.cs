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

//[Table("slide_channel_partner")]
//[Index("ChannelId", Name = "slide_channel_partner__channel_id_index")]
//[Index("PartnerId", Name = "slide_channel_partner__partner_id_index")]
//[Index("ChannelId", "PartnerId", Name = "slide_channel_partner_channel_partner_uniq", IsUnique = true)]
public partial class SlideChannelPartner
{
    [Column("completed")]
    public bool? Completed { get; set; }
}
