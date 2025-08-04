using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;
//[Keyless]
public partial class ImLivechatReportChannel
{
    [Column("id")]
    public Guid? Id { get; set; }
    
    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("uuid")]
    [StringLength(50)]
    public string? Uuid { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("channel_name", TypeName = "character varying")]
    public string? ChannelName { get; set; }

    [Column("technical_name")]
    public string? TechnicalName { get; set; }

    [Column("livechat_channel_id")]
    public Guid? LivechatChannelId { get; set; }

    [Column("start_date", TypeName = "timestamp without time zone")]
    public DateTime? StartDate { get; set; }

    [Column("start_date_hour")]
    public string? StartDateHour { get; set; }

    [Column("start_hour")]
    public string? StartHour { get; set; }

    [Column("day_number")]
    public decimal? DayNumber { get; set; }

    [Column("duration")]
    public decimal? Duration { get; set; }

    [Column("time_to_answer")]
    public decimal? TimeToAnswer { get; set; }

    [Column("nbr_speaker")]
    public long? NbrSpeaker { get; set; }

    [Column("nbr_message")]
    public long? NbrMessage { get; set; }

    [Column("is_without_answer")]
    public int? IsWithoutAnswer { get; set; }

    [Column("days_of_activity")]
    public double? DaysOfActivity { get; set; }

    [Column("is_anonymous")]
    public int? IsAnonymous { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("is_happy")]
    public int? IsHappy { get; set; }

    [Column("rating")]
    public double? Rating { get; set; }

    [Column("rating_text")]
    public string? RatingText { get; set; }

    [Column("is_unrated")]
    public int? IsUnrated { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }
}
