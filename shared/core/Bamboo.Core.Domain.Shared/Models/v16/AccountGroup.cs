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
//[Index("ParentId", Name = "account_group_parent_id_index")]
//[Index("ParentPath", Name = "account_group_parent_path_index")]
public partial class AccountGroup: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("code_prefix_start")]
    public string? CodePrefixStart { get; set; }

    [Column("code_prefix_end")]
    public string? CodePrefixEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountGroups")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountGroupCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } = new List<AccountAccount>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<AccountGroup> InverseParent { get; set; } = new List<AccountGroup>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual AccountGroup? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountGroupWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
