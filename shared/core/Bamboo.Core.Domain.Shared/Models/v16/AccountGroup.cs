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

[Table("account_group")]
//[Index("ParentId", Name = "account_group__parent_id_index")]
//[Index("ParentPath", Name = "account_group_parent_path_index")]
public partial class AccountGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("code_prefix_start")]
    public string? CodePrefixStart { get; set; }

    [Column("code_prefix_end")]
    public string? CodePrefixEnd { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountGroup")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountGroupCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<AccountGroup> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual AccountGroup? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountGroupWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
