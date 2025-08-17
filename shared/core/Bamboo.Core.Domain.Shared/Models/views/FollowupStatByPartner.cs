using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class FollowupStatByPartner: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("date_move")]
    public DateTime? DateMove { get; set; }

    [Column("date_move_last")]
    public DateTime? DateMoveLast { get; set; }

    [Column("date_followup")]
    public DateTime? DateFollowup { get; set; }

    [Column("max_followup_id")]
    public Guid? MaxFollowupId { get; set; }

    [Column("balance")]
    public decimal? Balance { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
}
