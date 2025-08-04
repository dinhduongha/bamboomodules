using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;
//[Keyless]
public partial class ImLivechatReportOperator
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
    
    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("livechat_channel_id")]
    public Guid? LivechatChannelId { get; set; }

    [Column("nbr_channel")]
    public long? NbrChannel { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("start_date", TypeName = "timestamp without time zone")]
    public DateTime? StartDate { get; set; }

    [Column("duration")]
    public decimal? Duration { get; set; }

    [Column("time_to_answer")]
    public decimal? TimeToAnswer { get; set; }
}
