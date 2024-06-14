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

[Table("account_group_template")]
public partial class AccountGroupTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code_prefix_start")]
    public string? CodePrefixStart { get; set; }

    [Column("code_prefix_end")]
    public string? CodePrefixEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("AccountGroupTemplates")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountGroupTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual AccountGroupTemplate? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountGroupTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<AccountGroupTemplate> InverseParent { get; } = new List<AccountGroupTemplate>();

}
