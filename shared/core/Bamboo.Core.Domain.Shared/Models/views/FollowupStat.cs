using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class FollowupStat: Entity<Guid>, IMultiTenant
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

    [Column("followup_id")]
    public Guid? FollowupId { get; set; }

    [Column("debit")]
    public decimal? Debit { get; set; }

    [Column("credit")]
    public decimal? Credit { get; set; }

    [Column("balance")]
    public decimal? Balance { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("blocked")]
    public bool? Blocked { get; set; }
}
