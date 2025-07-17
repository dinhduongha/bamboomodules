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
public partial class ResLang: FullAuditedEntity<Guid>, IEntityDto<Guid>, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResLangCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResLangWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    //[InverseProperty("Lang")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    //[InverseProperty("SelfOrderingDefaultLanguage")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } = new List<PosConfig>();

    //[InverseProperty("Lang")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; set; } = new List<WebsiteVisitor>();

    //[InverseProperty("DefaultLang")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; set; } = new List<Website>();

    [ForeignKey("LangId")]
    //[InverseProperty("Langs")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> LanguageWizards { get; set; } = new List<BaseLanguageInstall>();

    [ForeignKey("ResLangId")]
    //[InverseProperty("ResLangs")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigsNavigation { get; set; } = new List<PosConfig>();

    [ForeignKey("ResLangId")]
    //[InverseProperty("ResLangs")]
    [NotMapped]
    public virtual ICollection<ResUsersSetting> ResUsersSettings { get; set; } = new List<ResUsersSetting>();

    [ForeignKey("LangId")]
    //[InverseProperty("Langs")]
    [NotMapped]
    public virtual ICollection<Website> WebsitesNavigation { get; set; } = new List<Website>();
}
