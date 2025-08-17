using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("res_lang")]
//[Index("Code", Name = "res_lang_code_uniq", IsUnique = true)]
//[Index("Name", Name = "res_lang_name_uniq", IsUnique = true)]
//[Index("UrlCode", Name = "res_lang_url_code_uniq", IsUnique = true)]
public partial class ResLang: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("iso_code")]
    public string? IsoCode { get; set; }

    [Column("url_code")]
    public string? UrlCode { get; set; }

    [Column("direction")]
    public string? Direction { get; set; }

    [Column("date_format")]
    public string? DateFormat { get; set; }

    [Column("time_format")]
    public string? TimeFormat { get; set; }

    [Column("short_time_format")]
    public string? ShortTimeFormat { get; set; }

    [Column("week_start")]
    public string? WeekStart { get; set; }

    [Column("grouping")]
    public string? Grouping { get; set; }

    [Column("decimal_point")]
    public string? DecimalPoint { get; set; }

    [Column("thousands_sep")]
    public string? ThousandsSep { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("LangId")]
    [InverseProperty("Lang")]
    public virtual ICollection<ChatRoom> ChatRoom { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResLangCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LangId")]
    [InverseProperty("Lang")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("SelfOrderingDefaultLanguageId")]
    [InverseProperty("SelfOrderingDefaultLanguage")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("DefaultLangId")]
    [InverseProperty("DefaultLang")]
    public virtual ICollection<Website> Website { get; set; }

    // [One2many]
    [ForeignKey("LangId")]
    [InverseProperty("Lang")]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitor { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResLangWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("LangId")]
    // [InverseProperty("Lang")]
    // public virtual ICollection<BaseLanguageInstall> LanguageWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResLangId")]
    // [InverseProperty("ResLang")]
    // public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResLangId")]
    // [InverseProperty("ResLang")]
    // public virtual ICollection<ResUsersSettings> ResUsersSettings { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("LangId")]
    // [InverseProperty("Lang")]
    // public virtual ICollection<Website> WebsiteNavigation { get; set; }
}
