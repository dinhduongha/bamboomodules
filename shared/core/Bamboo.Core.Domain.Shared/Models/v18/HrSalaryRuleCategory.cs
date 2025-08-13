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

[Table("hr_salary_rule_category")]
public partial class HrSalaryRuleCategory: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }


    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrSalaryRuleCategories")] //Many2One
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrSalaryRuleCategoryCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("Category") //Many2many
    public virtual ICollection<HrPayslipLine> HrPayslipLines { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Category") //Many2many
    public virtual ICollection<HrSalaryRule> HrSalaryRules { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Parent") //Many2many
    public virtual ICollection<HrSalaryRuleCategory> InverseParent { get; set; } = null;

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")] //Many2One
    public virtual HrSalaryRuleCategory? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrSalaryRuleCategoryWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
